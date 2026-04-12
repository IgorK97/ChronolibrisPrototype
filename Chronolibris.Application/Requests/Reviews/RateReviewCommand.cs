using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using MediatR;

namespace Chronolibris.Application.Requests.Reviews
{
    public record RateReviewCommand(long ReviewId, long UserId, short Score) : IRequest<ReviewDetails?>;
}
