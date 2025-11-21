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
    /// Запрос на асинхронное получение файлового содержимого (потока данных) указанной книги.
    /// <para>
    /// Этот класс является <c>record</c> с позиционным параметром, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="bookId">Идентификатор книги, файл которой необходимо получить.</param>
    /// <returns>Возвращает <see cref="FileResult"/>, содержащий поток данных файла и метаданные, 
    /// или <c>null</c>, если книга или файл не найден.</returns>
    public record GetBookFileQuery(long bookId) : IRequest<FileResult?>;
}
