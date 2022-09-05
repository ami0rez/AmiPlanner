using Amirez.AmipBackend.Controllers.Generic.Model;
using Amirez.Infrastructure.Data.Model;
using Amirez.Infrastructure.Repositories.Generic;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.Generic
{
    public abstract class GenericService<TEntity, TList, TItem, TCreate, TUpdate> :
        IGenericService<TList, TItem, TCreate, TUpdate>
        where TEntity : BaseDataModel
        where TCreate : CreateBaseQuery
        where TUpdate : UpdateBaseQuery
    {
        protected readonly IGenericRepository<TEntity> _context;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> dbContext, IMapper mapper)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Varifies if the entity is valid for creation.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract Task ValidateCreate(TCreate entity);

        /// <summary>
        /// Varifies if the entity is valid for updatinig
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract Task ValidateUpdate(Guid id, TUpdate entity);

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<TItem> Create(TCreate entity)
        {
            await ValidateCreate(entity);
            var mappedEntity = _mapper.Map<TEntity>(entity);
            await _context.Create(mappedEntity);
            return _mapper.Map<TItem>(mappedEntity);
        }

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task Delete(Guid id)
        {
            await _context.Delete(id);
        }

        /// <summary>
        /// Find All Entities.
        /// </summary>
        /// <returns></returns>
        public virtual Task<IEnumerable<TList>> FindAll()
        {
            var dblist = _context.FindAll();
            var mappedList = _mapper.ProjectTo<TList>(dblist);
            return Task.FromResult(mappedList.AsEnumerable());
        }

        /// <summary>
        /// Find Entity by id.
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        public virtual async Task<TItem> FindById(Guid? id)
        {
            var dbItem = await _context.FindById(id);
            var mappedItem = _mapper.Map<TItem>(dbItem);
            return mappedItem;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task Update(Guid id, TUpdate entity)
        {
            await ValidateUpdate(id, entity);
            var mappedEntity = _mapper.Map<TEntity>(entity);
            await _context.Update(id, mappedEntity);
        }
    }
}
