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
    /// <summary>
    /// Репозиторий для управления сущностями полок (<see cref="Shelf"/>) и их содержимым.
    /// Реализует интерфейс <see cref="IShelvesRepository"/> и использует <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class ShelvesRepository : IShelvesRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ShelvesRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных приложения, используемый для доступа к данным.</param>
        public ShelvesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Асинхронно получает сущность полки по ее уникальному идентификатору, включая связанные книги.
        /// </summary>
        /// <param name="shelfId">Уникальный идентификатор полки.</param>
        /// <param name="ct">Токен отмены для прерывания запроса.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// сущность <see cref="Shelf"/> со связанными книгами или <c>null</c>, если полка не найдена.
        /// </returns>
        public async Task<Shelf?> GetByIdAsync(long shelfId, CancellationToken ct)
        {
            return await _context.Shelves
                .Include(s => s.Books)
                .FirstOrDefaultAsync(s => s.Id == shelfId, ct);
        }

        /// <summary>
        /// Асинхронно получает все полки, принадлежащие указанному пользователю, включая связанные книги.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="ct">Токен отмены для прерывания запроса.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// коллекция <see cref="System.Collections.Generic.IEnumerable{T}"/> сущностей <see cref="Shelf"/>.
        /// </returns>
        public async Task<IEnumerable<Shelf>> GetForUserAsync(long userId, CancellationToken ct)
        {
            return await _context.Shelves
                .Where(s => s.UserId == userId)
                .Include(s => s.Books)
                .ToListAsync(ct);
        }

        /// <summary>
        /// Асинхронно получает книги с указанной полки с поддержкой пагинации.
        /// </summary>
        /// <param name="shelfId">Идентификатор полки.</param>
        /// <param name="page">Номер запрашиваемой страницы (начиная с 1).</param>
        /// <param name="pageSize">Количество книг на странице.</param>
        /// <param name="ct">Токен отмены для прерывания запроса.</param>
        /// <returns>
        /// Кортеж, содержащий коллекцию сущностей <see cref="Book"/> для текущей страницы 
        /// и общее количество книг на полке (<c>TotalCount</c>).
        /// </returns>
        public async Task<(IEnumerable<Book> Books, int TotalCount)>
            GetBooksForShelfAsync(long shelfId, int page, int pageSize, CancellationToken ct)
        {
            var query = _context.Shelves
                .Where(s => s.Id == shelfId)
                .SelectMany(s => s.Books);

            var total = await query.CountAsync(ct);

            var books = await query
                .OrderBy(b => b.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return (books, total);
        }

        /// <summary>
        /// Асинхронно добавляет книгу на указанную полку. Если книга уже присутствует, операция пропускается.
        /// Изменения будут сохранены при вызове <c>IUnitOfWork.SaveChangesAsync</c>.
        /// </summary>
        /// <param name="shelfId">Идентификатор полки.</param>
        /// <param name="bookId">Идентификатор книги, которую нужно добавить.</param>
        /// <param name="ct">Токен отмены для прерывания операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public async Task AddBookToShelf(long shelfId, long bookId, CancellationToken ct)
        {
            var shelf = await _context.Shelves
                .Include(s => s.Books)
                .FirstAsync(s => s.Id == shelfId, ct);

            if (!shelf.Books.Any(b => b.Id == bookId))
            {
                var book = await _context.Books.FindAsync(bookId);
                if (book != null)
                    shelf.Books.Add(book);
            }
        }

        /// <summary>
        /// Асинхронно удаляет книгу с указанной полки.
        /// Изменения будут сохранены при вызове <c>IUnitOfWork.SaveChangesAsync</c>.
        /// </summary>
        /// <param name="shelfId">Идентификатор полки.</param>
        /// <param name="bookId">Идентификатор книги, которую нужно удалить с полки.</param>
        /// <param name="ct">Токен отмены для прерывания операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public async Task RemoveBookFromShelf(long shelfId, long bookId, CancellationToken ct)
        {
            var shelf = await _context.Shelves
                .Include(s => s.Books)
                .FirstAsync(s => s.Id == shelfId, ct);

            var book = shelf.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
                shelf.Books.Remove(book);
        }
    }

}
