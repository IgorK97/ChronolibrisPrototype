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
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Book?> GetBookWithRelationsAsync(long id)
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Series)
                .Include(b => b.Country)
                .Include(b => b.Language)
                .Include(b => b.Contents)
                //.Include(b => b.Reviews)
                .Include(b => b.Participations)
                .Include(b => b.Persons)

                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
