using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class Bookmark
    {
        public required long Id { get; set; }
        public required long BookId { get; set; }
        public required long UserId { get; set; }
        public required string Mark { get; set; }
        public required DateTime CreatedAt { get; set; }
        public Book Book { get; set; } = null!;

    }
}
