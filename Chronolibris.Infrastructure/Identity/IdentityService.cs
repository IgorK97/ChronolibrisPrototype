using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Interfaces;
using Chronolibris.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Chronolibris.Infrastructure.Identity
{
    /// <summary>
    /// Сервис, предоставляющий функциональность для управления пользователями (регистрация, вход) 
    /// и генерации токенов аутентификации на основе ASP.NET Core Identity.
    /// Реализует интерфейс <see cref="IIdentityService"/>.
    /// </summary>
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IdentityService"/>.
        /// </summary>
        /// <param name="userManager">Менеджер пользователей ASP.NET Core Identity для управления сущностями <see cref="User"/>.</param>
        /// <param name="signInManager">Менеджер входа ASP.NET Core Identity для проверки учетных данных.</param>
        /// <param name="config">Конфигурация приложения, используемая для получения секретов JWT.</param>
        public IdentityService(UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        /// <summary>
        /// Асинхронно регистрирует нового пользователя в системе.
        /// </summary>
        /// <param name="request">Запрос на регистрацию, содержащий имя, фамилию, email и пароль.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию. Результат задачи — 
        /// объект <see cref="RegistrationResult"/>, содержащий статус успеха, 
        /// ошибки (если есть) и JWT-токен при успешной регистрации.
        /// </returns>
        public async Task<RegistrationResult> RegisterUserAsync(RegisterRequest request)
        {
            DateTime dt = DateTime.UtcNow;
            var user = new User
            {
                FamilyName = request.FamilyName,
                IsDeleted = false,
                LastEnteredAt = dt,
                Name = request.Name,
                RegisteredAt = dt,
                Email = request.Email,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            return new RegistrationResult
            {
                Success = result.Succeeded,
                Token = GenerateJwtToken(user),
                Errors = result.Succeeded ? null : result.Errors.Select(e => e.Description)
            }; //Or Exception???
        
        }

        /// <summary>
        /// Асинхронно выполняет вход пользователя по электронной почте и паролю.
        /// </summary>
        /// <param name="Email">Электронная почта пользователя.</param>
        /// <param name="Password">Пароль пользователя.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию. Результат задачи — 
        /// объект <see cref="LoginResult"/>, содержащий статус успеха и JWT-токен при успешном входе. 
        /// Возвращает успешный результат с пустым токеном или с ошибками в случае неудачи (зависит от логики обработки ошибок).
        /// </returns>
        public async Task<LoginResult> LoginUserByEmailAsync(string Email, string Password)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            //if (user == null) return null; //Exception???
            var result = await _signInManager.CheckPasswordSignInAsync(user, Password, false);

            //if (!result.Succeeded) return null;
            return new LoginResult
            {
                Success = true,
                Token = GenerateJwtToken(user)
            };
        }

        /// <summary>
        /// Создает подписанный JSON Web Token (JWT) для указанного пользователя.
        /// </summary>
        /// <param name="user">Сущность <see cref="User"/>, для которого создается токен.</param>
        /// <returns>Сгенерированная строка JWT-токена.</returns>
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!)
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
