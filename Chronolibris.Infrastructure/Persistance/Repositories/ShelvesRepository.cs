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
    public class ShelvesRepository : IShelvesRepository
    {
        private readonly ApplicationDbContext _context;

        public ShelvesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shelf?> GetByIdAsync(long shelfId)
        {
            return await _context.Shelves
                .Include(s => s.Books)
                .FirstOrDefaultAsync(s => s.Id == shelfId);
        }

        public async Task<IEnumerable<Shelf>> GetForUserAsync(long userId)
        {
            return await _context.Shelves
                .Where(s => s.UserId == userId)
                .Include(s => s.Books)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Book> Books, int TotalCount)>
            GetBooksForShelfAsync(long shelfId, int page, int pageSize)
        {
            var query = _context.Shelves
                .Where(s => s.Id == shelfId)
                .SelectMany(s => s.Books);

            var total = await query.CountAsync();

            var books = await query
                .OrderBy(b => b.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (books, total);
        }

        public async Task AddBookToShelf(long shelfId, long bookId)
        {
            var shelf = await _context.Shelves
                .Include(s => s.Books)
                .FirstAsync(s => s.Id == shelfId);

            if (!shelf.Books.Any(b => b.Id == bookId))
            {
                var book = await _context.Books.FindAsync(bookId);
                if (book != null)
                    shelf.Books.Add(book);
            }
        }

        public async Task RemoveBookFromShelf(long shelfId, long bookId)
        {
            var shelf = await _context.Shelves
                .Include(s => s.Books)
                .FirstAsync(s => s.Id == shelfId);

            var book = shelf.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
                shelf.Books.Remove(book);
        }
    }

}
