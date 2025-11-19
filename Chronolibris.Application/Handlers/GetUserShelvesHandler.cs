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
    public class GetUserShelvesHandler
    : IRequestHandler<GetUserShelvesQuery, IEnumerable<ShelfDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetUserShelvesHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ShelfDto>> Handle(GetUserShelvesQuery request, CancellationToken ct)
        {
            var shelves = await _uow.Shelves.GetForUserAsync(request.UserId);

            return shelves.Select(s => new ShelfDto
            {
                Id = s.Id,
                Name = s.Name,
                BooksCount = s.Books.Count
            });
        }
    }

}
