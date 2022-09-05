using Amirez.AmiPlanner.Controllers.TaskExpolrer.Model;
using Amirez.AmiPlanner.Services.TaskExpolrer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Controllers.TaskExpolrer
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class TaskExplorerController : ControllerBase
    {
        protected readonly ITaskExplorerService _taskExpolrerService;
        public TaskExplorerController(ITaskExplorerService taskExpolrerService)
        {
            _taskExpolrerService = taskExpolrerService ?? throw new ArgumentNullException(nameof(taskExpolrerService));
        }


        [HttpGet("Options")]
        public virtual async Task<ActionResult<TaskFilterOptions>> GetOptions()
        {
            var options = await _taskExpolrerService.GetTaskFilterOptions();
            return Ok(options);
        }
    }
}
