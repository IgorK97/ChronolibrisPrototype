using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string? ReviewText { get; set; }
        public required short Score { get; set; }
        public required DateTime CreatedAt { get; set; }
        public ICollection<ReviewsReaction> ReviewsRatings { get; set; } = new List<ReviewsReaction>();
    }
}
