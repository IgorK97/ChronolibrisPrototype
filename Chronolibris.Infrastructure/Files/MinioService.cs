using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Interfaces.Services;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace Chronolibris.Infrastructure.DataAccess.Files
{
    /// <summary>
    /// Реализация <see cref="IMinioService"/> поверх официального MinIO .NET SDK.
    /// Регистрируется как Singleton.
    /// </summary>
    public sealed class MinioService : IMinioService
    {
        private readonly IMinioClient _client;

        public MinioService(IMinioClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public async Task PutAsync(
            string bucketName,
            string objectName,
            Stream data,
            long size,
            string contentType,
            CancellationToken ct = default)
        {
            await EnsureBucketAsync(bucketName, ct);

            var args = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithStreamData(data)
                .WithObjectSize(size)
                .WithContentType(contentType);

            await _client.PutObjectAsync(args, ct);
        }

        /// <inheritdoc/>
        public async Task<Stream?> GetAsync(
            string bucketName,
            string objectName,
            CancellationToken ct = default)
        {
            try
            {
                var ms = new MemoryStream();

                var args = new GetObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(objectName)
                    .WithCallbackStream(async (stream, innerCt) =>
                    {
                        await stream.CopyToAsync(ms, innerCt);
                    });

                await _client.GetObjectAsync(args, ct);

                ms.Position = 0;
                return ms;
            }
            catch (ObjectNotFoundException)
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(
            string bucketName,
            string objectName,
            CancellationToken ct = default)
        {
            try
            {
                var args = new RemoveObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(objectName);

                await _client.RemoveObjectAsync(args, ct);
            }
            catch (InvalidObjectNameException)
            {
            }
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsAsync(
            string bucketName,
            string objectName,
            CancellationToken ct = default)
        {
            try
            {
                var args = new StatObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(objectName);

                await _client.StatObjectAsync(args, ct);
                return true;
            }
            catch (ObjectNotFoundException)
            {
                return false;
            }
        }


        private async Task EnsureBucketAsync(string bucketName, CancellationToken ct)
        {
            var existsArgs = new BucketExistsArgs().WithBucket(bucketName);
            bool exists = await _client.BucketExistsAsync(existsArgs, ct);

            if (!exists)
            {
                var makeArgs = new MakeBucketArgs().WithBucket(bucketName);
                await _client.MakeBucketAsync(makeArgs, ct);
            }
        }
    }
}
