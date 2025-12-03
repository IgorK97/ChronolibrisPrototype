using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Domain.Models;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    /// <summary>
    /// Обработчик запроса для получения постраничного списка книг, находящихся на определенной полке пользователя.
    /// Использует первичный конструктор для внедрения зависимости <see cref="ICommonShelvesRepository"/>.
    /// Реализует интерфейс <see cref="IRequestHandler{TRequest, TResponse}"/>
    /// для обработки <see cref="GetShelfBooksQuery"/> и возврата <see cref="PagedResult{T}"/> из <see cref="BookListItem"/>.
    /// </summary>
    public class GetShelfBooksHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetShelfBooksQuery, PagedResult<BookListItem>>
    {

        // Примечание: Внедрение зависимости через первичный конструктор (Primary Constructor)
        // автоматически создает приватное поле только для чтения `shelvesRepository`.

        /// <summary>
        /// Обрабатывает запрос на получение книг для указанной полки с поддержкой пагинации.
        /// </summary>
        /// <remarks>
        /// 1. Вызывает репозиторий для получения страницы книг и общего количества записей (<c>total</c>) для данной полки.
        /// 2. Преобразует полученные сущности книг в <see cref="BookListItem"/> DTO.
        /// 3. Упаковывает DTO и данные пагинации в объект <see cref="PagedResult{T}"/>.
        /// </remarks>
        /// <param name="request">Запрос, содержащий идентификатор полки (<c>ShelfId</c>), номер страницы (<c>Page</c>) и размер страницы (<c>PageSize</c>).</param>
        /// <param name="ct">Токен отмены для асинхронной операции.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию.
        /// Результат задачи — объект <see cref="PagedResult{T}"/>, содержащий список <see cref="BookListItem"/> 
        /// и информацию о пагинации.
        /// </returns>
        public async Task<PagedResult<BookListItem>> Handle(GetShelfBooksQuery request, CancellationToken ct)
        {

            long? lastId = request.lastId;


            var books = await unitOfWork.Shelves.GetBooksForShelfAsync(
                request.ShelfId, lastId, request.Limit, request.userId, ct);

            var hasNext = books.Count() > request.Limit;
            if (hasNext)
            {
                books.RemoveAt(books.Count() - 1);
            }



            return new PagedResult<BookListItem>
            {
                Items = books,
                Limit = request.Limit,
                HasNext = hasNext,
                LastId = books.LastOrDefault()?.Id
            };
        }
    }

}
