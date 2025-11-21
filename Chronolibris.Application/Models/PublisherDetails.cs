using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    /// <summary>
    /// Представляет модель данных для издательства (Publisher). 
    /// Используется для передачи минимальной информации об организации, опубликовавшей книгу.
    /// </summary>
    public class PublisherDetails
    {
        /// <summary>
        /// Обязательный уникальный идентификатор издательства.
        /// </summary>
        public required long Id { get; set; }

        /// <summary>
        /// Обязательное полное название издательства.
        /// </summary>
        public required string Name { get; set; }
    }
}
