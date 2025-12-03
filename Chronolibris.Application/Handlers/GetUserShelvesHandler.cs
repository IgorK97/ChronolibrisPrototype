using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    /// <summary>
    /// Обработчик запроса для получения списка полок (<see cref="ShelfDetails"/>), принадлежащих конкретному пользователю.
    /// Использует первичный конструктор для внедрения зависимости <see cref="ICommonShelvesRepository"/>.
    /// Реализует интерфейс <see cref="IRequestHandler{TRequest, TResponse}"/>
    /// для обработки <see cref="GetUserShelvesQuery"/> и возврата коллекции <see cref="ShelfDetails"/>.
    /// </summary>
    public class GetUserShelvesHandler(IShelfRepository shelvesRepository)
    : IRequestHandler<GetUserShelvesQuery, IEnumerable<ShelfDetails>>
    {

        // Примечание: Внедрение зависимости через первичный конструктор (Primary Constructor)
        // автоматически создает приватное поле только для чтения `shelvesRepository`.

        /// <summary>
        /// Обрабатывает запрос на получение всех полок для указанного пользователя.
        /// </summary>
        /// <remarks>
        /// 1. Вызывает репозиторий для получения всех сущностей полок, связанных с <c>UserId</c> из запроса.
        /// 2. Предполагается, что репозиторий <c>GetForUserAsync</c> либо загружает связанные книги (<c>Books</c>),
        ///    либо имеет оптимизацию для подсчета книг на уровне базы данных.
        /// 3. Преобразует сущности полок в <see cref="ShelfDetails"/> DTO.
        /// </remarks>
        /// <param name="request">Запрос, содержащий идентификатор пользователя (<c>UserId</c>).</param>
        /// <param name="ct">Токен отмены для асинхронной операции.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию.
        /// Результат задачи — коллекция <see cref="IEnumerable{T}"/> объектов <see cref="ShelfDetails"/>.
        /// </returns>
        public async Task<IEnumerable<ShelfDetails>> Handle(GetUserShelvesQuery request, CancellationToken ct)
        {
            var shelves = await shelvesRepository.GetForUserAsync(request.UserId, ct);

            return shelves.Select(s => new ShelfDetails
            {
                Id = s.Id,
                Name = s.Name,
                ShelfType = s.ShelfTypeId
                //BooksCount = s.Books.Count
            });
        }
    }

}
