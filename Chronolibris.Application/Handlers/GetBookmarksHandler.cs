using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetBookmarksHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBookmarksQuery, List<BookmarkDto>>
    {
        public async Task<List<BookmarkDto>> Handle(GetBookmarksQuery request, CancellationToken cancellationToken)
        {

            var bookmarks = await unitOfWork.Bookmarks
                                            .GetAllForBookAndUserAsync(request.Bookid, request.UserId);


            if (bookmarks == null)
            {
                return new List<BookmarkDto>();
            }

            return bookmarks.Select(b => new BookmarkDto
            {
                Id = b.Id,
                Mark = b.Mark,
                createdAt = b.CreatedAt
            }).ToList();
        }
    }
}
