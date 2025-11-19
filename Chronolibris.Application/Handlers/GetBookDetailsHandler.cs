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
    public class GetBookDetailsHandler : IRequestHandler<GetBookMetadataQuery, BookDetailsDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICdnService _cdnService;
        public GetBookDetailsHandler(IUnitOfWork unitOfWork, ICdnService cdnService)
        {
            _unitOfWork = unitOfWork;
            _cdnService = cdnService;
        }
        public async Task<BookDetailsDto?> Handle(GetBookMetadataQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetBookWithRelationsAsync(request.bookId);
            if (book == null)
                return null;

            var participantsGrouped = book.Participations
                .GroupBy(p => p.PersonRoleId)
                .Select(g => new BookPersonGroupDto
                {
                    Role = g.Key,
                    Persons = g.Select(p => new PersonDto
                    {
                        Id = p.PersonId,
                        FullName = p.Person.Name
                    }).ToList()
                }).ToList();

            var dto = new BookDetailsDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Year = book.Year,
                ISBN = book.ISBN,
                AverageRating = book.AverageRating,
                RatingsCount = book.RatingsCount,
                ReviewsCount = book.ReviewsCount,
                IsAvailable = book.IsAvailable,
                Publisher = book.Publisher != null ? new PublisherDto
                {
                    Id = book.Publisher.Id,
                    Name = book.Publisher.Name
                } : null,
                Country = book.Country.Name,
                Language = book.Language.Name,
                Participants = participantsGrouped,
                //CoverUri = _cdnService.GetCoverUrl(book.CoverPath),
                CoverUri = book.CoverPath,
            };

            return dto;

        }
    }
}
