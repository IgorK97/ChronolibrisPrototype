using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Interfaces;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetSelectionBooksQueryHandler
    : IRequestHandler<GetSelectionBooksQuery, PagedResultDto<BookListItemDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICdnService _cdnService;

        public GetSelectionBooksQueryHandler(IUnitOfWork uow, ICdnService cdnService)
        {
            _uow = uow;
            _cdnService = cdnService;
        }

        public async Task<PagedResultDto<BookListItemDto>> Handle(GetSelectionBooksQuery request, CancellationToken ct)
        {
            var (books, totalCount) = await _uow.Selections
                .GetBooksForSelection(request.SelectionId, request.Page, request.PageSize);

            return new PagedResultDto<BookListItemDto>
            {
                Items = books.Select(b => new BookListItemDto
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
