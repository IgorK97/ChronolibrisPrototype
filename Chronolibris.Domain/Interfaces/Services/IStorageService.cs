using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Interfaces.Services
{

    public interface IStorageService
    {
        string PublicCoversBucket { get; }

        Task DeleteAsync(string bucketName, string objectKey, CancellationToken ct = default);
        Task<string> SaveBookSourceAsync(
            string bookId,
            string extension,
            Stream data,
            CancellationToken ct = default);
        Task<Stream?> ReadBookSourceAsync(
            string bookId,
            string extension,
            CancellationToken ct = default);
        Task<Stream?> ReadByStorageUrlAsync(
            string storageUrl,
            CancellationToken ct = default);
        Task SaveChunkAsync(
            string bookId,
            string fileName,
            string content,
            string type,
            CancellationToken ct = default);
        Task<string?> ReadChunkAsync(
            string bookId,
            string fileName,
            string type,
            CancellationToken ct = default);
        Task<bool> ChunkExistsAsync(
            string bookId,
            string fileName,
            string type,
            CancellationToken ct = default);
        Task SavePublicBookImageAsync(
            string bookId,
            string fileName,
            byte[] data,
            string contentType,
            CancellationToken ct = default);

        Task SaveCoverAsync(string bookId, string fileName, byte[] data, string contentType, CancellationToken ct = default);
        Task<string> UploadFileAsync(
            Stream fileStream,
            string fileName,
            string contentType,
            CancellationToken ct = default);

        Task DeleteFileAsync(
            string storageUrl,
            CancellationToken ct = default);
    }
}
