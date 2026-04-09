using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    public class BookmarkDetails
    {
        public long Id { get; set; }
        public int ParaIndex { get; set; }
        public string? Note { get; set; }
        public required long BookFileId { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
