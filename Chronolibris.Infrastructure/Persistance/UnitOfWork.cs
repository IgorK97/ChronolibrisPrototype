using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Infrastructure.Data;
using Chronolibris.Infrastructure.Persistance.Repositories;

namespace Chronolibris.Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBookRepository Books { get; }
        public IBookmarkRepository Bookmarks { get; }
        public IReviewsRatingRepository ReviewsRatings { get; }
        public IReviewRepository Reviews { get; }
        public ISelectionsRepository Selections { get; }
        public IGenericRepository<Person> Persons { get; }
        public IGenericRepository<Content> Contents { get; }
        //public IGenericRepository<Review> Reviews { get; }
        public IGenericRepository<Publisher> Publishers { get; }
        //public IGenericRepository<ReviewsRating> ReviewsRatings { get; }


        public UnitOfWork(ApplicationDbContext context, IBookRepository bookRepository,
            IBookmarkRepository bookmarks,
            IGenericRepository<Person> personRepository, IGenericRepository<Content> contentRepository,
            IGenericRepository<Publisher> publisherRepository,
            IReviewsRatingRepository reviewsRatings,
            IReviewRepository reviewRepository,
            ISelectionsRepository selections)
        {
            _context = context;

            Books = bookRepository;
            Bookmarks = bookmarks;
            Persons = personRepository;
            Contents = contentRepository;
            Reviews = reviewRepository;
            Publishers = publisherRepository;
            ReviewsRatings = reviewsRatings;
            Selections = selections;
        }

        public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
