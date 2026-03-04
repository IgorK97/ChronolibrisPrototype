using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public record GetBookCommentsQuery(
        long BookId,
        long? LastId,
        int Limit,
        bool IncludeReplies
    ) : IRequest<List<CommentDto>>;
    public class GetBookCommentsHandler : IRequestHandler<GetBookCommentsQuery, List<CommentDto>>
    {
        private readonly ICommentRepository _repository;

        public GetBookCommentsHandler(ICommentRepository repository) => _repository = repository;

        public async Task<List<CommentDto>> Handle(GetBookCommentsQuery request, CancellationToken ct)
        {
            var comments = await _repository.GetRootCommentsByBookIdAsync(
                request.BookId, request.LastId, request.Limit, request.IncludeReplies, ct);

            return comments.Select(MapToDto).ToList();
        }

        private CommentDto MapToDto(Comment c) => new CommentDto(
            c.Id, c.Text, c.CreatedAt, c.UserId, c.ParentCommentId,
            c.Replies?.Where(r => r.DeletedAt == null).Select(MapToDto).ToList()
        );
    }
}
