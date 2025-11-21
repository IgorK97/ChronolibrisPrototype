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
        IBookmarkRepository Bookmarks { get; }
        IReviewsRatingRepository ReviewsRatings { get; }
        IReviewRepository Reviews { get; }
        ISelectionsRepository Selections { get; }
        IShelvesRepository Shelves { get; }

        IGenericRepository<Person> Persons { get; }
        IGenericRepository<Content> Contents { get; }

        IGenericRepository<Publisher> Publishers { get; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
