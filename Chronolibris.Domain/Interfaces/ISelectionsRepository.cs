using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Interfaces
{
    public interface ISelectionsRepository
    {
        Task<Selection?> GetByIdAsync(long id);
        Task<IEnumerable<Selection>> GetActiveSelectionsAsync();
        Task<(IEnumerable<Book> Books, int TotalCount)>
            GetBooksForSelection(long selectionId, int page, int pageSize);
    }

}
