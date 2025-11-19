using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book?> GetBookWithRelationsAsync(long id);
    }
}
