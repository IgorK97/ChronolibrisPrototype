using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chronolibris.Infrastructure.Persistance.Repositories
{
    public class BookmarkRepository : GenericRepository<Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Bookmark>?> GetAllForBookAndUserAsync(long bookId, long userId)
        {
            return await _context.Bookmarks.Where(b => b.BookId == bookId && b.UserId == userId)
                .ToListAsync();
        }
    }
}
