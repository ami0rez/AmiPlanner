using Amirez.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Global
{
    public interface IGlobalRepository
    {
        IQueryable<TEntity> FindAll<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") where TEntity : BaseDataModel;


        /// <summary>
        /// Checks if item is unique by a filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : BaseDataModel;

        Task<TEntity> FindById<TEntity>(Guid? id) where TEntity : BaseDataModel;

        Task Create<TEntity>(TEntity entity) where TEntity : BaseDataModel;



        /// <summary>
        /// Create Range of Entities.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseDataModel;

        Task<bool> Exists<TEntity>(Guid id) where TEntity : BaseDataModel;

        Task<bool> Exists<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : BaseDataModel;

        Task Update<TEntity>(Guid id, TEntity entity) where TEntity : BaseDataModel;

        Task Delete<TEntity>(Guid id) where TEntity : BaseDataModel;


        /// <summary>
        /// Delete Range Of Entities.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task DeleteRange<TEntity>(IEnumerable<Guid> ids) where TEntity : BaseDataModel;

        Task SaveChangesAsync();
    }
}
