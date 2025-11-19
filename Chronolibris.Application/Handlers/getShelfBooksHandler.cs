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
    public class GetShelfBooksHandler
    : IRequestHandler<GetShelfBooksQuery, PagedResultDto<BookListItemDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetShelfBooksHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<PagedResultDto<BookListItemDto>> Handle(GetShelfBooksQuery request, CancellationToken ct)
        {
            var (books, total) = await _uow.Shelves.GetBooksForShelfAsync(
                request.ShelfId, request.Page, request.PageSize);

            return new PagedResultDto<BookListItemDto>
            {
                Items = books.Select(b => new BookListItemDto
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
