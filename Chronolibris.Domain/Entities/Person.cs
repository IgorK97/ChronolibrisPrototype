using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class Person
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImagePath { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Content> Contents { get; set; } = new List<Content>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
