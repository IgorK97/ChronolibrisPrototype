using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Domain.Entities;
using MediatR;

namespace Chronolibris.Application.Requests
{
    /// <summary>
    /// Запрос на получение всех закладок (<see cref="BookmarkDetails"/>) 
    /// для конкретной книги, созданных указанным пользователем.
    /// <para>
    /// Этот класс является <c>record</c> с позиционными параметрами, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="Bookid">Идентификатор книги, для которой запрашиваются закладки.</param>
    /// <param name="UserId">Идентификатор пользователя, чьи закладки запрашиваются.</param>
    /// <returns>Возвращает <see cref="System.Collections.Generic.List{T}"/> 
    /// объектов <see cref="BookmarkDetails"/>, содержащий все найденные закладки.</returns>
    public record GetBookmarksQuery(long Bookid, long UserId): IRequest<List<BookmarkDetails>>;

}
