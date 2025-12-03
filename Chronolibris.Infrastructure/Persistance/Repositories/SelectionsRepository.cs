using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Domain.Models;
using Chronolibris.Domain.SystemConstants;
using Chronolibris.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chronolibris.Infrastructure.Persistance.Repositories
{
    /// <summary>
    /// Репозиторий для управления сущностями подборок (<see cref="Selection"/>). 
    /// Реализует интерфейс <see cref="ISelectionsRepository"/>, предоставляя методы для 
    /// получения подборок и книг, входящих в них, с поддержкой пагинации.
    /// </summary>
    public class SelectionsRepository : ISelectionsRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="SelectionsRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных приложения, используемый для доступа к данным.</param>
        public SelectionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Асинхронно получает сущность подборки по ее идентификатору, включая книги, и фильтрует только активные подборки.
        /// </summary>
        /// <param name="id">Уникальный идентификатор подборки.</param>
        /// <param name="ct">Токен отмены для прерывания запроса.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// сущность <see cref="Selection"/> со связанными книгами или <c>null</c>, если подборка не найдена или не активна.
        /// </returns>
        public async Task<Selection?> GetByIdAsync(long id, CancellationToken ct)
        {
            return await _context.Selections
                .Include(s => s.Books)
                .FirstOrDefaultAsync(s => s.Id == id && s.IsActive, ct);
        }

        /// <summary>
        /// Асинхронно получает список всех активных подборок, которые должны отображаться пользователю.
        /// </summary>
        /// <param name="ct">Токен отмены для прерывания запроса.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// коллекция <see cref="System.Collections.Generic.IEnumerable{T}"/> активных сущностей <see cref="Selection"/>.
        /// </returns>
        public async Task<IEnumerable<Selection>> GetActiveSelectionsAsync(CancellationToken ct)
        {
            return await _context.Selections
                .Where(s => s.IsActive)
                .ToListAsync(ct);
        }

        /// <summary>
        /// Асинхронно получает книги, включенные в указанную активную подборку, с поддержкой пагинации.
        /// </summary>
        /// <param name="selectionId">Идентификатор подборки.</param>
        /// <param name="page">Номер запрашиваемой страницы (начиная с 1).</param>
        /// <param name="pageSize">Количество книг на странице.</param>
        /// <param name="ct">Токен отмены для прерывания запроса.</param>
        /// <returns>
        /// Кортеж, содержащий коллекцию сущностей <see cref="Book"/> для текущей страницы 
        /// и общее количество книг в подборке (<c>TotalCount</c>).
        /// </returns>
        public async Task<List<BookListItem>>
            GetBooksForSelection(long selectionId, long? lastId, int limit, long userId, CancellationToken ct)
        {
            //var query = _context.Selections
            //    .Where(s => s.Id == selectionId && s.IsActive)
            //    .SelectMany(s => s.Books);

            //var total = await query.CountAsync(ct);

            //var items = await query
            //    .OrderBy(b => b.Title)
            //    .Skip((page - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToListAsync(ct);

            //return (items, total);

            var query = _context.Books.AsNoTracking()
                .Where(b => b.Selections.Any(s => s.Id == selectionId && s.IsActive));

            if (lastId.HasValue)
            {
                query = query.Where(b => b.Id > lastId.Value);
            }

            //var books = await query
            //    .OrderBy(b => b.Id)
            //    .Select(b => new BookListItem
            //    {
            //        Id = b.Id,
            //        Title = b.Title,
            //        AverageRating = b.AverageRating,
            //        CoverUri = b.CoverPath,
            //        RatingsCount = b.RatingsCount,
            //        IsFavorite = false,
            //        //эффективный SQL (JOIN/Subselect)
            //        Authors = b.BookContents
            //            .SelectMany(bc => bc.Content.Participations
            //                .Select(p => p.Person.Name))
            //            .ToList()
            //    })
            //    .Take(limit + 1)
            //    .ToListAsync(ct);

            //return books;

            var books = await query
                .OrderBy(rp => rp.Id)
                .Select(b => new BookListItem
                {
                    Id = b.Id,
                    Title = b.Title,
                    AverageRating = b.AverageRating,
                    CoverUri = b.CoverPath,
                    RatingsCount = b.RatingsCount,
                    IsFavorite = b.Shelves.Any(s =>
                        s.UserId == userId &&
                        s.ShelfType.Code == ShelfTypes.FAVORITES),

                    IsRead = b.Shelves.Any(s =>
                        s.UserId == userId &&
                        s.ShelfType.Code == ShelfTypes.READ),

                    Authors = b.BookContents
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
