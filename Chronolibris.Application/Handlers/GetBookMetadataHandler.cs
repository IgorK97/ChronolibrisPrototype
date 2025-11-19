using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Queries;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetBookMetadataHandler : IRequestHandler<GetBookMetadataQuery, BookMetadataDTO>
    {
        public Task<BookMetadataDTO> Handle(GetBookMetadataQuery request, CancellationToken cancellationToken)
        {
            // Example: fetch from database or repository
            var metadata = new BookMetadataDTO
            {
                Title = "Example Book",
                Author = "John Doe",
                Pages = 200
            };

            return Task.FromResult(metadata);
        }
    }
}
