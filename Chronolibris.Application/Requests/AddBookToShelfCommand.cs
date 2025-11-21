using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Chronolibris.Application.Requests
{
    /// <summary>
    /// Команда для добавления указанной книги на указанную полку пользователя.
    /// <para>
    /// Этот класс является <c>record</c> с позиционными параметрами, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="ShelfId">Идентификатор полки, на которую добавляется книга.</param>
    /// <param name="BookId">Идентификатор книги, которую необходимо добавить.</param>
    /// <returns>Возвращает <c>bool</c>, указывающий на успех выполнения операции.</returns>
    public record AddBookToShelfCommand(long ShelfId, long BookId)
    : IRequest<bool>;

}
