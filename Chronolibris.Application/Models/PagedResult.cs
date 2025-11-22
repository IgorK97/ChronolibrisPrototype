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

        /// <summary>
        /// Общее количество всех элементов, доступных в базе данных, вне зависимости от страницы.
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        //public int TotalCount { get; init; }

        /// <summary>
        /// Номер текущей страницы, которую возвращает данный результат (начиная с 1).
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        //public int Page { get; init; }

        /// <summary>
        /// Максимальное количество элементов, которое должно находиться на одной странице.
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        //public int PageSize { get; init; }

        //public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        //public bool HasNextPage => Page*PageSize < TotalCount;

        //public bool HasPreviousPage => Page > 1;

        //public PagedResult(IEnumerable<T> items, int totalCount, int page, int pageSize)
        //{
        //    Items = items;
        //    TotalCount = totalCount;
        //    Page = page;
        //    PageSize = pageSize;
        //}

        //public long? Nextid { get; set; }
        //public bool HasNextPage => Nextid is not null;
        public int Limit { get; set; }
        public bool HasNext { get; set; }

        public long? LastId { get; set; }
    }
}
