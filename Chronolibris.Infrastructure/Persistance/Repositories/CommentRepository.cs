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
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Comment>> GetRootCommentsByBookIdAsync(long bookId, long? lastId, int limit, bool includeReplies, CancellationToken token)
        {
            var query = _context.Comments
                .AsNoTracking()
                .Where(c => c.BookId == bookId && c.ParentCommentId == null && c.DeletedAt == null);

            if (lastId.HasValue)
                query = query.Where(c => c.Id < lastId.Value); // Листаем "вниз" по ID

            var resultQuery = query.OrderByDescending(c => c.Id).Take(limit);

            if (includeReplies)
            {
                // Загружаем первый уровень дочерних комментариев (только активные)
                return await resultQuery
                    .Include(c => c.Replies.Where(r => r.DeletedAt == null).OrderByDescending(r => r.Id).Take(5))
                    .ToListAsync(token);
            }

            return await resultQuery.ToListAsync(token);
        }

        public async Task<List<Comment>> GetRepliesByParentIdAsync(long parentCommentId, long? lastId, int limit, CancellationToken token)
        {
            var query = _context.Comments
                .AsNoTracking()
                .Where(c => c.ParentCommentId == parentCommentId && c.DeletedAt == null);

            if (lastId.HasValue)
                query = query.Where(c => c.Id < lastId.Value);

            return await query
                .OrderByDescending(c => c.Id)
                .Take(limit)
                .ToListAsync(token);
        }
    }
}
