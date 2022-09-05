using Amirez.AmiPlanner.Controllers.TaskExpolrer.Model;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.TaskExpolrer
{
    public interface ITaskExplorerService
    {
        Task<TaskFilterOptions> GetTaskFilterOptions();
    }
}