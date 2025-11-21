using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Interfaces
{
    public interface IReviewsRatingRepository : IGenericRepository<ReviewsRating>
    {
        Task<ReviewsRating?> GetReviewsRatingByUserIdAsync(long reviewId, long userId, CancellationToken token = default);
    }
}
