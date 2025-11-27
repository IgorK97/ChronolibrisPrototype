using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Domain.Models;
using MediatR;

namespace Chronolibris.Application.Requests
{
    /// <summary>
    /// Запрос на асинхронное получение списка книг, принадлежащих указанной подборке (<c>Selection</c>), 
    /// с поддержкой пагинации.
    /// <para>
    /// Этот класс является <c>record</c> с позиционными параметрами, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="SelectionId">Идентификатор подборки, книги которой необходимо получить.</param>
    /// <param name="Page">Номер запрашиваемой страницы (обычно начинается с 1).</param>
    /// <param name="PageSize">Максимальное количество элементов, которое должно находиться на одной странице.</param>
    /// <returns>Возвращает объект <see cref="PagedResult{T}"/>, содержащий коллекцию 
    /// <see cref="BookListItem"/> и метаданные пагинации.</returns>
    public record GetSelectionBooksQuery(long SelectionId, long? LastId, int Limit, long userId)
    : IRequest<PagedResult<BookListItem>>;

}
