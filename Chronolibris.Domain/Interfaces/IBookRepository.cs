using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Models;

namespace Chronolibris.Domain.Interfaces
{
    /// <summary>
    /// Определяет контракт для репозитория, управляющего сущностями <see cref="Book"/>.
    /// Наследует базовые операции CRUD от <see cref="IGenericRepository{T}"/>.
    /// </summary>
    public interface IBookRepository : IGenericRepository<Book>
    {
        /// <summary>
        /// Асинхронно получает сущность книги по ее идентификатору, включая все связанные 
        /// с ней данные (например, авторов, издателя, рецензии и т.д.).
        /// Используется для получения полного профиля книги.
        /// </summary>
        /// <param name="id">Уникальный идентификатор книги.</param>
        /// <param name="token">Токен отмены для прерывания операции. По умолчанию — <c>default</c>.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// сущность <see cref="Book"/> или <c>null</c>, если книга не найдена.
        /// </returns>
        Task<Book?> GetBookWithRelationsAsync(long id, CancellationToken token = default);
        Task<List<BookListItem>>
            GetSearchedBooks(string query, long? lastId, int limit, long userId, CancellationToken token = default);
    }
}
