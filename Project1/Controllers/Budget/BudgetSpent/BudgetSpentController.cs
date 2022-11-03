using Amirez.AmipBackend.Controllers.Budget.BudgetSpent.Models;
using Amirez.AmipBackend.Services.BudgetSpent;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Controllers.Budget.BudgetSpent
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class BudgetSpentController : ControllerBase
    {
        private readonly IBudgetSpentService _service;

        public BudgetSpentController(IBudgetSpentService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(BudgetSpentCreateQuery entity)
        {
            return Ok(await _service.Create(entity));
        }


        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpGet]
        public virtual async Task<ActionResult<BudgetSpentItemResponse>> FindByParentId(Guid? parentId)
        {
            var entity = await _service.FindByParentId(parentId);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update(BudgetSpentUpdateQuery entity)
        {
            return Ok(await _service.Update(entity.Id, entity));
        }
    }
}
