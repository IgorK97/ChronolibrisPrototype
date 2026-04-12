using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Chronolibris.Application.Requests.Users
{
    public record ChangePasswordCommand(string CurrentPassword, string NewPassword, long UserId) : IRequest<Unit>;
}
