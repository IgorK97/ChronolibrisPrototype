using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Chronolibris.Application.Requests
{
    public class CreateReviewRequest : IRequest<long>
    {
        public long BookId { get; init; }
        public long UserId { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public short Score { get; init; }
        public string? UserName { get; init; }
    }
}
