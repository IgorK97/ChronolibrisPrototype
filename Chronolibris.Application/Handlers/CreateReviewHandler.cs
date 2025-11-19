using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewRequest, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReviewHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateReviewRequest request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                BookId = request.data.BookId,
                UserId = request.data.UserId,
                Title = request.data.Title,
                Description = request.data.Description,
                Score = request.data.Score,
                CreatedAt = DateTime.UtcNow,
                AverageRating = 0,
                DislikesCount = 0,
                Id = 0,
                LikesCount = 0,
                Name = request.data.Name,
            };

            await _unitOfWork.Reviews.AddAsync(review);
            await _unitOfWork.SaveChangesAsync();

            return review.Id;
        }
    }
}
