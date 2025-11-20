using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;

namespace Chronolibris.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<RegistrationResult> RegisterUserAsync(RegisterRequest request);
        Task<LoginResult> LoginUserByEmailAsync(string Email, string Password);
    }
}
