using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Models
{
    public class ReviewDetailsWithVote
    {
        public Review Review { get; set; }
        public bool? UserVote { get; set; } // true - лайк, false - дизлайк, null - не голосовал
    }
}
