using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Interfaces;
using Chronolibris.Application.Queries;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetBookFileHandler : IRequestHandler<GetBookFileQuery, FileResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookFileProvider _fileProvider;

        public GetBookFileHandler(IUnitOfWork unitOfWork, IBookFileProvider fileProvider)
        {
            _unitOfWork = unitOfWork;
            _fileProvider = fileProvider;
        }

        public async Task<FileResultDto?> Handle(GetBookFileQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.bookId);
            if (book == null || String.IsNullOrEmpty(book.FilePath))
            {
                return null;
            }
            //var fileBytes = await _fileProvider.GetBookFileAsync(book.FilePath, cancellationToken);
            var stream = await _fileProvider.OpenReadStreamAsync(book.FilePath, cancellationToken);
            if (stream == null)
                return null;

            return new FileResultDto
            {
                Stream = stream,
                ContentType = "application/epub+zip",
                FileName = book.Title
            };
            //return null;
        }
    }
}
