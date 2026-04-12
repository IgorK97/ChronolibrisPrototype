using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using MediatR;

namespace Chronolibris.Application.Requests.Users
{
    public record UpdateUserProfileCommand(string FirstName, string LastName, string? Email, long UserId, string? PhoneNumber, string UserName) : IRequest<UserProfileResponse>;
}
