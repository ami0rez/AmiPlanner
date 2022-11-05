
using Amirez.AmipBackend.Services.BudgetTrack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Controllers.Budget.BudgetSpent
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("Budget")]
        public virtual async Task<ActionResult> BudgetDashboard(DateTime date)
        {
            return Ok(await _service.BudgetDashboard(date));
        }
    }
}
