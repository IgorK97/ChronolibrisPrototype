using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using MediatR;

namespace Chronolibris.Application.Requests.Users
{
    public record RegisterUserCommand(string UserName, string FirstName, string LastName, string Email, 
        string PhoneNumber, string Password) : IRequest<RegistrationResult>;
}
