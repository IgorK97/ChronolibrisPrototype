using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    /// <summary>
    /// Представляет модель данных для полки (коллекции) книг пользователя.
    /// Используется для отображения информации о полке в списках или навигации.
    /// </summary>
    public class ShelfDetails
    {
        /// <summary>
        /// Уникальный идентификатор полки.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Обязательное название полки, заданное пользователем (например, "Избранное", "Хочу прочитать").
        /// </summary>
        public required string Name { get; set; }
        public required long ShelfType { get; set; }

        /// <summary>
        /// Общее количество книг, содержащихся на этой полке.
        /// </summary>
        //public int BooksCount { get; set; }
    }

}
