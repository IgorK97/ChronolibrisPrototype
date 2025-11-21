using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    /// <summary>
    /// Представляет упрощенную модель данных для физического лица, связанного с книгой 
    /// (например, автор, редактор, иллюстратор).
    /// </summary>
    public class PersonDetails
    {
        /// <summary>
        /// Обязательный уникальный идентификатор персоны.
        /// </summary>
        public required long Id { get; set; }

        /// <summary>
        /// Обязательное полное имя персоны (например, "Джон Смит").
        /// </summary>
        public required string FullName { get; set; }
    }
}
