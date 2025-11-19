using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;

namespace Chronolibris.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<RegistrationResultDTO> RegisterUserAsync(RegisterRequest request);
        Task<LoginResultDTO?> LoginUserByEmailAsync(LoginRequest request);
    }
}
