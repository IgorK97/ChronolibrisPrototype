using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Queries;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetBookMetadataHandler : IRequestHandler<GetBookMetadataQuery, BookDetailsDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBookMetadataHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BookDetailsDto?> Handle(GetBookMetadataQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.bookId);
            if (book == null)
                return null;

            return new BookDetailsDto
            {
                
            }

            //var metadata = new BookMetadataDTO
            //{
            //    Title = "Example Book",
            //    Author = "John Doe",
            //    Pages = 200
            //};

            //return await Task.FromResult(metadata);
        }
    }
}
