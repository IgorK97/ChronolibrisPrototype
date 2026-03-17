using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Entities
{
    public class ReadingProgress
    {
        public long Id { get; set; }
        public decimal Percentage { get; set; }
        public int ParaIndex { get; set; }
        public DateTime ReadingDate { get; set; }
        public long UserId { get; set; }
        public long BookFileId { get; set; }
        public BookFile BookFile { get; set; }
    }
}
