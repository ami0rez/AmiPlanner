using Amirez.AmipBackend.Controllers.Folder.Model;
using Amirez.AmipBackend.Services.Folder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Controllers.Folder
{
    [Route("api/v1/Amip/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _service;
        public FolderController(IFolderService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(FolderCreateQuery entity)
        {
            return Ok(await _service.Create(entity));
        }


        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }


        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<FolderListItemResponse>>> FindAll()
        {
            var entityList = await _service.FindAll();
            return Ok(entityList);
        }


        [HttpGet("Id")]
        public virtual async Task<ActionResult<FolderItemResponse>> FindById(Guid? id)
        {
            var entity = await _service.FindById(id);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update(Guid id, FolderUpdateQuery entity)
        {
            await _service.Update(id, entity);
            return Ok();
        }
    }
}
