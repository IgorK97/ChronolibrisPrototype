using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Chronolibris.Application.Requests.Reviews
{
    public record DeleteReviewCommand(long ReviewId, long UserId) : IRequest<Unit>;
}
