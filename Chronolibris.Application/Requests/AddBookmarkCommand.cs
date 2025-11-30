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
    /// Команда для добавления новой закладки к указанной книге от имени пользователя.
    /// <para>
    /// Этот класс является <c>record</c> с позиционными параметрами, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="BookId">Идентификатор книги, к которой добавляется закладка.</param>
    /// <param name="UserId">Идентификатор пользователя, создающего закладку.</param>
    /// <param name="Mark">Текст или позиция закладки (например, номер страницы или цитата).</param>
    /// <returns>Возвращает <c>bool</c>, указывающий на успех выполнения операции.</returns>
    public record AddBookmarkCommand(long bookId, long userId, string mark, string text) : IRequest<long>;
}
