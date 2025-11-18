using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class Review
    {
        public required long Id { get; set; }
        public required long UserId { get; set; }
        public required long BookId { get; set; }
        public required string Title { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required short Score { get; set; }
        public required decimal AverageRating { get; set; }
        public required long LikesCount { get; set; }
        public required long DislikesCount { get; set; }
        //public Book Book { get; set; } = null!;
        public ICollection<ReviewsRating> ReviewsRatings { get; set; } = new List<ReviewsRating>();
    }
}
