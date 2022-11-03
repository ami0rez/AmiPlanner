using Amirez.AmiPlanner.Services.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Controllers.Import
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        protected readonly IImportService _importService;

        public ImportController(IImportService importService)
        {
            _importService = importService ?? throw new ArgumentNullException(nameof(_importService));
        }
        // POST: api/v1/Activation/Import
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult> ImportFile([FromForm] IFormFile file)
        {
            await _importService.SaveImportData(file);
            return Ok();
        }
    }
}
