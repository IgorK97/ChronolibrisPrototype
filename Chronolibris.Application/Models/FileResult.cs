using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    /// <summary>
    /// Представляет результат операции, связанной с файлом, 
    /// содержащий сам файловый поток и метаданные о файле.
    /// Этот класс используется для передачи файлов из сервисного слоя на уровень представления 
    /// (например, в контроллер для отправки клиенту).
    /// </summary>
    public class FileResult
    {
        //public byte[] FileBytes { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Обязательный поток данных (<see cref="System.IO.Stream"/>), содержащий содержимое файла.
        /// Использование потока предпочтительно для больших файлов, так как предотвращает 
        /// загрузку всего файла в память.
        /// </summary>
        public required Stream Stream { get; set; }

        /// <summary>
        /// MIME-тип содержимого файла (например, "application/pdf", "image/jpeg"). 
        /// По умолчанию — пустая строка.
        /// </summary>
        public string ContentType { get; set; } = string.Empty;

        /// <summary>
        /// Имя файла, которое должно использоваться при сохранении или отображении файла клиенту. 
        /// По умолчанию — пустая строка.
        /// </summary>
        public string FileName { get; set; } = string.Empty;
    }
}
