using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Interfaces;
using Chronolibris.Application.Queries;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginResultDTO?>
    {
        private readonly IIdentityService _identityService;

        public LoginUserHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<LoginResultDTO?> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _identityService.LoginUserByEmailAsync(request.request);
            return result;
        }
    }
}
