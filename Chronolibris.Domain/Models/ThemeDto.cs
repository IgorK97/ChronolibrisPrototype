using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Models
{
    public class ThemeDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long? ParentThemeId { get; set; }
        public string? ParentThemeName { get; set; }
        public int SubThemesCount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
