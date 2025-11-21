using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Interfaces;
using Chronolibris.Application.Queries;
using Chronolibris.Application.Requests;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    /// <summary>
    /// Обработчик команды для регистрации нового пользователя в системе.
    /// Реализует интерфейс <see cref="IRequestHandler{TRequest, TResponse}"/>
    /// для обработки <see cref="RegisterUserCommand"/> и возврата <see cref="RegistrationResult"/>.
    /// </summary>
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegistrationResult>
    {
        /// <summary>
        /// Приватное поле только для чтения для доступа к сервису аутентификации и идентификации.
        /// </summary>
        private readonly IIdentityService _identityService;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RegisterUserHandler"/>.
        /// </summary>
        /// <param name="identityService">Сервис, отвечающий за логику регистрации и управления пользователями.</param>
        public RegisterUserHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        /// <summary>
        /// Обрабатывает команду регистрации нового пользователя.
        /// </summary>
        /// <remarks>
        /// Данный обработчик выполняет маппинг данных из <see cref="RegisterUserCommand"/> в объект <see cref="RegisterRequest"/>,
        /// который затем передается внешнему сервису <see cref="IIdentityService"/> для выполнения основной бизнес-логики 
        /// (валидация данных, хеширование пароля, создание записи пользователя и, возможно, генерация токена).
        /// </remarks>
        /// <param name="request">Объект команды, содержащий данные нового пользователя (Email, Имя, Фамилия, Пароль).</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию.
        /// Результат задачи — объект <see cref="RegistrationResult"/>, содержащий статус регистрации (успех/неудача) и, при необходимости, сообщения об ошибках.
        /// </returns>
        public async Task<RegistrationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.RegisterUserAsync(new RegisterRequest
            {
                Email = request.Email,
                FamilyName = request.FamilyName,
                Name = request.Name,
                Password = request.Password
            });
            return result;
        }
    }
}
