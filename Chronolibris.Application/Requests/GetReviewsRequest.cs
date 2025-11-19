using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using MediatR;

namespace Chronolibris.Application.Requests
{
    public record GetReviewsRequest(long BookId):IRequest<List<ReviewDTO>>;
}
