using Chronolibris.Application.Models;
using MediatR;

namespace ChronolibrisPrototype.Models
{
    public class RateReviewRequest
    {
        public long ReviewId { get; init; }
        public short Score { get; init; }
        
    }
}
