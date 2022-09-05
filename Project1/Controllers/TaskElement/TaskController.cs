
using Amirez.AmipBackend.Controllers.Generic;
using Amirez.AmipBackend.Controllers.TaskElement.Model;
using Amirez.AmipBackend.Services.TaskElement;
using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Data.Model.Enumerations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Controllers.TaskElement
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class TaskController : GenericController<
        TaskDataModel,
        TaskListItemResponse,
        TaskItemResponse,
        TaskCreateQuery,
        TaskUpdateQuery>
    {

        protected new readonly ITaskService _service;

        public TaskController(ITaskService service) : base(service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }


        [HttpGet("Goal/{projectId}")]
        public async Task<ActionResult<IEnumerable<TaskListItemResponse>>> FindByGoal(Guid projectId)
        {
            var entityList = await _service.FindByProject(projectId);
            return Ok(entityList);
        }


        [HttpPost("Filter")]
        public async Task<ActionResult<IEnumerable<TaskFilterListItemResponse>>> FilterTasks(TaskFilterQuery query)
        {
            var entityList = await _service.FilterTasks(query);
            return Ok(entityList);
        }


        [HttpGet("State/{id}/{taskStatus}")]
        public async Task<ActionResult> UpdateTaskState(Guid id, int taskStatus)
        {
            await _service.UpdateTaskState(id, taskStatus);
            return Ok();
        }


        [HttpPut("Description/{id}")]
        public async Task<ActionResult> UpdateTaskDescription(Guid id, TaskUpdateQuery query)
        {
            await _service.UpdateTaskDescription(id, query);
            return Ok();
        }


        [HttpGet("Repeat/{id}/{repeat}")]
        public async Task<ActionResult> UpdateTaskRepeat(Guid id, bool repeat)
        {
            await _service.UpdateTaskRepeat(id, repeat);
            return Ok();
        }


        [HttpGet("Priority/{id}/{priority}")]
        public async Task<ActionResult> UpdateTaskPriority(Guid id, int priority)
        {
            await _service.UpdateTaskPriority(id, priority);
            return Ok();
        }


        [HttpGet("Date/{id}")]
        public async Task<ActionResult> UpdateTaskDate(Guid id, DateTime? date)
        {
            await _service.UpdateTaskDate(id, date);
            return Ok();
        }


        [HttpGet("daily/{id}")]
        public virtual async Task<ActionResult<DailyTaskItemResponse>> FindDailyTaskById(Guid id)
        {
            var entity = await _service.FindDailyTaskById(id);
            return Ok(entity);
        }
    }
}
