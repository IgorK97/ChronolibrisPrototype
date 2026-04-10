using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Models
{
    public class PersonRoleFilter
    {
        public long RoleId { get; set; }

        public List<long> PersonIds { get; set; } = [];
        public List<string>? PersonNames { get; set; } = [];
    }
}
