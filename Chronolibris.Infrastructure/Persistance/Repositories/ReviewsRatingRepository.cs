using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chronolibris.Infrastructure.Persistance.Repositories
{
    public class ReviewsRatingRepository : GenericRepository<ReviewsRating>, IReviewsRatingRepository
    {
        public ReviewsRatingRepository(ApplicationDbContext context) : base(context) { }
        public async Task<ReviewsRating?> GetReviewsRatingByUserIdAsync(long reviewId, long userId, CancellationToken token)
        {
            return await _context.ReviewsRatings.FirstOrDefaultAsync(rr => rr.UserId == userId && rr.ReviewId==reviewId, token);
        }
    }
}
