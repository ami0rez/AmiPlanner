using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Repositories.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.TaskElement
{
    public interface ITaskRepository : IGenericRepository<TaskDataModel>
    {
        Task<TaskDataModel> FindDailyTaskById(Guid Id);
        Task<IQueryable<TaskDataModel>> FindAllNewTasks();
        Task<IQueryable<TaskDataModel>> FindAllNewTasks(params Guid[] taskIds);
    }
}
