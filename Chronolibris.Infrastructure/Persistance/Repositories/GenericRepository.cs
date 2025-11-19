using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chronolibris.Infrastructure.Persistance.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity:class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _set;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(long id) =>
        await _set.FindAsync(id);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync() =>
            await _set.ToListAsync();

        public async Task AddAsync(TEntity entity) =>
            await _set.AddAsync(entity);

        public void Update(TEntity entity) =>
            _set.Update(entity);

        public void Delete(TEntity entity) =>
            _set.Remove(entity);
    }
}
