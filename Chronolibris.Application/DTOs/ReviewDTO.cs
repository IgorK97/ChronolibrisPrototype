using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.DTOs
{
    public class ReviewDTO
    {
        public required long Id { get; set; }
        //public long UserId { get; set; }
        //public long BookId { get; set; }
        public required string Title { get; set; }
        public required string UserName { get; set; }
        public required string Text { get; set; }
        public required short Score { get; set; }
        public required decimal AverageRating { get; set; }
        public required long LikesCount { get; set; }
        public required long DislikesCount { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
