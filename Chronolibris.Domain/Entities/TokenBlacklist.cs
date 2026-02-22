using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class TokenBlacklist
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
    }
}
