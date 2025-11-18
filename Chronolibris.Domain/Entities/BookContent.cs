using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    //[Table("books_contents")]
    public class BookContent
    {
        public long ContentId { get; set; }
        public long BookId { get; set; }
        public Content Content { get; set; } = null!;
        public Book Book { get; set; } = null!;
    }
}
