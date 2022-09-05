using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.TaskElement
{
    public class TaskRepository : GenericRepository<TaskDataModel>, ITaskRepository
    {
        public TaskRepository(DatabaseContext context)
            : base(context)
        {

        }
        public async Task<TaskDataModel> FindDailyTaskById(Guid Id)
        {
            return await _context.Tasks
                .Include(task => task.HistoryVersions)
                .ThenInclude(taskhistory => taskhistory.Version)
                .Include(task => task.Project)
                .ThenInclude(project => project.Goal)
                .ThenInclude(goal => goal.Folder)
                .ThenInclude(folder => folder.Goals)
                .ThenInclude(goal => goal.Projects)
                .ThenInclude(project => project.Tasks)
                .FirstOrDefaultAsync(task => task.Id == Id);
        }

        public async Task<IQueryable<TaskDataModel>> FindAllNewTasks()
        {
            var historyIds = await _context.TaskHistory.Select(hist => hist.VersionId).ToListAsync();
            return _context.Tasks
                .Where(task => !historyIds.Contains(task.Id));
        }

        public async Task<IQueryable<TaskDataModel>> FindAllNewTasks(params Guid[] taskIds)
        {
            var historyIds = await _context.TaskHistory
                .Where(task => taskIds == null || taskIds.Contains(task.VersionId))
                .Select(hist => hist.VersionId).ToListAsync();
            return _context.Tasks
                .Where(task => (taskIds == null || taskIds.Contains(task.Id)) && !historyIds.Contains(task.Id));
        }
    }
}
