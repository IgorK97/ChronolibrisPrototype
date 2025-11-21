using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Infrastructure.Data;
using Chronolibris.Infrastructure.Persistance.Repositories;

namespace Chronolibris.Infrastructure.Persistance
{
    /// <summary>
    /// Реализация шаблона Единица Работы (Unit of Work). 
    /// Инкапсулирует контекст базы данных (<see cref="ApplicationDbContext"/>) 
    /// и предоставляет централизованный доступ ко всем репозиториям приложения, 
    /// управляя сохранением изменений как единой транзакцией.
    /// Реализует интерфейс <see cref="IUnitOfWork"/> и <see cref="IDisposable"/>.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Получает репозиторий для управления сущностями книг.
        /// </summary>
        public IBookRepository Books { get; }

        /// <summary>
        /// Получает репозиторий для управления сущностями закладок.
        /// </summary>
        public IBookmarkRepository Bookmarks { get; }

        /// <summary>
        /// Получает репозиторий для управления оценками отзывов.
        /// </summary>
        public IReviewsRatingRepository ReviewsRatings { get; }

        /// <summary>
        /// Получает репозиторий для управления отзывами (рецензиями).
        /// </summary>
        public IReviewRepository Reviews { get; }

        /// <summary>
        /// Получает репозиторий для управления подборками книг.
        /// </summary>
        public ISelectionsRepository Selections { get; }

        /// <summary>
        /// Получает репозиторий для управления полками пользователя.
        /// </summary>
        public IShelvesRepository Shelves { get; }

        /// <summary>
        /// Получает обобщенный репозиторий для управления сущностями <see cref="Person"/> (например, авторы).
        /// </summary>
        public IGenericRepository<Person> Persons { get; }

        /// <summary>
        /// Получает обобщенный репозиторий для управления сущностями <see cref="Content"/> (файлы/содержимое).
        /// </summary>
        public IGenericRepository<Content> Contents { get; }
        //public IGenericRepository<Review> Reviews { get; }

        /// <summary>
        /// Получает обобщенный репозиторий для управления сущностями <see cref="Publisher"/>.
        /// </summary>
        public IGenericRepository<Publisher> Publishers { get; }
        //public IGenericRepository<ReviewsRating> ReviewsRatings { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UnitOfWork"/>, 
        /// внедряя контекст базы данных и все необходимые репозитории через конструктор.
        /// </summary>
        /// <param name="context">Контекст базы данных Entity Framework Core.</param>
        /// <param name="bookRepository">Репозиторий книг.</param>
        /// <param name="bookmarks">Репозиторий закладок.</param>
        /// <param name="personRepository">Обобщенный репозиторий персон.</param>
        /// <param name="contentRepository">Обобщенный репозиторий содержимого.</param>
        /// <param name="publisherRepository">Обобщенный репозиторий издателей.</param>
        /// <param name="reviewsRatings">Репозиторий оценок отзывов.</param>
        /// <param name="reviewRepository">Репозиторий отзывов.</param>
        /// <param name="selections">Репозиторий подборок.</param>
        /// <param name="shelves">Репозиторий полок.</param>
        public UnitOfWork(ApplicationDbContext context, IBookRepository bookRepository,
            IBookmarkRepository bookmarks,
            IGenericRepository<Person> personRepository, IGenericRepository<Content> contentRepository,
            IGenericRepository<Publisher> publisherRepository,
            IReviewsRatingRepository reviewsRatings,
            IReviewRepository reviewRepository,
            ISelectionsRepository selections, IShelvesRepository shelves)
        {
            _context = context;

            Books = bookRepository;
            Bookmarks = bookmarks;
            Persons = personRepository;
            Contents = contentRepository;
            Reviews = reviewRepository;
            Publishers = publisherRepository;
            ReviewsRatings = reviewsRatings;
            Selections = selections;
            Shelves = shelves;
        }

        /// <summary>
        /// Асинхронно сохраняет все изменения, накопленные в контексте отслеживания изменений 
        /// во всех репозиториях, в базе данных.
        /// </summary>
        /// <param name="ct">Токен отмены для прерывания операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию. Результат задачи — количество успешно сохраненных записей.</returns>
        public async Task<int> SaveChangesAsync(CancellationToken ct) =>
        await _context.SaveChangesAsync(ct);

        /// <summary>
        /// Освобождает ресурсы, связанные с контекстом базы данных.
        /// </summary>
        public void Dispose() => _context.Dispose();
    }
}
