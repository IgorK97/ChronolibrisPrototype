using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    /// <summary>
    /// Представляет упрощенную модель данных книги, предназначенную для отображения 
    /// в списках, каталогах или результатах поиска.
    /// Содержит только минимально необходимую информацию для превью.
    /// </summary>
    public class BookListItem
    {
        /// <summary>
        /// Обязательный уникальный идентификатор книги.
        /// </summary>
        public required long Id { get; set; }

        /// <summary>
        /// Обязательное название книги.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// URI (Uniform Resource Identifier) или URL обложки книги. Может быть null.
        /// </summary>
        public string? CoverUri { get; set; }

        /// <summary>
        /// Обязательный средний рейтинг книги (например, по шкале от 1.0 до 5.0).
        /// </summary>
        public required decimal AverageRating { get; set; }

        /// <summary>
        /// Обязательное общее количество оценок, поставленных книге.
        /// </summary>
        public required long RatingsCount { get; set; }

        /// <summary>
        /// Обязательный флаг, указывающий, добавлена ли книга в избранное текущим пользователем.
        /// </summary>
        public required bool IsFavorite { get; set; }

        /// <summary>
        /// Список имен авторов книги. Инициализируется пустым списком строк, если не указано иное.
        /// </summary>
        public IEnumerable<string> Authors { get; set; } = [];
    }
}
