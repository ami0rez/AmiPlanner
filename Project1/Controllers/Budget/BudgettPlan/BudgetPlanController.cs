using Amirez.AmipBackend.Controllers.Budget.BudgetPlan.Models;
using Amirez.AmipBackend.Services.BudgetPlan;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Controllers.Budget.BudgetPlan
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class BudgetPlanController : ControllerBase
    {
        private readonly IBudgetPlanService _service;
        public BudgetPlanController(IBudgetPlanService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(BudgetPlanCreateQuery entity)
        {
            return Ok(await _service.Create(entity));
        }


        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }


        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<BudgetPlanListItemResponse>>> FindPlans()
        {
            var plans = await _service.FindPlans();
            return Ok(plans);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update(BudgetPlanUpdateQuery entity)
        {
            return Ok(await _service.Update(entity.Id, entity));
        }
    }
}
