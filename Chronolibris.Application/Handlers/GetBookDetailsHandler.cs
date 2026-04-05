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
using Chronolibris.Domain.Models;

namespace Chronolibris.Application.Handlers
{
    /// <summary>
    /// Обработчик запроса для получения детальной информации о книге.
    /// Реализует интерфейс <see cref="IRequestHandler{TRequest, TResponse}"/>
    /// для обработки <see cref="GetBookMetadataQuery"/> и возврата <see cref="BookDetails"/> DTO.
    /// </summary>
    public class GetBookDetailsHandler : IRequestHandler<GetBookMetadataQuery, BookDetails?>
    {
        /// <summary>
        /// Приватное поле только для чтения для доступа к репозиторию книг.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GetBookDetailsHandler"/>.
        /// </summary>
        /// <param name="bookRepository">Интерфейс репозитория для доступа к данным книг.</param>
        public GetBookDetailsHandler(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        /// <summary>
        /// Обрабатывает запрос на получение метаданных и деталей книги.
        /// </summary>
        /// <remarks>
        /// 1. Извлекает книгу и связанные сущности (участники, издатель, страна, язык) из базы данных.
        /// 2. Если книга не найдена, возвращает <c>null</c>.
        /// 3. Группирует участников (авторов, редакторов и т.д.) по их роли.
        /// 4. Преобразует сущность <c>Book</c> и связанные данные в объект <see cref="BookDetails"/> DTO.
        /// </remarks>
        /// <param name="request">Запрос, содержащий идентификатор книги (<c>bookId</c>).</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию. 
        /// Результат задачи — объект <see cref="BookDetails"/>, содержащий детали книги, 
        /// или <c>null</c>, если книга не найдена.
        /// </returns>
        public async Task<BookDetails?> Handle(GetBookMetadataQuery request, CancellationToken cancellationToken)
        {
            // Получение книги с необходимыми связанными сущностями из репозитория
            return await unitOfWork.Books.GetBookWithRelationsAsync(request.bookId, request.userId, request.mode, cancellationToken);
        }
    }
}
