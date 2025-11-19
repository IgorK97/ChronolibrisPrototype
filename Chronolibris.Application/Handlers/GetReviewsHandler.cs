using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Requests;
using MediatR;
using Chronolibris.Domain.Interfaces;

namespace Chronolibris.Application.Handlers
{
    public class GetReviewsHandler : IRequestHandler<GetReviewsRequest, List<ReviewDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetReviewsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ReviewDTO>> Handle(GetReviewsRequest request, CancellationToken cancellationToken)
        {
            var reviews = await _unitOfWork.Reviews.GetAllAsync();
            return reviews.Where(r => r.BookId == request.BookId)
                .Select(r => new ReviewDTO
                {
                    Id = r.Id,
                    AverageRating = r.AverageRating,
                    Text = r.Description,

                    DislikesCount = r.DislikesCount,
                    LikesCount = r.LikesCount,
                    Name = r.Name,
                    Score = r.Score,
                    Title = r.Title,
                }).ToList(); // i should fix this code (1 - where, 2 - mapping)
        }
    }

}
