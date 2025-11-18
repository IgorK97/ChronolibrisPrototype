using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class Tag
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required int TagTypeId { get; set; }
        public required TagType TagType { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
