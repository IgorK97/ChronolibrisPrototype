using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using MediatR;

namespace Chronolibris.Application.Requests
{
    /// <summary>
    /// Запрос на асинхронное получение списка книг, принадлежащих указанной полке (<c>Shelf</c>), 
    /// с поддержкой пагинации.
    /// <para>
    /// Этот класс является <c>record</c> с позиционными параметрами, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="ShelfId">Идентификатор полки, книги которой необходимо получить.</param>
    /// <param name="Page">Номер запрашиваемой страницы (обычно начинается с 1).</param>
    /// <param name="PageSize">Максимальное количество элементов, которое должно находиться на одной странице.</param>
    /// <returns>Возвращает объект <see cref="PagedResult{T}"/>, содержащий коллекцию 
    /// <see cref="BookListItem"/> (облегченная модель книги) и метаданные пагинации.</returns>
    public record GetShelfBooksQuery(long ShelfId, int Page, int PageSize)
    : IRequest<PagedResult<BookListItem>>;

}
