using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Interfaces;
using Chronolibris.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Chronolibris.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;

        public IdentityService(UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        public async Task<RegistrationResultDTO> RegisterUserAsync(RegisterRequest request)
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

            return new RegistrationResultDTO
            {
                Success = result.Succeeded,
                Token = GenerateJwtToken(user),
                Errors = result.Succeeded ? null : result.Errors.Select(e => e.Description)
            }; //Or Exception???
        
        }

        public async Task<LoginResultDTO?> LoginUserByEmailAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return null; //Exception???
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded) return null;
            return new LoginResultDTO
            {
                Success = true,
                Token = GenerateJwtToken(user)
            };
        }

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
