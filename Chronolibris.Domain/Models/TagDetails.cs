using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Models
{
    public class TagDetails
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required long TagTypeId { get; set; }
        public string? TagTypeName { get; set; }
    }
}
