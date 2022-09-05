using Amirez.AmipBackend.Common.Constants;
using Amirez.AmipBackend.Controllers.Goal.Model;
using Amirez.AmipBackend.Services.Generic;
using Amirez.Common.Exceptions;
using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Repositories.Folder;
using Amirez.Infrastructure.Repositories.Goal;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.Goal
{
    public class GoalService : GenericService<
        GoalDataModel,
        GoalListItemResponse,
        GoalItemResponse,
        GoalCreateQuery,
        GoalUpdateQuery
        >, IGoalService
    {
        protected readonly IFolderRepository _folderRepository;

        public GoalService(IGoalRepository context, IMapper mapper, IFolderRepository folderRepository)
            : base(context, mapper)
        {
            _folderRepository = folderRepository ?? throw new ArgumentNullException(nameof(folderRepository));
        }

        public override async Task ValidateCreate(GoalCreateQuery entity)
        {
            if (entity.FolderId == Guid.Empty)
            {
                throw new ResponseException(ErrorConstants.GoalFolderIdRequired);
            }
            if (!await _folderRepository.Exists(entity.FolderId))
            {
                throw new ResponseException(ErrorConstants.FolderNotFound);
            }
            if (await _context.Exists(dbEntity => dbEntity.Name == entity.Name && dbEntity.FolderId == entity.FolderId))
            {
                throw new ResponseException(ErrorConstants.GoalNameExists);
            }
        }

        public override async Task ValidateUpdate(Guid id, GoalUpdateQuery entity)
        {
            if (!await _context.Exists(id))
            {
                throw new ResponseException(ErrorConstants.GoalNotFound);
            }
            if (await _context.Exists(dbEntity => dbEntity.Name == entity.Name && dbEntity.Id != id))
            {
                throw new ResponseException(ErrorConstants.GoalNameExists);
            }
        }

        /// <summary>
        /// Find goals in a folder
        /// </summary>
        /// <param name="folderId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GoalListItemResponse>> FindByFolder(Guid folderId)
        {
            var dbList = _context.FindAll(goal => goal.FolderId == folderId);
            var mappedList = _mapper.ProjectTo<GoalListItemResponse>(dbList);
            return await mappedList.ToListAsync();
        }
    }
}
