using Amirez.Infrastructure.Data.Model;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : BaseDataModel
    {
        IQueryable<TEntity> FindAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> FindById(Guid? id);

        Task Create(TEntity entity);

        Task<bool> Exists(Guid id);

        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);

        Task Update(Guid id, TEntity entity);

        Task Delete(Guid id);

        Task SaveChangesAsync();
    }
}
