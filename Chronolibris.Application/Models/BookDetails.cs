using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    /// <summary>
    /// Представляет подробную информацию о конкретной книге, используемую в приложении 
    /// для отображения полного профиля книги (например, на странице "Детали книги").
    /// </summary>
    public class BookDetails
    {
        /// <summary>
        /// Уникальный идентификатор книги.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Обязательное название книги.
        /// </summary>
        public required string Title { get; set; }
        //public int Pages { get; set; }

        /// <summary>
        /// Год издания книги. Может быть null, если информация недоступна.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Обязательное подробное описание или аннотация книги.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Международный стандартный книжный номер (ISBN). Может быть null.
        /// </summary>
        public string? ISBN { get; set; }

        /// <summary>
        /// Обязательный средний рейтинг книги (например, по шкале от 1.0 до 5.0).
        /// </summary>
        public required decimal AverageRating { get; set; }

        /// <summary>
        /// Обязательное общее количество оценок, поставленных книге.
        /// </summary>
        public required long RatingsCount { get; set; }

        /// <summary>
        /// Обязательное общее количество написанных отзывов (рецензий) на книгу.
        /// </summary>
        public required long ReviewsCount { get; set; }

        // <summary>
        /// URI (Uniform Resource Identifier) или URL обложки книги. Может быть null.
        /// </summary>
        public string? CoverUri { get; set; }

        /// <summary>
        /// Обязательный флаг, указывающий, доступна ли книга для использования/просмотра.
        /// </summary>
        public required bool IsAvailable { get; set; }

        /// <summary>
        /// Детали издателя книги. Может быть null, если издатель неизвестен.
        /// </summary>
        public PublisherDetails? Publisher { get; set; }

        /// <summary>
        /// Страна публикации книги. Может быть null.
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Обязательный язык, на котором написана книга (например, "English", "Russian").
        /// </summary>
        public required string Language { get; set; }

        /// <summary>
        /// Список участников, связанных с книгой (например, авторы, редакторы, иллюстраторы).
        /// Инициализируется пустым списком, если не указано иное.
        /// </summary>
        public IEnumerable<BookPersonGroupDetails> Participants { get; set; } = [];
    }
}
