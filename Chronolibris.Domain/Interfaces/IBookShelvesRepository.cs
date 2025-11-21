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
        Task<Shelf?> GetByIdAsync(long shelfId, CancellationToken token = default);
        Task<IEnumerable<Shelf>> GetForUserAsync(long userId, CancellationToken token = default);
        Task<(IEnumerable<Book> Books, int TotalCount)>
            GetBooksForShelfAsync(long shelfId, int page, int pageSize, CancellationToken token = default);

        Task AddBookToShelf(long shelfId, long bookId, CancellationToken token = default);
        Task RemoveBookFromShelf(long shelfId, long bookId, CancellationToken token = default);
    }

}
