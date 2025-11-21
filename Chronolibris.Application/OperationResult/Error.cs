using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.OperationResult
{
    /// <summary>
    /// Определяет общие типы ошибок, которые могут возникнуть в приложении.
    /// Используется для категоризации причин сбоя операции.
    /// </summary>
    public enum ErrorReason
    {
        /// <summary>
        /// Отсутствие ошибки. Используется, когда операция прошла успешно. 
        /// Должно использоваться только в сочетании с <c>Error.None</c>.
        /// </summary>
        None,

        /// <summary>
        /// Указывает, что запрошенный ресурс (сущность) не был найден в системе.
        /// </summary>
        NotFound,

    }

    /// <summary>
    /// Представляет объект ошибки, инкапсулирующий код ошибки и ее текстовое описание.
    /// Используется для предоставления детальной информации в случае неуспешного выполнения операции.
    /// </summary>
    /// <param name="Code">Категория ошибки, определяемая <see cref="ErrorReason"/>.</param>
    /// <param name="Description">Подробное текстовое описание ошибки, понятное разработчику или конечному пользователю.</param>
    public sealed record Error(ErrorReason Code, string Description)
    {
        /// <summary>
        /// Статический экземпляр, представляющий отсутствие ошибки. 
        /// Должен использоваться для всех успешных операций.
        /// </summary>
        public static readonly Error None = new(ErrorReason.None, string.Empty);
    }
}
