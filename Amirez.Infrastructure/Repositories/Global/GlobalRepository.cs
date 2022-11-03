using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Global
{
    public class GlobalRepository : IGlobalRepository
    {
        protected readonly DatabaseContext _context;

        public GlobalRepository(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Create Entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Create<TEntity>(TEntity entity) where TEntity : BaseDataModel
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Create Range of Entities.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task CreateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseDataModel
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task Delete<TEntity>(Guid id) where TEntity : BaseDataModel
        {
            var entity = await FindById<TEntity>(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Range Of Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteRange<TEntity>(IEnumerable<Guid> ids) where TEntity : BaseDataModel
        {
            var entities = await FindAll<TEntity>(item => ids != null && ids.Contains(item.Id)).ToListAsync();
            _context.Set<TEntity>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Save Changes Async.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Find List of entities depending on the filter and order and the included list
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> FindAll<TEntity>(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "") where TEntity : BaseDataModel
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).AsNoTracking();
            }
            else
            {
                return query.AsNoTracking();
            }
        }


        /// <summary>
        /// Checks if item is unique by a filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : BaseDataModel
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            return await query.AnyAsync(filter);
        }

        /// <summary>
        /// Find entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindById<TEntity>(Guid? id) where TEntity : BaseDataModel
        {
            return await _context.Set<TEntity>()
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Find entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindQueryableById<TEntity>(Guid? id) where TEntity : BaseDataModel
        {
            return await _context.Set<TEntity>()
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Update Entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update<TEntity>(Guid id, TEntity entity) where TEntity : BaseDataModel
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if an entity exists by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> Exists<TEntity>(Guid id) where TEntity : BaseDataModel
        {
            return await _context.Set<TEntity>().AnyAsync(entity => entity.Id == id);
        }

        /// <summary>
        /// Checks if an entity exists by the provided filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual async Task<bool> Exists<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : BaseDataModel
        {
            return await _context.Set<TEntity>().AnyAsync(filter);
        }
    }
}
