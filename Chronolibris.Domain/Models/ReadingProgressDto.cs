using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Models
{
    public record ReadingProgressDto(
        long BookFileId,
        decimal Percentage,
        int ParaIndex,
        DateTime ReadingDate);
}
