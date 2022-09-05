using Amirez.AmipBackend.Common.Constants;
using Amirez.AmipBackend.Controllers.TaskElement.Model;
using Amirez.AmipBackend.Services.Generic;
using Amirez.Common.Exceptions;
using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Data.Model.Enumerations;
using Amirez.Infrastructure.Repositories.Project;
using Amirez.Infrastructure.Repositories.TaskElement;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.TaskElement
{
    public class TaskService : GenericService<
        TaskDataModel,
        TaskListItemResponse,
        TaskItemResponse,
        TaskCreateQuery,
        TaskUpdateQuery>, ITaskService
    {
        protected readonly IProjectRepository _goalRepository;
        protected new readonly ITaskRepository _context;

        public TaskService(ITaskRepository context, IMapper mapper, IProjectRepository goalRepository)
            : base(context, mapper)
        {
            _goalRepository = goalRepository ?? throw new ArgumentNullException(nameof(goalRepository));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override async Task ValidateCreate(TaskCreateQuery entity)
        {
            if (entity.ProjectId == Guid.Empty)
            {
                throw new ResponseException(ErrorConstants.TaskProjectIdRequired);
            }
            if (!await _goalRepository.Exists(entity.ProjectId))
            {
                throw new ResponseException(ErrorConstants.ProjectNotFound);
            }
            if (await _context.Exists(dbEntity => dbEntity.Name == entity.Name && dbEntity.ProjectId == entity.ProjectId))
            {
                throw new ResponseException(ErrorConstants.TaskNameExists);
            }
        }

        public override async Task ValidateUpdate(Guid id, TaskUpdateQuery entity)
        {
            if (!await _context.Exists(id))
            {
                throw new ResponseException(ErrorConstants.ProjectNotFound);
            }
            if (await _context.Exists(dbEntity => dbEntity.Name == entity.Name && dbEntity.Id != id))
            {
                throw new ResponseException(ErrorConstants.TaskNameExists);
            }
        }


        /// <summary>
        /// Find All Entities.
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<TaskListItemResponse>> FindAll()
        {
            await UpdateAllTaskHistory();
            var dblist = await _context.FindAllNewTasks();
            var mappedList = _mapper.ProjectTo<TaskListItemResponse>(dblist);
            return mappedList.AsEnumerable();
        }

        /// <summary>
        /// Find projects for a goal
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskListItemResponse>> FindByProject(Guid goalId)
        {
            var dbList = _context.FindAll(goal => goal.ProjectId == goalId);
            var mappedList = _mapper.ProjectTo<TaskListItemResponse>(dbList);
            return await mappedList.ToListAsync();
        }


        /// <summary>
        /// Find Entity by id.
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        public override async Task<TaskItemResponse> FindById(Guid? id)
        {
            var dbItem = await _context.FindById(id);
            var mappedItem = _mapper.Map<TaskItemResponse>(dbItem);
            return mappedItem;
        }

        public async Task UpdateAllTaskHistory()
        {
            var dblist = await _context.FindAllNewTasks();
            foreach (var task in dblist)
            {
                await UpdateTaskHistory(task.Id);
            }
        }


        /// <summary>
        /// Find projects for a goal
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public async Task UpdateTaskHistory(Guid? id)
        {
            if (!id.HasValue)
            {
                return;
            }
            var task = await _context.FindDailyTaskById(id.Value);
            if(task.Date.HasValue && task.Date.Value.Date < DateTime.Today.Date)
            {
                var newTask = new TaskDataModel
                {
                    Date = DateTime.Today.Date,
                    Name = task.Name,
                    Priority = task.Priority,
                    Everyday = task.Everyday,
                    Project = task.Project,
                    ProjectId = task.ProjectId,
                    State = task.State
                };
                await _context.Create(newTask);
                var history = new List<HistoryDataModel<TaskDataModel>>();
                foreach (var taskHistory in task.HistoryVersions)
                {
                    taskHistory.Parent = newTask;
                    history.Add(taskHistory);
                }
                history.Add(new HistoryDataModel<TaskDataModel>
                {
                    Date = task.Date.Value.Date,
                    Version = task,
                    VersionId = task.Id,
                    Parent = newTask,
                    Operation = OperationsEnum.Cretae
                });
                newTask.HistoryVersions = history;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Find projects for a goal
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskFilterListItemResponse>> FilterTasks(TaskFilterQuery query)
        {
            await UpdateAllTaskHistory();
            var taskQuery = await _context.FindAllNewTasks();
            taskQuery.Include(task => task.Project)
                .ThenInclude(project => project.Goal)
                .ThenInclude(goal => goal.Folder);
            taskQuery = taskQuery.Where((task) =>
                    (!query.Today.HasValue || task.Date.HasValue == query.Today.Value) ||
                    (!query.Everyday.HasValue || task.Everyday == query.Everyday));
            if (query.FolderId.HasValue)
            {
                taskQuery = taskQuery.Where(task => task.Project.Goal.FolderId == query.FolderId.Value);
            }
            if (query.GoalId.HasValue)
            {
                taskQuery = taskQuery.Where(task => task.Project.GoalId == query.GoalId.Value);
            }
            if (query.ProjectId.HasValue)
            {
                taskQuery = taskQuery.Where(task => task.ProjectId == query.ProjectId.Value);
            }
            if (query.Priority.HasValue)
            {
                taskQuery = taskQuery.Where(task => task.Priority == query.Priority.Value);
            }
            if (query.Today.HasValue)
            {
                if (query.Today.Value)
                {
                    taskQuery = taskQuery.Where(
                    task => (task.Date.Value.Day == DateTime.Today.Day
                    && task.Date.Value.Year == DateTime.Today.Year)
                    || task.Everyday == true);
                }
                else
                {
                    taskQuery = taskQuery.Where(
                    task => (task.Date.Value.Day != DateTime.Today.Day
                    || task.Date.Value.Year != DateTime.Today.Year)
                    && task.Everyday == false);
                }
            }
            if (query.Everyday.HasValue)
            {
                taskQuery = taskQuery.Where(task => task.Everyday == query.Everyday);
            }
            if (!string.IsNullOrEmpty(query.TaskName?.Trim()))
            {
                taskQuery = taskQuery.Where(
                    task => task.Name.ToLower().Contains(query.TaskName.Trim().ToLower()) 
                    || query.TaskName.ToLower().Contains(task.Name.Trim().ToLower()));
            }
            if (!string.IsNullOrEmpty(query.Description?.Trim()))
            {
                taskQuery = taskQuery.Where(task => task.Description.ToLower().Contains(query.Description.Trim().ToLower()) || query.Description.ToLower().Contains(task.Description.Trim().ToLower()));
            }
            if (query.StateList != null && query.StateList.Any())
            {
                taskQuery = taskQuery.Where(task => query.StateList.Contains(task.State));
            }
            var mappedList = _mapper.ProjectTo<TaskFilterListItemResponse>(taskQuery);
            return await mappedList.ToListAsync();
        }

        /// <summary>
        /// Update Task State
        /// </summary>
        /// <param name="id">task id</param>
        /// <param name="state">new state</param>
        /// <returns></returns>
        public async Task UpdateTaskState(Guid id, int state)
        {
            var task = await _context.FindById(id);
            task.State = (TaskStateEnum)state;
            await _context.Update(id, task);
        }

        /// <summary>
        /// Update Task State
        /// </summary>
        /// <param name="id">task id</param>
        /// <param name="state">new state</param>
        /// <returns></returns>
        public async Task UpdateTaskDescription(Guid id, TaskUpdateQuery query)
        {
            var task = await _context.FindById(id);
            task.Description = query.Description;
            await _context.Update(id, task);
        }

        /// <summary>
        /// Update Task Date
        /// </summary>
        /// <param name="id">task id</param>
        /// <param name="state">new state</param>
        /// <returns></returns>
        public async Task UpdateTaskDate(Guid id, DateTime? date)
        {
            var task = await _context.FindById(id);
            task.Date = date;
            await _context.Update(id, task);
        }

        /// <summary>
        /// Update Task Repetition
        /// </summary>
        /// <param name="id">task id</param>
        /// <param name="state">new state</param>
        /// <returns></returns>
        public async Task UpdateTaskRepeat(Guid id, bool repeat)
        {
            var task = await _context.FindById(id);
            task.Everyday = repeat;
            task.Date = DateTime.Today.Date;
            await _context.Update(id, task);
        }

        /// <summary>
        /// Update Task Priority
        /// </summary>
        /// <param name="id">task id</param>
        /// <param name="state">new state</param>
        /// <returns></returns>
        public async Task UpdateTaskPriority(Guid id, int priority)
        {
            var task = await _context.FindById(id);
            task.Priority = priority;
            await _context.Update(id, task);
        }

        /// <summary>
        /// Find Daily Task By Id
        /// </summary>
        /// <param name="id">task id</param>
        /// <returns></returns>
        public virtual async Task<DailyTaskItemResponse> FindDailyTaskById(Guid id)
        {
            var dbItem = await _context.FindDailyTaskById(id);
            var mappedItem = _mapper.Map<DailyTaskItemResponse>(dbItem);
            return mappedItem;
        }
    }
}
