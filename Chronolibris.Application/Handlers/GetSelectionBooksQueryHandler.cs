using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Interfaces;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetSelectionBooksQueryHandler(ISelectionsRepository selectionsRepository)
    : IRequestHandler<GetSelectionBooksQuery, PagedResult<BookListItem>>
    {


        public async Task<PagedResult<BookListItem>> Handle(GetSelectionBooksQuery request, CancellationToken ct)
        {
            var (books, totalCount) = await selectionsRepository
                .GetBooksForSelection(request.SelectionId, request.Page, request.PageSize);

            return new PagedResult<BookListItem>
            {
                Items = books.Select(b => new BookListItem
                {
                    Id = b.Id,
                    Title = b.Title,
                    AverageRating = b.AverageRating,
                    //CoverUrl = _coverService.GetCoverUrl(b.CoverPath)
                    IsFavorite = false,
                    RatingsCount = b.RatingsCount,
                    CoverUri = b.CoverPath
                }),

                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }

}
