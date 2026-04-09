using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Models
{
    public class PersonDetails
    {
        public required long Id { get; set; }
        public required string FullName { get; set; }
    }
}
