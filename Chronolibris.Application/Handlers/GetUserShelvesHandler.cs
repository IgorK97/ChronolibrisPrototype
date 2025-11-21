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
    public class GetUserShelvesHandler(IShelvesRepository shelvesRepository)
    : IRequestHandler<GetUserShelvesQuery, IEnumerable<ShelfDetails>>
    {


        public async Task<IEnumerable<ShelfDetails>> Handle(GetUserShelvesQuery request, CancellationToken ct)
        {
            var shelves = await shelvesRepository.GetForUserAsync(request.UserId, ct);

            return shelves.Select(s => new ShelfDetails
            {
                Id = s.Id,
                Name = s.Name,
                BooksCount = s.Books.Count
            });
        }
    }

}
