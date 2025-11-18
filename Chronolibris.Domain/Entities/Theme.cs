using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class Theme
    {
        [Key]
        public required long Id { get; set; }
        public required string Name { get; set; }
        public long? ParentThemeId { get; set; }
        [ForeignKey("ParentThemeId")]
        public Theme? ParentTheme { get; set; }
        public ICollection<Content>? Contents { get; set; }
    }
}
