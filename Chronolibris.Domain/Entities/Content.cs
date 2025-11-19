using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class Content
    {
        public required long Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required long CountryId { get; set; }
        public required long LanguageId { get; set; }
        public int? Year { get; set; }
        public required bool IsOriginal { get; set; }
        public required bool IsTranslate { get; set; }
        public long? ParentContentId { get; set; }
        public required int Position { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public Country Country { get; set; } = null!;
        public Language Language { get; set; } = null!;
        public ICollection<Participation> Participations { get; set; } = new List<Participation>();
        public ICollection<Person> Persons { get; set;} = new List<Person>();
        public ICollection<Theme> Themes { get; set; }=new List<Theme>();
    }
}
