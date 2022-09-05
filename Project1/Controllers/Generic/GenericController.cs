using Amirez.AmipBackend.Services.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Controllers.Generic
{
    public abstract class GenericController<TEntity, TList, TItem, TCreate, TUpdate> : ControllerBase, IGenericController<TList, TItem, TCreate, TUpdate>
    {
        protected readonly IGenericService<TList, TItem, TCreate, TUpdate> _service;

        public GenericController(IGenericService<TList, TItem, TCreate, TUpdate> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(TCreate entity)
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
        public virtual async Task<ActionResult<IEnumerable<TList>>> FindAll()
        {
            var entityList = await _service.FindAll();
            return Ok(entityList);
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TItem>> FindById(Guid id)
        {
            var entity = await _service.FindById(id);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update(Guid id, TUpdate entity)
        {
            await _service.Update(id, entity);
            return Ok();
        }
    }
}
