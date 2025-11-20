using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using MediatR;

namespace Chronolibris.Application.Requests
{
    public class RegisterUserRequest : IRequest<RegistrationResult>
    {
        public required string Name { get; init; }
        public required string FamilyName { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}
