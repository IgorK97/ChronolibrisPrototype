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
    public class GetBookDetailsHandler : IRequestHandler<GetBookMetadataQuery, BookDetails?>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookDetailsHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<BookDetails?> Handle(GetBookMetadataQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookWithRelationsAsync(request.bookId, cancellationToken);
            if (book == null)
                return null;

            var participantsGrouped = book.Participations
                .GroupBy(p => p.PersonRoleId)
                .Select(g => new BookPersonGroupDetails
                {
                    Role = g.Key,
                    Persons = g.Select(p => new PersonDetails
                    {
                        Id = p.PersonId,
                        FullName = p.Person.Name
                    }).ToList()
                }).ToList();

            var dto = new BookDetails
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
                Publisher = book.Publisher != null ? new PublisherDetails
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
