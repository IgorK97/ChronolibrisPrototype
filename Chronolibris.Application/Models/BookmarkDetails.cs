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
        public string Mark { get; set; }
        public DateTime createdAt { get; set; }
    }
}
