using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class ReviewsRating
    {
        public required long Id { get; set; }
        public required long ReviewId { get; set; }
        public required long UserId { get; set; }
        public required short Score { get; set; }
    }
}
