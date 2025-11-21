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
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegistrationResult>
    {
        private readonly IIdentityService _identityService;

        public RegisterUserHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

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
