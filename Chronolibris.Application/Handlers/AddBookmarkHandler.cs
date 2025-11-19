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
    public class AddBookmarkHandler : IRequestHandler<AddBookmarkCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBookmarkHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddBookmarkCommand request, CancellationToken cancellationToken)
        {
            //IT WONT WORK, 100%, AAAAAAAAAAAAAAAA
            //TODO: FIX THIS!!!

            var bookmark = new Bookmark
            {
                BookId = request.BookId,
                UserId = request.UserId,
                Mark = request.Mark,
                CreatedAt = DateTime.UtcNow,
                Id = 0,
            };

            await _unitOfWork.Bookmarks.AddAsync(bookmark);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }

}
