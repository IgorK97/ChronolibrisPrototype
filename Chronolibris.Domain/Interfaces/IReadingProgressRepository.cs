using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Interfaces
{
    public interface IReadingProgressRepository : IGenericRepository<ReadingProgress>
    {
        Task<ReadingProgress?> GetForBookUser(long bookId, long userId, CancellationToken token = default);
    }
}
