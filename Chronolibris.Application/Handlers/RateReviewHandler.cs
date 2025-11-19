using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class RateReviewHandler : IRequestHandler<RateReviewRequest, ReviewDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RateReviewHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReviewDTO?> Handle(RateReviewRequest request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.Reviews.GetByIdAsync(request.ReviewId);
            if (review == null)
                return null;
            var rating = await _unitOfWork.ReviewsRatings.GetReviewsRatingByUserIdAsync(request.ReviewId,
                request.UserId, cancellationToken);

            if (request.Score == 0)
            {
                if (rating != null)
                    _unitOfWork.ReviewsRatings.Delete(rating);
            }
            else
            {
                if (rating == null)
                {
                    rating = new ReviewsRating
                    {
                        Id = 0,
                        ReviewId = request.ReviewId,
                        Score = request.Score,
                        UserId = request.UserId,
                    };
                    await _unitOfWork.ReviewsRatings.AddAsync(rating);
                }
                else
                {
                    rating.Score = request.Score;
                }
            }

            var likesCount = await _unitOfWork.Reviews.CountLikesForReview(request.ReviewId, cancellationToken);
            var dislikesCount = await _unitOfWork.Reviews.CountDislikesForReview(request.ReviewId, cancellationToken);
            long average = likesCount - dislikesCount;

            review.AverageRating = average;
            await _unitOfWork.SaveChangesAsync();

            //Maybe I need return not ReviewDTO, but Result {Succeeded, ReviewDTO} ??????????
            return new ReviewDTO
            {
                Id = review.Id,
                AverageRating = review.AverageRating,
                CreatedAt = review.CreatedAt,
                DislikesCount = review.DislikesCount,
                LikesCount = review.LikesCount,
                Score = review.Score,
                Text = review.Description,
                Title = review.Title,
                UserName = review.Name,
                UserVote = request.Score switch
                {
                    1 => true,
                    -1 => false,
                    _ => null
                }
            };

        }



    }
}
