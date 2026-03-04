using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public record CreateCommentCommand(long BookId, long UserId, string Text, long? ParentCommentId) : IRequest<long>;

    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, long>
    {
        private readonly ICommentRepository _repository;
        public CreateCommentHandler(ICommentRepository repository) => _repository = repository;

        public async Task<long> Handle(CreateCommentCommand request, CancellationToken ct)
        {
            var comment = new Comment
            {
                BookId = request.BookId,
                UserId = request.UserId,
                Text = request.Text,
                ParentCommentId = request.ParentCommentId,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(comment, ct);
            // Предполагается, что UnitOfWork сохранит изменения
            return comment.Id;
        }
    }
}
