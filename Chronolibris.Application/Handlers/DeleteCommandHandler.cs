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
    public record DeleteCommentCommand(long CommentId, long UserId) : IRequest;
    // --- ОБРАБОТЧИК УДАЛЕНИЯ ---
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand>
        {
            private readonly ICommentRepository _repository;
            private readonly IUnitOfWork _unitOfWork; // Предполагаем наличие UoW для SaveChanges

            public DeleteCommentHandler(ICommentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task Handle(DeleteCommentCommand request, CancellationToken ct)
            {
                var comment = await _repository.GetByIdAsync(request.CommentId, ct);

                // Проверяем существование и права доступа
                if (comment == null || comment.UserId != request.UserId) return;

                // Выполняем Soft Delete
                comment.DeletedAt = DateTime.UtcNow;
                _repository.Update(comment);
                await _unitOfWork.SaveChangesAsync(ct);
            }
        }


       
    
}
