using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        IGenericRepository<Person> Persons { get; }
        IGenericRepository<Content> Contents { get; }
        IGenericRepository<Review> Reviews { get; }
        IGenericRepository<Publisher> Publishers { get; }

        Task<int> SaveChangesAsync();
    }
}
