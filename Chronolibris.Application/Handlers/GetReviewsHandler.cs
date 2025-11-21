using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using MediatR;
using Chronolibris.Domain.Interfaces;

namespace Chronolibris.Application.Handlers
{
    public class GetReviewsHandler(IReviewRepository reviewRepository) : IRequestHandler<GetReviewsQuery, List<ReviewDetails>>
    {


        public async Task<List<ReviewDetails>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await reviewRepository.GetAllAsync(cancellationToken);
            return reviews.Where(r => r.BookId == request.BookId)
                .Select(r => new ReviewDetails
                {
                    Id = r.Id,
                    AverageRating = r.AverageRating,
                    Text = r.Description,

                    DislikesCount = r.DislikesCount,
                    LikesCount = r.LikesCount,
                    UserName = r.Name,
                    Score = r.Score,
                    Title = r.Title,
                    CreatedAt = r.CreatedAt,
                }).ToList(); // i should fix this code later (1 - where, 2 - mapping)
        }
    }

}
