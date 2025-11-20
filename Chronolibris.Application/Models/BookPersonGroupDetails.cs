using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    public class BookPersonGroupDetails
    {
        public long Role { get; set; }
        public IEnumerable<PersonDetails> Persons { get; set; } = [];
    }
}
