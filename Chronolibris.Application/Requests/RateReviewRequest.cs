using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using MediatR;

namespace Chronolibris.Application.Requests
{
    public class RateReviewRequest : IRequest<ReviewDetails?>
    {
        public long ReviewId { get; init; }
        public long UserId { get; init; }
        public short Score { get; init; }
    }
}
