using Amirez.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.SimpleGneric
{
    public abstract class SimpleGenericRepository<T> : ISimpleGenericRepository<T> where T : class
    {
        protected readonly DatabaseContext _context;

        public SimpleGenericRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> FindAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async virtual Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateRange(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task<IQueryable<T>> FindAll()
        {
            var query = _context.Set<T>().AsQueryable();
            return Task.FromResult(query);
        }
        public virtual async Task<T> FindAsync(Guid? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> FindParamAsync(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }
    }
}
