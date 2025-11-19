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
        public IGenericRepository<Person> Persons { get; }
        public IGenericRepository<Content> Contents { get; }
        public IGenericRepository<Review> Reviews { get; }
        public IGenericRepository<Publisher> Publishers { get; }


        public UnitOfWork(ApplicationDbContext context, IBookRepository bookRepository,
            IGenericRepository<Person> personRepository, IGenericRepository<Content> contentRepository,
            IGenericRepository<Review> reviewRepository, IGenericRepository<Publisher> publisherRepository)
        {
            _context = context;

            Books = bookRepository;
            Persons = personRepository;
            Contents = contentRepository;
            Reviews = reviewRepository;
            Publishers = publisherRepository;

        }

        public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
