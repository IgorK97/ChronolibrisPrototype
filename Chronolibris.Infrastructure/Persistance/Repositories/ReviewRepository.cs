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
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context) { }
        public async Task<long> CountLikesForReview(long reviewId, CancellationToken cancellationToken)
        {
            return await _context.ReviewsRatings.LongCountAsync(rr => rr.ReviewId == reviewId && rr.Score == 1);
        }
        public async Task<long> CountDislikesForReview(long reviewId, CancellationToken token)
        {
            return await _context.ReviewsRatings.LongCountAsync(rr => rr.ReviewId == reviewId && rr.Score == -1);
        }

        public async Task<long> GetAverageForReview(long reviewId, CancellationToken token)
        {
            return await _context.ReviewsRatings.Where(rr => rr.ReviewId == reviewId).SumAsync(rr => (long)rr.Score, token);
        }
    }
}
