using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    /// <summary>
    /// Представляет результат операции аутентификации (входа в систему).
    /// Используется сервисом идентификации (<see cref="Chronolibris.Application.Interfaces.IIdentityService"/>) 
    /// для возврата статуса входа, токена доступа и списка ошибок.
    /// </summary>
    public class LoginResult
    {
        /// <summary>
        /// Флаг, указывающий, была ли аутентификация успешной.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Токен доступа (например, JWT), который возвращается при успешном входе (<see cref="Success"/> = <c>true</c>).
        /// Если аутентификация не удалась, это свойство будет <c>null</c>.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Список сообщений об ошибках, возникших в процессе аутентификации 
        /// (например, "Неверный пароль" или "Пользователь не найден").
        /// Если вход успешен, это свойство будет <c>null</c> или пустым.
        /// </summary>
        public IEnumerable<string>? Errors { get; set; }
    }
}
