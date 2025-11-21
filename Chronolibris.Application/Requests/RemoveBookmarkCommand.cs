using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Chronolibris.Application.Requests
{
    /// <summary>
    /// Команда для удаления закладки по ее уникальному идентификатору.
    /// <para>
    /// Этот класс является <c>record</c> с позиционным параметром, 
    /// что обеспечивает неизменяемость (immutability).
    /// </para>
    /// </summary>
    /// <param name="bookmarkId">Уникальный идентификатор закладки, которую необходимо удалить.</param>
    /// <returns>Возвращает <c>bool</c>, указывающий на успех выполнения операции (т.е., была ли закладка найдена и удалена).</returns>
    public record RemoveBookmarkCommand(long bookmarkId):IRequest<bool>;
}
