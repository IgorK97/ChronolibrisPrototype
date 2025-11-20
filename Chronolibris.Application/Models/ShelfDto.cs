using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.DTOs
{
    public class ShelfDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public int BooksCount { get; set; }
    }

}
