using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Controllers.Generic
{
    public interface IGenericController<TList, TItem, TCreate, TUpdate>
    {
        Task<ActionResult<IEnumerable<TList>>> FindAll();

        Task<ActionResult<TItem>> FindById(Guid id);

        Task<ActionResult> Create(TCreate entity);

        Task<ActionResult> Update(Guid id, TUpdate entity);

        Task<ActionResult> Delete(Guid id);
    }
}
