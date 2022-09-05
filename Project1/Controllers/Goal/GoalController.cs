using Amirez.AmipBackend.Controllers.Generic;
using Amirez.AmipBackend.Controllers.Goal.Model;
using Amirez.AmipBackend.Services.Goal;
using Amirez.Infrastructure.Data.Model.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmipBackend.Controllers.Goal
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class GoalController : GenericController<
        GoalDataModel,
        GoalListItemResponse,
        GoalItemResponse,
        GoalCreateQuery,
        GoalUpdateQuery>
    {

        protected readonly IGoalService _service;

        public GoalController(IGoalService service) : base(service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }


        [HttpGet("Folder/{folderId}")]
        public async Task<ActionResult<IEnumerable<GoalListItemResponse>>> FindByFolder(Guid folderId)
        {
            var entityList = await _service.FindByFolder(folderId);
            return Ok(entityList);
        }
    }
}
