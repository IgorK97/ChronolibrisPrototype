using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Interfaces;
using Chronolibris.Application.Queries;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginResult>
    {
        private readonly IIdentityService _identityService;

        public LoginUserHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<LoginResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.LoginUserByEmailAsync(request.Email, request.Password);
            return result;
        }
    }
}
