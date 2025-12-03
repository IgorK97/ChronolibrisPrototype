using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Domain.Models;
using Chronolibris.Domain.SystemConstants;
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

        //public async Task<List<BookListItem>>
        //   GetBooks(long userId, long? lastId, int limit, CancellationToken ct)
        //{
        //    var query = _context.ReadingProgresses.AsNoTracking()
        //        .Where(b => b.UserId == userId);

        //    if (lastId.HasValue)
        //    {
        //        query = query.Where(b => b.Id > lastId.Value);
        //    }

        //    query = query.Include(b => b.Book).ThenInclude(boo => boo.BookContents).ThenInclude(bc => bc.Content)
        //        .ThenInclude(c => c.Participations);

        //    var books = await query
        //        .OrderBy(b => b.Id)
        //        .Select(b => new BookListItem
        //        {
        //            Id = b.Id,
        //            Title = b.Book.Title,
        //            AverageRating = b.Book.AverageRating,
        //            CoverUri = b.Book.CoverPath,
        //            RatingsCount = b.Book.RatingsCount,
        //            IsFavorite = false,
        //            IsRead = false,
        //            Authors = b.Book.BookContents
        //                .SelectMany(bc => bc.Content.Participations
        //                    .Select(p => p.Person.Name))
        //                .ToList()
        //        })
        //        .Take(limit + 1)
        //        .ToListAsync(ct);

        //    return books;

        //}

        public async Task<List<BookListItem>> GetBooks(long userId, long? lastId, int limit, CancellationToken ct)
        {

            var query = _context.ReadingProgresses.AsNoTracking()
                .Where(rp => rp.UserId == userId);

            // (keyset pagination)
            if (lastId.HasValue)
            {
                query = query.Where(rp => rp.Id > lastId.Value);
            }

            var books = await query
                .OrderBy(rp => rp.Id)
                .Select(rp => new BookListItem
                {
                    Id = rp.Id,
                    Title = rp.Book.Title,
                    AverageRating = rp.Book.AverageRating,
                    CoverUri = rp.Book.CoverPath,
                    RatingsCount = rp.Book.RatingsCount,

                    IsFavorite = rp.Book.Shelves.Any(s =>
                        s.UserId == userId &&
                        s.ShelfType.Code == ShelfTypes.FAVORITES),


                    IsRead = rp.Book.Shelves.Any(s =>
                        s.UserId == userId &&
                        s.ShelfType.Code == ShelfTypes.READ),

                    Authors = rp.Book.BookContents
                        .SelectMany(bc => bc.Content.Participations
                            .Select(p => p.Person.Name))
                        .ToList()
                })
                .Take(limit + 1)
                .ToListAsync(ct);

            return books;
        }


    }
}
