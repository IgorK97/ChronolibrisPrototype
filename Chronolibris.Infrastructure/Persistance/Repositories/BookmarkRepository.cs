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
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BookmarkRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных приложения, используемый для доступа к данным.</param>
        public BookmarkRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Асинхронно получает список всех закладок, относящихся к указанной книге и созданными указанным пользователем.
        /// </summary>
        /// <param name="bookId">Идентификатор книги, для которой ищутся закладки.</param>
        /// <param name="userId">Идентификатор пользователя, создавшего закладки.</param>
        /// <param name="token">Токен отмены для прерывания запроса.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// <see cref="System.Collections.Generic.List{T}"/> сущностей <see cref="Bookmark"/>.
        /// </returns>
        public async Task<List<Bookmark>> GetAllForBookAndUserAsync(long bookId, long userId, CancellationToken token)
        {
            return await _context.Bookmarks.Where(b => b.BookId == bookId && b.UserId == userId)
                .ToListAsync(token);
        }
    }
}
