using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;

namespace Chronolibris.Infrastructure.DataAccess.Files
{
    /// <summary>
    /// Единая реализация <see cref="IStorageService"/>.
    /// Делегирует все операции с MinIO низкоуровневому <see cref="IMinioService"/>.
    ///
    /// <para><b>Структура ключей:</b></para>
    /// <code>
    /// books/
    ///   v1/
    ///     {bookId}/
    ///       source.fb2            ← исходник
    ///       chunks/
    ///         000.json            ← фрагменты
    ///         toc.json
    ///       images/
    ///         1.jpg               ← картинки из книги
    ///
    /// pcovers/
    ///   uploads/
    ///     {guid}_{fileName}       ← пользовательские загрузки
    /// </code>
    /// </summary>
    public sealed class StorageService : IStorageService
    {
        private readonly IMinioService _minio;
        private readonly IMinioClient _minioClient;
        private readonly BookStorageOptions _bookOpts;
        private readonly UploadStorageOptions _uploadOpts;

        public StorageService(
            IMinioService minio,
            IMinioClient minioClient,
            IOptions<BookStorageOptions> bookOpts,
            IOptions<UploadStorageOptions> uploadOpts)
        {
            _minio = minio;
            _bookOpts = bookOpts.Value;
            _uploadOpts = uploadOpts.Value;
            _minioClient = minioClient;
        }

        // ── Исходники книг ────────────────────────────────────────────────────────

        /// <inheritdoc/>
        //public Task SaveBookSourceAsync(
        //    string bookId, string extension, Stream data, string contentType,
        //    CancellationToken ct = default)
        //{
        //    var key = BookSourceKey(bookId, extension);
        //    return _minio.PutAsync(_bookOpts.BooksBucket, key, data, data.Length, contentType, ct);
        //}


        public async Task<string> SaveBookSourceAsync(
    string bookId, string extension, Stream data,
    CancellationToken ct = default)
        {
            var key = BookSourceKey(bookId, extension);
            var contentType = ResolveContentType(extension);
            await _minio.PutAsync(_bookOpts.BooksBucket, key, data, data.Length, contentType, ct);
            return key;
        }

        private static string ResolveContentType(string extension) =>
            extension.ToLowerInvariant() switch
            {
                ".fb2" => "application/xml",
                ".epub" => "application/epub+zip",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };


        /// <inheritdoc/>
        public Task<Stream?> ReadBookSourceAsync(
            string bookId, string extension,
            CancellationToken ct = default)
        {
            var key = BookSourceKey(bookId, extension);
            return _minio.GetAsync(_bookOpts.BooksBucket, key, ct);
        }

        public Task<Stream?> ReadByStorageUrlAsync(string storageUrl, CancellationToken ct = default)
    => _minio.GetAsync(_bookOpts.BooksBucket, storageUrl, ct);

        // ── Фрагменты (chunks) ────────────────────────────────────────────────────

        /// <inheritdoc/>
        public async Task SaveChunkAsync(
            string bookId, string fileName, string content,
            CancellationToken ct = default)
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            using var ms = new MemoryStream(bytes);
            var key = ChunkKey(bookId, fileName);
            await _minio.PutAsync(
                _bookOpts.BooksBucket, key, ms, bytes.Length,
                "application/json; charset=utf-8", ct);
        }

        /// <inheritdoc/>
        public async Task<string?> ReadChunkAsync(
            string bookId, string fileName,
            CancellationToken ct = default)
        {
            var key = ChunkKey(bookId, fileName);
            await using var stream = await _minio.GetAsync(_bookOpts.BooksBucket, key, ct);
            if (stream is null) return null;

            using var reader = new StreamReader(stream, Encoding.UTF8);
            return await reader.ReadToEndAsync(ct);
        }

        /// <inheritdoc/>
        public Task<bool> ChunkExistsAsync(
            string bookId, string fileName,
            CancellationToken ct = default)
        {
            var key = ChunkKey(bookId, fileName);
            return _minio.ExistsAsync(_bookOpts.BooksBucket, key, ct);
        }

        // ── Изображения книг ──────────────────────────────────────────────────────

        /// <inheritdoc/>
        public async Task SaveBookImageAsync(
            string bookId, string fileName, byte[] data, string contentType,
            CancellationToken ct = default)
        {
            using var ms = new MemoryStream(data);
            var key = BookImageKey(bookId, fileName);
            await _minio.PutAsync(_bookOpts.BooksBucket, key, ms, data.Length, contentType, ct);
        }

        // ── Пользовательские загрузки ─────────────────────────────────────────────

        /// <inheritdoc/>
        public async Task<string> UploadFileAsync(
            Stream fileStream, string fileName, string contentType,
            CancellationToken ct = default)
        {
            var storageUrl = UploadKey(fileName);
            await _minio.PutAsync(
                _uploadOpts.UploadsBucket, storageUrl,
                fileStream, fileStream.Length, contentType, ct);
            return storageUrl;
        }

        /// <inheritdoc/>
        public Task DeleteFileAsync(string storageUrl, CancellationToken ct = default)
            => _minio.DeleteAsync(_uploadOpts.UploadsBucket, storageUrl, ct);


        /// <summary>
        /// Удаляет все объекты книги из бакета books:
        /// source-файл, все чанки (v1/{bookId}/chunks/) и все изображения (v1/{bookId}/images/).
        /// Идемпотентен — не бросает исключение если объекты уже удалены.
        /// </summary>
        public async Task DeleteBookAsync(
            string bookId, string extension,
            CancellationToken ct = default)
        {
            // 1. Source-файл
            await _minio.DeleteAsync(_bookOpts.BooksBucket, BookSourceKey(bookId, extension), ct);

            // 2. Чанки и изображения — удаляем по префиксу
            await DeleteByPrefixAsync($"{_bookOpts.Prefix}/{bookId}/chunks/", ct);
            await DeleteByPrefixAsync($"{_bookOpts.Prefix}/{bookId}/images/", ct);
        }

        private async Task DeleteByPrefixAsync(string prefix, CancellationToken ct)
        {
            var listArgs = new ListObjectsArgs()
                .WithBucket(_bookOpts.BooksBucket)
                .WithPrefix(prefix)
                .WithRecursive(true);

            var keys = new List<string>();

            // ListObjectsEnumAsync — неблокирующий стриминговый листинг
            await foreach (var item in _minioClient.ListObjectsEnumAsync(listArgs, ct))
                keys.Add(item.Key);

            foreach (var key in keys)
                await _minio.DeleteAsync(_bookOpts.BooksBucket, key, ct);
        }


        //private async Task DeleteByPrefixAsync(string prefix, CancellationToken ct)
        //{
        //    var listArgs = new ListObjectsArgs()
        //        .WithBucket(_bookOpts.BooksBucket)
        //        .WithPrefix(prefix)
        //        .WithRecursive(true);

        //    var keys = new List<DeleteObject>();

        //    await foreach (var item in _minioClient.ListObjectsEnumAsync(listArgs, ct))
        //        keys.Add(new DeleteObject(item.Key));

        //    if (keys.Count == 0) return;

        //    var removeArgs = new RemoveObjectsArgs()
        //        .WithBucket(_bookOpts.BooksBucket)
        //        .WithObjects((IList<string>)keys);

        //    await _minioClient.RemoveObjectsAsync(removeArgs, ct);
        //}

        // ── Ключи объектов ────────────────────────────────────────────────────────

        // books / v1 / {bookId} / source.fb2
        private string BookSourceKey(string bookId, string extension)
            => $"{_bookOpts.Prefix}/{bookId}/source{extension}";

        // books / v1 / {bookId} / chunks / {fileName}
        private string ChunkKey(string bookId, string fileName)
            => $"{_bookOpts.Prefix}/{bookId}/chunks/{fileName}";

        // books / v1 / {bookId} / images / {fileName}
        private string BookImageKey(string bookId, string fileName)
            => $"{_bookOpts.Prefix}/{bookId}/images/{fileName}";

        // pcovers / uploads / {guid}_{fileName}
        private static string UploadKey(string fileName)
            => $"uploads/{Guid.NewGuid()}_{fileName}";
    }
}
