using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetBookmarksHandler(IBookmarkRepository bookmarkRepository) : IRequestHandler<GetBookmarksQuery, List<BookmarkDetails>>
    {
        public async Task<List<BookmarkDetails>> Handle(GetBookmarksQuery request, CancellationToken cancellationToken)
        {

            var bookmarks = await bookmarkRepository
                                            .GetAllForBookAndUserAsync(request.Bookid, request.UserId);


            if (bookmarks == null)
            {
                return new List<BookmarkDetails>();
            }

            return bookmarks.Select(b => new BookmarkDetails
            {
                Id = b.Id,
                Mark = b.Mark,
                createdAt = b.CreatedAt
            }).ToList();
        }
    }
}
