using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Interfaces;
using Chronolibris.Application.Queries;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    /// <summary>
    /// Обработчик запроса для получения файла книги.
    /// Реализует интерфейс <see cref="IRequestHandler{TRequest, TResponse}"/>
    /// для обработки <see cref="GetBookFileQuery"/> и возврата <see cref="FileResult"/> DTO.
    /// </summary>
    public class GetBookFileHandler : IRequestHandler<GetBookFileQuery, FileResult?>
    {
        /// <summary>
        /// Приватное поле только для чтения для доступа к репозиторию книг (метаданным).
        /// </summary>
        private readonly IBookRepository _bookRepository;

        /// <summary>
        /// Приватное поле только для чтения для доступа к провайдеру файлов (хранилищу).
        /// </summary>
        private readonly IBookFileProvider _fileProvider;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GetBookFileHandler"/>.
        /// </summary>
        /// <param name="bookRepository">Интерфейс репозитория для доступа к данным книг.</param>
        /// <param name="fileProvider">Интерфейс провайдера, отвечающего за чтение файла из хранилища (например, S3, Azure Blob, локальный диск).</param>
        public GetBookFileHandler(IBookRepository bookRepository, IBookFileProvider fileProvider)
        {
            _bookRepository = bookRepository;
            _fileProvider = fileProvider;
        }

        /// <summary>
        /// Обрабатывает запрос на получение файла книги в виде потока.
        /// </summary>
        /// <remarks>
        /// 1. Извлекает метаданные книги для получения пути к файлу.
        /// 2. Если книга не найдена или путь к файлу пуст, возвращает <c>null</c>.
        /// 3. Использует провайдер файлов для открытия потока чтения.
        /// 4. Возвращает <see cref="FileResult"/> с потоком и метаданными файла для передачи клиенту.
        /// </remarks>
        /// <param name="request">Запрос, содержащий идентификатор книги (<c>bookId</c>).</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию. 
        /// Результат задачи — объект <see cref="FileResult"/>, содержащий поток и метаданные файла, 
        /// или <c>null</c>, если файл или книга не найдены.
        /// </returns>
        public async Task<FileResult?> Handle(GetBookFileQuery request, CancellationToken cancellationToken)
        {
            // Шаг 1: Получение метаданных книги
            var book = await _bookRepository.GetByIdAsync(request.bookId, cancellationToken);

            // Шаг 2: Проверка наличия книги и пути к файлу
            if (book == null || String.IsNullOrEmpty(book.FilePath))
            {
                return null;
            }
            //var fileBytes = await _fileProvider.GetBookFileAsync(book.FilePath, cancellationToken);
            // Шаг 3: Получение потока данных файла из хранилища
            var stream = await _fileProvider.OpenReadStreamAsync(book.FilePath, cancellationToken);
            if (stream == null)
                return null;

            // Шаг 4: Создание DTO с результатом файла
            return new FileResult
            {
                Stream = stream,
                ContentType = "application/epub+zip",
                FileName = book.Title
            };
            //return null;
        }
    }
}
