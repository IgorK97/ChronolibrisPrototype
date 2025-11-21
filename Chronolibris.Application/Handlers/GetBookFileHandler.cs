using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Interfaces;
using Chronolibris.Application.Queries;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetBookFileHandler : IRequestHandler<GetBookFileQuery, FileResult?>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookFileProvider _fileProvider;

        public GetBookFileHandler(IBookRepository bookRepository, IBookFileProvider fileProvider)
        {
            _bookRepository = bookRepository;
            _fileProvider = fileProvider;
        }

        public async Task<FileResult?> Handle(GetBookFileQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.bookId, cancellationToken);
            if (book == null || String.IsNullOrEmpty(book.FilePath))
            {
                return null;
            }
            //var fileBytes = await _fileProvider.GetBookFileAsync(book.FilePath, cancellationToken);
            var stream = await _fileProvider.OpenReadStreamAsync(book.FilePath, cancellationToken);
            if (stream == null)
                return null;

            return new FileResult
            {
                Stream = stream,
                ContentType = "application/epub+zip",
                FileName = book.Title
            };
            //return null;
        }
    }
}
