using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.Generic
{
    public interface IGenericService<TList, TItem, TCreate, TUpdate>
    {
        Task<IEnumerable<TList>> FindAll();

        Task<TItem> FindById(Guid? id);

        Task<TItem> Create(TCreate entity);

        Task Update(Guid id, TUpdate entity);

        Task Delete(Guid id);
    }
}
