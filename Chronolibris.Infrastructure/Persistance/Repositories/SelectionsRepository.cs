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
    public class SelectionsRepository : ISelectionsRepository
    {
        private readonly ApplicationDbContext _context;

        public SelectionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Selection?> GetByIdAsync(long id, CancellationToken ct)
        {
            return await _context.Selections
                .Include(s => s.Books)
                .FirstOrDefaultAsync(s => s.Id == id && s.IsActive, ct);
        }

        public async Task<IEnumerable<Selection>> GetActiveSelectionsAsync(CancellationToken ct)
        {
            return await _context.Selections
                .Where(s => s.IsActive)
                .ToListAsync(ct);
        }

        public async Task<(IEnumerable<Book> Books, int TotalCount)>
            GetBooksForSelection(long selectionId, int page, int pageSize, CancellationToken ct)
        {
            var query = _context.Selections
                .Where(s => s.Id == selectionId && s.IsActive)
                .SelectMany(s => s.Books);

            var total = await query.CountAsync(ct);

            var items = await query
                .OrderBy(b => b.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return (items, total);
        }
    }

}
