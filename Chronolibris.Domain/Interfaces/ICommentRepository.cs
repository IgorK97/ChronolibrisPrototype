using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        // Получение корневых комментариев книги
        Task<List<Comment>> GetRootCommentsByBookIdAsync(long bookId, long? lastId, int limit, bool includeReplies, CancellationToken token);

        // Получение ответов на конкретный комментарий
        Task<List<Comment>> GetRepliesByParentIdAsync(long parentCommentId, long? lastId, int limit, CancellationToken token);
    }
}
