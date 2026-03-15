using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Interfaces.Services
{
    /// <summary>
    /// Единый высокоуровневый интерфейс хранилища.
    /// Объединяет бывшие <c>IBookStorage</c> и <c>IFileService</c>.
    ///
    /// <para><b>Структура ключей в MinIO:</b></para>
    /// <list type="bullet">
    ///   <item>
    ///     <b>Бакет <c>books</c></b> — всё, связанное с книгами:<br/>
    ///     Исходник (FB2):    <c>v1/{bookId}/source.fb2</c><br/>
    ///     Фрагменты (JSON):  <c>v1/{bookId}/chunks/{fileName}</c>  (напр. <c>000.json</c>, <c>toc.json</c>)<br/>
    ///     Изображения:       <c>v1/{bookId}/images/{fileName}</c>  (напр. <c>1.jpg</c>)
    ///   </item>
    ///   <item>
    ///     <b>Бакет <c>pcovers</c></b> — пользовательские загрузки (обложки и прочее):<br/>
    ///     <c>uploads/{guid}_{originalFileName}</c>
    ///   </item>
    /// </list>
    ///
    /// <para>
    /// Методы, работающие с фрагментами книги, принимают <paramref name="bookId"/>
    /// в виде строки (GUID из БД). Методы для обычных файлов возвращают/принимают
    /// <c>storageUrl</c> — полный ключ объекта внутри бакета, который можно
    /// хранить в БД и передавать обратно в метод удаления.
    /// </para>
    /// </summary>
    public interface IStorageService
    {
        // ── Книги: исходники ──────────────────────────────────────────────────────

        /// <summary>
        /// Сохраняет исходный файл книги и возвращает его ключ (storageUrl) для сохранения в БД.
        /// ContentType определяется автоматически по расширению.
        /// </summary>
        /// <param name="bookId">Идентификатор книги в БД.</param>
        /// <param name="extension">Расширение файла с точкой, напр. <c>.fb2</c>.</param>
        /// <param name="data">Поток с содержимым файла.</param>
        /// <returns>Ключ объекта (storageUrl), напр. <c>v1/{bookId}/source.fb2</c>.</returns>
        Task<string> SaveBookSourceAsync(
            string bookId,
            string extension,
            Stream data,
            CancellationToken ct = default);

        /// <summary>
        /// Открывает исходный файл книги для чтения.
        /// Возвращает <c>null</c>, если файл не найден.
        /// </summary>
        Task<Stream?> ReadBookSourceAsync(
            string bookId,
            string extension,
            CancellationToken ct = default);

        /// <summary>
        /// Читает произвольный объект из бакета книг по полному ключу,
        /// хранящемуся в БД (storageUrl).
        /// Используется когда bookId и расширение неизвестны — только ключ.
        /// Возвращает <c>null</c>, если объект не найден.
        /// </summary>
        Task<Stream?> ReadByStorageUrlAsync(
            string storageUrl,
            CancellationToken ct = default);

        // ── Книги: фрагменты (chunks) ─────────────────────────────────────────────

        /// <summary>
        /// Сохраняет JSON-фрагмент книги.
        /// Ключ объекта: <c>v1/{bookId}/chunks/{fileName}</c>
        /// </summary>
        Task SaveChunkAsync(
            string bookId,
            string fileName,
            string content,
            CancellationToken ct = default);

        /// <summary>
        /// Читает JSON-фрагмент книги.
        /// Возвращает <c>null</c>, если фрагмент не найден.
        /// </summary>
        Task<string?> ReadChunkAsync(
            string bookId,
            string fileName,
            CancellationToken ct = default);

        /// <summary>
        /// Проверяет, существует ли фрагмент книги.
        /// </summary>
        Task<bool> ChunkExistsAsync(
            string bookId,
            string fileName,
            CancellationToken ct = default);

        // ── Книги: изображения ────────────────────────────────────────────────────

        /// <summary>
        /// Сохраняет изображение, извлечённое из книги.
        /// Ключ объекта: <c>v1/{bookId}/images/{fileName}</c>
        /// </summary>
        Task SaveBookImageAsync(
            string bookId,
            string fileName,
            byte[] data,
            string contentType,
            CancellationToken ct = default);

        // ── Пользовательские загрузки ─────────────────────────────────────────────

        /// <summary>
        /// Загружает произвольный файл (обложку и т.п.) и возвращает его ключ
        /// (<c>storageUrl</c>), который следует сохранить в БД.
        /// Ключ объекта: <c>uploads/{guid}_{fileName}</c>
        /// </summary>
        /// <returns>Ключ объекта внутри бакета (storageUrl).</returns>
        Task<string> UploadFileAsync(
            Stream fileStream,
            string fileName,
            string contentType,
            CancellationToken ct = default);

        /// <summary>
        /// Удаляет ранее загруженный файл по ключу, возвращённому методом
        /// <see cref="UploadFileAsync"/>.
        /// Не бросает исключение, если файл уже удалён.
        /// </summary>
        /// <param name="storageUrl">Ключ объекта внутри бакета (то, что хранится в БД).</param>
        Task DeleteFileAsync(
            string storageUrl,
            CancellationToken ct = default);
    }
}
