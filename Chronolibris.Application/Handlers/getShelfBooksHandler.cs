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
    public class GetShelfBooksHandler(IShelvesRepository shelvesRepository)
    : IRequestHandler<GetShelfBooksQuery, PagedResult<BookListItem>>
    {


        public async Task<PagedResult<BookListItem>> Handle(GetShelfBooksQuery request, CancellationToken ct)
        {
            var (books, total) = await shelvesRepository.GetBooksForShelfAsync(
                request.ShelfId, request.Page, request.PageSize, ct);

            return new PagedResult<BookListItem>
            {
                Items = books.Select(b => new BookListItem
                {
                    Id = b.Id,
                    Title = b.Title,
                    AverageRating = b.AverageRating,
                    //CoverUrl = _coverUrl.GetCoverUrl(b.CoverPath)
                    CoverUri = b.CoverPath,
                    IsFavorite = false,
                    RatingsCount = b.RatingsCount,
                }),
                TotalCount = total,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }

}
