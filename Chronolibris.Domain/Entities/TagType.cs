using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class TagType
    {
        [Key]
        public required long Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
