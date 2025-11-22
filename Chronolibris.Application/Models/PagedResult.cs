using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    /// <summary>
    /// Представляет собой результат запроса с пагинацией (постраничный результат).
    /// Используется для возврата определенного подмножества данных (страницы)
    /// вместе с метаданными о пагинации.
    /// </summary>
    /// <typeparam name="T">Тип элементов в коллекции, например, <c>BookListItem</c> или <c>AuthorDetails</c>.</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Коллекция элементов типа <typeparamref name="T"/>, которые относятся к текущей странице.
        /// Свойство доступно только для инициализации (<c>init</c>). Инициализируется пустым списком.
        /// </summary>
        public IEnumerable<T> Items { get; init; } = [];

        
        public int Limit { get; set; }
        public bool HasNext { get; set; }

        public long? LastId { get; set; }
    }
}
