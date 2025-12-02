using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    /// <summary>
    /// Представляет результат операции регистрации нового пользователя.
    /// Используется сервисом идентификации (<see cref="Chronolibris.Application.Interfaces.IIdentityService"/>) 
    /// для возврата статуса регистрации, токена доступа и списка ошибок.
    /// </summary>
    public class RegistrationResult
    {
        /// <summary>
        /// Флаг, указывающий, была ли регистрация учетной записи успешной.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Токен доступа (например, JWT), который может быть возвращен сразу после успешной регистрации 
        /// (<see cref="Success"/> = <c>true</c>) для автоматического входа пользователя.
        /// </summary>
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Список сообщений об ошибках, возникших в процессе регистрации 
        /// (например, "Пользователь с таким Email уже существует" или "Пароль слишком слабый").
        /// Если регистрация успешна, это свойство будет <c>null</c> или пустым.
        /// </summary>
        //public IEnumerable<string>? Errors { get; set; }
        public string? Message { get; set; }
    }
}
