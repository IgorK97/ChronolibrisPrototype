using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    public class SelectionDetails
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        
    }
}
