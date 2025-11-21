using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using MediatR;

namespace Chronolibris.Application.Queries
{
    /// <summary>
    /// Запрос на асинхронное получение полной метаинформации и подробных данных 
    /// (<see cref="BookDetails"/>) для указанной книги.
    /// <para>
    /// Этот класс является <c>record</c> с позиционным параметром, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="bookId">Идентификатор книги, метаданные которой необходимо получить.</param>
    /// <returns>Возвращает объект <see cref="BookDetails"/>, содержащий всю подробную информацию о книге.</returns>
    public record GetBookMetadataQuery(long bookId) : IRequest<BookDetails>;
}
