using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using MediatR;

namespace Chronolibris.Application.Models
{
    public class RegisterRequest
    {
        public required string UserName { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required string PhoneNumber { get; init; }
        public string? Role { get; init; }
    }
}
