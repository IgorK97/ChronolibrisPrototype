using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using MediatR;

namespace Chronolibris.Application.Requests
{
    public class RateReviewRequest : IRequest<ReviewDTO?>
    {
        public long ReviewId { get; set; }
        public long UserId { get; set; }
        public short Score { get; set; }
    }
}
