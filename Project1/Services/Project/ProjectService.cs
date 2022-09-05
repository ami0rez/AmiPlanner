using Amirez.AmipBackend.Common.Constants;
using Amirez.AmipBackend.Controllers.Project.Model;
using Amirez.AmipBackend.Services.Generic;
using Amirez.Common.Exceptions;
using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Repositories.Goal;
using Amirez.Infrastructure.Repositories.Project;
using Amirez.Infrastructure.Repositories.TaskElement;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.Project
{
    public class ProjectService : GenericService<
        ProjectDataModel,
        ProjectListItemResponse,
        ProjectItemResponse,
        ProjectCreateQuery,
        ProjectUpdateQuery>, IProjectService
    {
        protected readonly IGoalRepository _goalRepository;
        protected readonly ITaskRepository _taskRepository;
        protected new readonly IProjectRepository _context;


        public ProjectService(IProjectRepository context, ITaskRepository taskRepository, IMapper mapper, IGoalRepository goalRepository)
            : base(context, mapper)
        {
            _goalRepository = goalRepository ?? throw new ArgumentNullException(nameof(goalRepository));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        }

        public override async Task ValidateCreate(ProjectCreateQuery entity)
        {
            if (entity.GoalId == Guid.Empty)
            {
                throw new ResponseException(ErrorConstants.ProjectGoalIdRequired);
            }
            if (!await _goalRepository.Exists(entity.GoalId))
            {
                throw new ResponseException(ErrorConstants.GoalNotFound);
            }
            if (await _context.Exists(dbEntity => dbEntity.Name == entity.Name && dbEntity.GoalId == entity.GoalId))
            {
                throw new ResponseException(ErrorConstants.ProjectNameExists);
            }
        }

        public override async Task ValidateUpdate(Guid id, ProjectUpdateQuery entity)
        {
            if (!await _context.Exists(id))
            {
                throw new ResponseException(ErrorConstants.GoalNotFound);
            }
            if (await _context.Exists(dbEntity => dbEntity.Name == entity.Name && dbEntity.Id != id))
            {
                throw new ResponseException(ErrorConstants.ProjectNameExists);
            }
        }

        /// <summary>
        /// Find projects for a goal
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectListItemResponse>> FindByGoal(Guid goalId)
        {
            var dbList = _context.FindAll(goal => goal.GoalId == goalId);
            var mappedList = _mapper.ProjectTo<ProjectListItemResponse>(dbList);
            return await mappedList.ToListAsync();
        }

        /// <summary>
        /// Finds a project by its id, returns the project with all its principal tasks
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<ProjectItemResponse> FindById(Guid? id)
        {
            var project = await _context.FindById(id);
            var tasks = await _taskRepository.FindAllNewTasks(project.Tasks.Select(task => task.Id).ToArray());
            project.Tasks = await tasks.ToListAsync();
            var mappedItem = _mapper.Map<ProjectItemResponse>(project);
            return mappedItem;
        }
    }
}
