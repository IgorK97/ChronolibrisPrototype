using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class Shelf
    {
        public required long Id { get; set; }
        public required long UserId { get; set; }
        public required long ShelfTypeId { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }
        public required DateTime CreatedAt { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ShelfType ShelfType { get; set; }
    }
}
