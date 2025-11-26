using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Infrastructure.Data;
using Chronolibris.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chronolibris.Infrastructure.DataAccess.Persistance.Repositories
{
    public class ReadingProgressRepository : GenericRepository<ReadingProgress>, IReadingProgressRepository
    {
        public ReadingProgressRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<ReadingProgress?> GetForBookUser(long bookId, long userId, CancellationToken token)
        {
            return await _context.ReadingProgresses.Where(rp => rp.UserId == userId && rp.BookId == bookId).FirstOrDefaultAsync(token);
        }
    }
}
