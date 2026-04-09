using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Models
{
    public class BookPersonGroupDetails
    {
        public required long Role { get; set; }
        public IEnumerable<PersonDetails> Persons { get; set; } = [];
    }
}
