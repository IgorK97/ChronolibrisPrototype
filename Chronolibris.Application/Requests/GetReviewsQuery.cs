using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using MediatR;

namespace Chronolibris.Application.Requests
{
    public record GetReviewsQuery(long BookId, long? lastId, int limit, long? userId=null):IRequest<PagedResult<ReviewDetails>>;
}
