
using Amirez.AmiPlanner.Services.Budget.Period;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Controllers.Budget.Month
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        private readonly IPeriodService _service;

        public PeriodController(IPeriodService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("Init")]
        public virtual async Task<ActionResult> Init(DateTime? date)
        {
            await _service.InitPeriod(date ?? DateTime.Today);
            return Ok();
        }

        [HttpGet("Clear")]
        public virtual async Task<ActionResult> Clear(DateTime? date)
        {
            await _service.ClearPeriod(date ?? DateTime.Today);
            return Ok();
        }

        [HttpGet("Close")]
        public virtual async Task<ActionResult> Close(DateTime? date)
        {
            await _service.ClosePeriod(date ?? DateTime.Today);
            return Ok();
        }

        [HttpGet("Open")]
        public virtual async Task<ActionResult> Open(DateTime? date)
        {
            await _service.OpenPeriod(date ?? DateTime.Today);
            return Ok();
        }

    }
}
