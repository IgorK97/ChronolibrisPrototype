using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.DTOs
{
    public class BookListItemDto
    {
        public required long Id { get; set; }
        public required string Title { get; set; }
        public string? CoverPath { get; set; }
        public required decimal AverageRating { get; set; }
        public required long RatingsCount { get; set; }
        public required bool IsFavorite { get; set; }
        public IEnumerable<string> Authors { get; set; } = [];
    }
}
