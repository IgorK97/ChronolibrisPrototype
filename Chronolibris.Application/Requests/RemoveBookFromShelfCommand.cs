using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Chronolibris.Application.Requests
{

    /// <summary>
    /// Команда для удаления указанной книги с указанной полки пользователя.
    /// <para>
    /// Этот класс является <c>record</c> с позиционными параметрами, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="ShelfId">Идентификатор полки, с которой удаляется книга.</param>
    /// <param name="BookId">Идентификатор книги, которую необходимо удалить с полки.</param>
    /// <returns>Возвращает <c>bool</c>, указывающий на успех выполнения операции.</returns>
    public record RemoveBookFromShelfCommand(long ShelfId, long BookId)
     : IRequest<bool>;

}
