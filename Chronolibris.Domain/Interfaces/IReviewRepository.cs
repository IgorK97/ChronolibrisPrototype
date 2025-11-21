using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Interfaces
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<long> CountLikesForReview(long reviewId, CancellationToken token = default);
        Task<long> CountDislikesForReview(long reviewId, CancellationToken token = default);
        Task<long> GetAverageForReview(long reviewId, CancellationToken token = default);
    }
}
