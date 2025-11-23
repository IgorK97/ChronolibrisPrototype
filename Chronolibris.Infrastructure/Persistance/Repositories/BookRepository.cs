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
    /// Репозиторий для управления сущностями книг (<see cref="Book"/>). 
    /// Предоставляет специализированные методы доступа к данным, расширяя <see cref="GenericRepository{TEntity}"/>.
    /// Реализует интерфейс <see cref="IBookRepository"/>.
    /// </summary>
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BookRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных приложения, используемый для доступа к данным.</param>
        public BookRepository(ApplicationDbContext context) : base(context) { }

        /// <summary>
        /// Асинхронно получает полную сущность книги по ее идентификатору, 
        /// включая все связанные сущности (Relations) с помощью Eager Loading.
        /// </summary>
        /// <remarks>
        /// Этот метод использует множество вызовов <c>Include</c> для загрузки Publisher, Series, Country, 
        /// Language, BookContents, Participations и Persons, предотвращая проблемы N+1.
        /// </remarks>
        /// <param name="id">Уникальный идентификатор книги.</param>
        /// <param name="token">Токен отмены для прерывания запроса.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// сущность <see cref="Book"/> со всеми загруженными связями или <c>null</c>, если книга не найдена.
        /// </returns>
        public async Task<Book?> GetBookWithRelationsAsync(long id, CancellationToken token)
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Series)
                .Include(b => b.Country)
                .Include(b => b.Language)
                .Include(b => b.BookContents).ThenInclude(bc => bc.Content).ThenInclude(c => c.Participations).ThenInclude(p => p.Person)
                
                //.Include(b => b.Reviews)
                .Include(b => b.Participations)
                .Include(b => b.Persons)
                .FirstOrDefaultAsync(b => b.Id == id, token);
        }
    }
}
