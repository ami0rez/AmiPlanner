using Amirez.AmipBackend.Controllers.TaskElement.Model;
using Amirez.AmipBackend.Services.Generic;
using Amirez.Infrastructure.Data.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.TaskElement
{
    public interface ITaskService : IGenericService<
        TaskListItemResponse,
        TaskItemResponse,
        TaskCreateQuery,
        TaskUpdateQuery>
    {
        Task<IEnumerable<TaskListItemResponse>> FindByProject(Guid goalId);
        Task<IEnumerable<TaskFilterListItemResponse>> FilterTasks(TaskFilterQuery query);
        Task UpdateTaskState(Guid id, int state);
        Task UpdateTaskDescription(Guid id, TaskUpdateQuery query);
        Task UpdateTaskDate(Guid id, DateTime? date);
        Task UpdateTaskRepeat(Guid id, bool repeat);
        Task UpdateTaskPriority(Guid id, int priority);
        Task<DailyTaskItemResponse> FindDailyTaskById(Guid id);
    }
}
