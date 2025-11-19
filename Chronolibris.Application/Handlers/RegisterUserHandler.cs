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
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegistrationResultDTO>
    {
        private readonly IIdentityService _identityService;

        public RegisterUserHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<RegistrationResultDTO> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _identityService.RegisterUserAsync(request.request);
            return result;
        }
    }
}
