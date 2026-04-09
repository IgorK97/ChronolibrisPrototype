using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; init; } = [];
        public int Limit { get; set; }
        public bool HasNext { get; set; }
        public long? LastId { get; set; }
    }
}
