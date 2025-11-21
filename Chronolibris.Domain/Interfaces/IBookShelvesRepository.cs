using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Interfaces
{
    /// <summary>
    /// Определяет контракт для репозитория, управляющего сущностями <see cref="Shelf"/>
    /// и операциями по управлению книгами на этих полках.
    /// </summary>
    public interface IShelvesRepository
    {
        /// <summary>
        /// Асинхронно получает сущность полки по ее уникальному идентификатору.
        /// </summary>
        /// <param name="shelfId">Уникальный идентификатор полки.</param>
        /// <param name="token">Токен отмены для прерывания операции. По умолчанию — <c>default</c>.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// сущность <see cref="Shelf"/> или <c>null</c>, если полка не найдена.
        /// </returns>
        Task<Shelf?> GetByIdAsync(long shelfId, CancellationToken token = default);

        /// <summary>
        /// Асинхронно получает все полки, принадлежащие указанному пользователю.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="token">Токен отмены для прерывания операции. По умолчанию — <c>default</c>.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// коллекция <see cref="System.Collections.Generic.IEnumerable{T}"/> сущностей <see cref="Shelf"/>.
        /// </returns>
        Task<IEnumerable<Shelf>> GetForUserAsync(long userId, CancellationToken token = default);

        /// <summary>
        /// Асинхронно получает книги с указанной полки с поддержкой пагинации.
        /// </summary>
        /// <param name="shelfId">Идентификатор полки.</param>
        /// <param name="page">Номер запрашиваемой страницы (начиная с 1).</param>
        /// <param name="pageSize">Количество книг на странице.</param>
        /// <param name="token">Токен отмены для прерывания операции. По умолчанию — <c>default</c>.</param>
        /// <returns>
        /// Кортеж, содержащий коллекцию сущностей <see cref="Book"/> для текущей страницы 
        /// и общее количество книг на полке (<c>TotalCount</c>).
        /// </returns>
        Task<(IEnumerable<Book> Books, int TotalCount)>
            GetBooksForShelfAsync(long shelfId, int page, int pageSize, CancellationToken token = default);

        /// <summary>
        /// Асинхронно добавляет связь между указанной книгой и указанной полкой.
        /// </summary>
        /// <param name="shelfId">Идентификатор полки.</param>
        /// <param name="bookId">Идентификатор книги, которую нужно добавить на полку.</param>
        /// <param name="token">Токен отмены для прерывания операции. По умолчанию — <c>default</c>.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        Task AddBookToShelf(long shelfId, long bookId, CancellationToken token = default);

        /// <summary>
        /// Асинхронно удаляет связь между указанной книгой и указанной полкой.
        /// </summary>
        /// <param name="shelfId">Идентификатор полки.</param>
        /// <param name="bookId">Идентификатор книги, которую нужно удалить с полки.</param>
        /// <param name="token">Токен отмены для прерывания операции. По умолчанию — <c>default</c>.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        Task RemoveBookFromShelf(long shelfId, long bookId, CancellationToken token = default);
    }

}
