using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        Task<TEntity?> GetByIdAsync(long id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
