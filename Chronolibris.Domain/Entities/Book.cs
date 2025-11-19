using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class Book
    {
        public required long Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CountryId { get; set; }
        public required int LanguageId { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Year { get; set; }
        public string? ISBN { get; set; }
        public required bool IsFragment { get; set; }
        public required string FilePath { get; set; }
        public required string CoverPath { get; set; }
        public required bool IsAvailable { get; set; }
        public required decimal AverageRating { get; set; }
        public required long RatingsCount { get; set; }
        public required long ReviewsCount { get; set; }
        public long? ParentBookId { get; set; }
        public long? PublisherId { get; set; }
        public Publisher Publisher { get; set; } = null!;
        public long? SeriesId { get; set; }
        public Series? Series { get; set; }
        public Country Country { get; set; } = null!;
        public Language Language { get; set; } = null!;
        public ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Content> Contents { get; set; } = new List<Content>();
        public ICollection<Shelf> Shelves { get; set; } = [];
        public ICollection<Person> Persons { get; set; } = new List<Person>();
        public ICollection<Participation> Participations { get; set; } = new List<Participation>();
        public ICollection<Selection> Selections { get; set; } = new List<Selection>();
        
    }
}
