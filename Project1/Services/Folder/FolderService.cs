using Amirez.AmipBackend.Common.Constants;
using Amirez.AmipBackend.Controllers.Folder.Model;
using Amirez.AmipBackend.Services.Generic;
using Amirez.Common.Exceptions;
using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Repositories.Folder;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.Folder
{
    public class FolderService : IFolderService
    {
        protected readonly IFolderRepository _context;
        protected readonly IMapper _mapper;

        public FolderService(IFolderRepository dbContext, IMapper mapper)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task ValidateCreate(FolderCreateQuery entity)
        {
            if (await _context.Exists(dbEntity => dbEntity.Name == entity.Name))
            {
                throw new ResponseException(ErrorConstants.FolderNameExists);
            }
        }

        public async Task ValidateUpdate(Guid id, FolderUpdateQuery entity)
        {
            if (!await _context.Exists(id))
            {
                throw new ResponseException(ErrorConstants.FolderNotFound);
            }
            if (await _context.Exists(dbEntity => dbEntity.Name == entity.Name && dbEntity.Id != id))
            {
                throw new ResponseException(ErrorConstants.FolderNameExists);
            }
        }


        /// <summary>
        /// Find Entity by id.
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        public virtual async Task<FolderItemResponse> FindByParentId(Guid? parentId)
        {
            var dbItem = await _context.FindById(parentId);
            var mappedItem = _mapper.Map<FolderItemResponse>(dbItem);
            return mappedItem;
        }

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<FolderItemResponse> Create(FolderCreateQuery entity)
        {
            await ValidateCreate(entity);
            var mappedEntity = _mapper.Map<FolderDataModel>(entity);
            if (mappedEntity.FolderId == Guid.Empty)
            {
                mappedEntity.FolderId = null;
            }
            await _context.Create(mappedEntity);
            return _mapper.Map<FolderItemResponse>(mappedEntity);
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
        public virtual Task<IEnumerable<FolderListItemResponse>> FindAll()
        {
            var dblist = _context.FindAll();
            var mappedList = _mapper.ProjectTo<FolderListItemResponse>(dblist);
            return Task.FromResult(mappedList.AsEnumerable());
        }

        /// <summary>
        /// Find Entity by id.
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        public virtual async Task<FolderItemResponse> FindById(Guid? id)
        {
            if (id.HasValue)
            {
                var dbItem = await _context.FindById(id);
                var mappedItem = _mapper.Map<FolderItemResponse>(dbItem);
                return mappedItem;
            }
            else
            {
                var dbItem = await _context.FindRoot();
                var mappedItem = _mapper.Map<FolderItemResponse>(dbItem);
                return mappedItem;
            }

        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task Update(Guid id, FolderUpdateQuery entity)
        {
            await ValidateUpdate(id, entity);
            var mappedEntity = _mapper.Map<FolderDataModel>(entity);
            await _context.Update(id, mappedEntity);
        }

    }
}
