using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Interfaces.Services
{
    /// <summary>
    /// Низкоуровневая абстракция над MinIO / S3-совместимым хранилищем.
    /// Работает с сырыми байтами и потоками, не знает ничего о доменной логике.
    /// Все методы принимают <paramref name="bucketName"/> явно, что позволяет
    /// использовать один сервис для нескольких бакетов.
    /// </summary>
    public interface IMinioService
    {
        /// <summary>Загружает объект из потока. Создаёт бакет, если он не существует.</summary>
        Task PutAsync(
            string bucketName,
            string objectName,
            Stream data,
            long size,
            string contentType,
            CancellationToken ct = default);

        /// <summary>
        /// Читает объект в MemoryStream и возвращает его.
        /// Возвращает <c>null</c>, если объект не найден.
        /// </summary>
        Task<Stream?> GetAsync(
            string bucketName,
            string objectName,
            CancellationToken ct = default);

        /// <summary>
        /// Удаляет объект. Не бросает исключение, если объект отсутствует.
        /// </summary>
        Task DeleteAsync(
            string bucketName,
            string objectName,
            CancellationToken ct = default);

        /// <summary>Возвращает <c>true</c>, если объект существует.</summary>
        Task<bool> ExistsAsync(
            string bucketName,
            string objectName,
            CancellationToken ct = default);
    }
}
