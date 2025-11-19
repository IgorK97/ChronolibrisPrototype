using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.DTOs
{
    public class BookPersonGroupDto
    {
        public string Role { get; set; } = null!;
        public IEnumerable<PersonDto> Persons { get; set; } = [];
    }
}
