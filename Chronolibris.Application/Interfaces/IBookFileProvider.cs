using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Interfaces
{
    /// <summary>
    /// Определяет контракт для поставщиков, которые предоставляют доступ 
    /// к файловому контенту книг (например, чтение файлов eBook).
    /// </summary>
    public interface IBookFileProvider
    {
        /// <summary>
        /// Асинхронно получает содержимое файла книги в виде массива байтов.
        /// </summary>
        /// <param name="fileName">Имя или идентификатор файла книги, который необходимо получить.</param>
        /// <param name="cancellationToken">Токен отмены для прерывания операции.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// массив <c>byte[]</c>, содержащий весь контент файла книги.
        /// </returns>
        Task<byte[]> GetBookFileAsync(string fileName, CancellationToken cancellationToken);

        /// <summary>
        /// Асинхронно открывает поток для чтения содержимого файла книги.
        /// </summary>
        /// <param name="fileName">Имя или идентификатор файла книги, для которого необходимо открыть поток.</param>
        /// <param name="token">Токен отмены для прерывания операции.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// <see cref="System.IO.Stream"/>, который можно использовать для потоковой передачи данных.
        /// Возвращает <c>null</c>, если файл не найден.
        /// </returns>
        Task<Stream?> OpenReadStreamAsync(string fileName, CancellationToken token);


    }
}
