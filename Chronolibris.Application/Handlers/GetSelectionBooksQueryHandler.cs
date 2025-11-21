using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Interfaces;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    /// <summary>
    /// Обработчик запроса для получения постраничного списка книг, принадлежащих определенной подборке (Selection).
    /// Использует первичный конструктор для внедрения зависимости <see cref="ISelectionsRepository"/>.
    /// Реализует интерфейс <see cref="IRequestHandler{TRequest, TResponse}"/>
    /// для обработки <see cref="GetSelectionBooksQuery"/> и возврата <see cref="PagedResult{T}"/> из <see cref="BookListItem"/>.
    /// </summary>
    public class GetSelectionBooksQueryHandler(ISelectionsRepository selectionsRepository)
    : IRequestHandler<GetSelectionBooksQuery, PagedResult<BookListItem>>
    {
        // Примечание: Внедрение зависимости через первичный конструктор (Primary Constructor)
        // автоматически создает приватное поле только для чтения `selectionsRepository`.

        /// <summary>
        /// Обрабатывает запрос на получение книг для определенной подборки с поддержкой пагинации.
        /// </summary>
        /// <remarks>
        /// 1. Вызывает репозиторий для получения страницы книг и общего количества записей (<c>totalCount</c>).
        /// 2. Преобразует полученные сущности книг в <see cref="BookListItem"/> DTO.
        /// 3. Упаковывает DTO и данные пагинации в объект <see cref="PagedResult{T}"/>.
        /// </remarks>
        /// <param name="request">Запрос, содержащий идентификатор подборки (<c>SelectionId</c>), номер страницы (<c>Page</c>) и размер страницы (<c>PageSize</c>).</param>
        /// <param name="ct">Токен отмены для асинхронной операции.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию.
        /// Результат задачи — объект <see cref="PagedResult{T}"/>, содержащий список <see cref="BookListItem"/> 
        /// и информацию о пагинации.
        /// </returns>
        public async Task<PagedResult<BookListItem>> Handle(GetSelectionBooksQuery request, CancellationToken ct)
        {
            // Получение страницы книг и общего количества записей из репозитория
            var (books, totalCount) = await selectionsRepository
                .GetBooksForSelection(request.SelectionId, request.Page, request.PageSize, ct);

            // Создание и возврат объекта PagedResult, содержащего DTO и информацию о пагинации
            return new PagedResult<BookListItem>
            {
                // Маппинг сущностей книг на DTO BookListItem
                Items = books.Select(b => new BookListItem
                {
                    Id = b.Id,
                    Title = b.Title,
                    AverageRating = b.AverageRating,
                    //CoverUrl = _coverService.GetCoverUrl(b.CoverPath)
                    // Поле IsFavorite временно установлено в false, пока не будет реализована логика проверки избранного
                    //TODO!!!
                    IsFavorite = false,
                    RatingsCount = b.RatingsCount,
                    CoverUri = b.CoverPath
                }),

                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }

}
