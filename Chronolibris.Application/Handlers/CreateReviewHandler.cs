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
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReviewHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                BookId = request.BookId,
                UserId = request.UserId,
                Title = request.Title ?? "",
                Description = request.Description ?? "",
                Score = request.Score,
                CreatedAt = DateTime.UtcNow,
                AverageRating = 0,
                DislikesCount = 0,
                Id = 0,
                LikesCount = 0,
                Name = request.UserName ?? "",
            };

            await _unitOfWork.Reviews.AddAsync(review, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return review.Id;
        }
    }
}
