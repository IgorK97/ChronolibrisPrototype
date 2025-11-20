using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.DTOs
{
    public class BookDetailsDto
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        //public int Pages { get; set; }
        public int? Year { get; set; }
        public required string Description { get; set; }
        public string? ISBN { get; set; }
        public required decimal AverageRating { get; set; }
        public required long RatingsCount { get; set; }
        public required long ReviewsCount { get; set; }
        public string? CoverUri { get; set; }
        public required bool IsAvailable { get; set; }
        public PublisherDto? Publisher { get; set; }
        public string? Country { get; set; }
        public required string Language { get; set; }

        public IEnumerable<BookPersonGroupDto> Participants { get; set; } = [];
    }
}
