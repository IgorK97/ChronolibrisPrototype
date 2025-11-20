using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.DTOs
{
    public class BookmarkRequest
    {
        public required long BookId { get; set; }
        public required long UserId { get; set; }
        public required string Mark { get; set; }
    }
}
