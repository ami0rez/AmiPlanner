using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.SimpleGneric
{
    public interface ISimpleGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindAsync(Guid id);
        Task AddAsync(T entity);
        Task Remove(T entity);
        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
        Task<IQueryable<T>> FindAll();
        Task<T> FindAsync(Guid? id);
        Task<T> FindParamAsync(int? id);
        Task SaveChangesAsync();
        Task AddRangeAsync(IEnumerable<T> entities);
    }
}
