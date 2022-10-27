using Amirez.AmipBackend.Controllers.Budget.BudgetTrack.Models;
using Amirez.AmipBackend.Services.BudgetTrack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Controllers.Budget.BudgetTrack
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class BudgetTrackController : ControllerBase
    {
        private readonly IBudgetTrackService _service;

        public BudgetTrackController(IBudgetTrackService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(BudgetTrackCreateQuery entity)
        {
            return Ok(await _service.Create(entity));
        }


        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }


        [HttpGet("Options")]
        public virtual async Task<ActionResult> GetCategoryOptions()
        {
            return Ok(await _service.GetCategoryOptions());
        }


        [HttpGet]
        public virtual async Task<ActionResult<BudgetTrackItemResponse>> FindByDate(DateTime? date)
        {
            var entity = await _service.FindByDate(date);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update(BudgetTrackUpdateQuery entity)
        {
            return Ok(await _service.Update(entity.Id, entity));
        }
    }
}
