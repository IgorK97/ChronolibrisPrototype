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
    /// Запрос на асинхронное получение списка всех полок (<see cref="ShelfDetails"/>), 
    /// принадлежащих указанному пользователю.
    /// <para>
    /// Этот класс является <c>record</c> с позиционным параметром, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="UserId">Идентификатор пользователя, для которого запрашиваются полки.</param>
    /// <returns>Возвращает <see cref="System.Collections.Generic.IEnumerable{T}"/> 
    /// объектов <see cref="ShelfDetails"/>, содержащий все полки пользователя.</returns>
    public record GetUserShelvesQuery(long UserId)
    : IRequest<IEnumerable<ShelfDetails>>;

}
