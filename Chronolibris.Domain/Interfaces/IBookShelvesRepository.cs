using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Interfaces
{
    public interface IShelvesRepository
    {
        Task<Shelf?> GetByIdAsync(long shelfId);
        Task<IEnumerable<Shelf>> GetForUserAsync(long userId);
        Task<(IEnumerable<Book> Books, int TotalCount)>
            GetBooksForShelfAsync(long shelfId, int page, int pageSize);

        Task AddBookToShelf(long shelfId, long bookId);
        Task RemoveBookFromShelf(long shelfId, long bookId);
    }

}
