using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Interfaces;
using Chronolibris.Application.Queries;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetBookFileHandler : IRequestHandler<GetBookFileQuery, FileResultDto>
    {
        private readonly IBookFileProvider _fileProvider;

        public GetBookFileHandler(IBookFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public async Task<FileResultDto> Handle(GetBookFileQuery request, CancellationToken cancellationToken)
        {
            var fileBytes = await _fileProvider.GetBookFileAsync("book.epub", cancellationToken);

            return new FileResultDto
            {
                FileBytes = fileBytes,
                ContentType = "application/epub+zip",
                FileName = "book.epub"
            };
        }
    }
}
