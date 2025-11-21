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
    /// Запрос на асинхронное получение списка всех отзывов (<see cref="ReviewDetails"/>) 
    /// для указанной книги.
    /// <para>
    /// Этот класс является <c>record</c> с позиционным параметром, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="BookId">Идентификатор книги, для которой запрашиваются отзывы.</param>
    /// <returns>Возвращает <see cref="System.Collections.Generic.List{T}"/> 
    /// объектов <see cref="ReviewDetails"/>, содержащий все отзывы на книгу.</returns>
    public record GetReviewsQuery(long BookId):IRequest<List<ReviewDetails>>;
}
