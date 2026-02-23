using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class MediaType
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}
