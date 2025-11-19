using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.DTOs
{
    public class ReviewDTO
    {
        public long Id { get; set; }
        //public long UserId { get; set; }
        //public long BookId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Score { get; set; }
        public decimal AverageRating { get; set; }
        public long LikesCount { get; set; }
        public long DislikesCount { get; set; }
    }
}
