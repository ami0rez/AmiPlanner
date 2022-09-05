using Amirez.AmipBackend.Controllers.Generic;
using Amirez.AmipBackend.Controllers.Project.Model;
using Amirez.AmipBackend.Services.Project;
using Amirez.Infrastructure.Data.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmipBackend.Controllers.Project
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class ProjectController : GenericController<
        ProjectDataModel,
        ProjectListItemResponse,
        ProjectItemResponse,
        ProjectCreateQuery,
        ProjectUpdateQuery>
    {

        protected readonly IProjectService _service;

        public ProjectController(IProjectService service) : base(service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }


        [HttpGet("Goal/{goalId}")]
        public async Task<ActionResult<IEnumerable<ProjectListItemResponse>>> FindByGoal(Guid goalId)
        {
            var entityList = await _service.FindByGoal(goalId);
            return Ok(entityList);
        }
    }
}
