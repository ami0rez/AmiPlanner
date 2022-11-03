using Amirez.AmipBackend.Controllers.Budget.BudgetSpent.Models;
using System;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.BudgetSpent
{
    public interface IBudgetSpentService
    {
        /// <summary>
        /// Find By Parent Id.
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<BudgetSpentItemResponse> FindByParentId(Guid? parentId);

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<BudgetSpentItemResponse> Create(BudgetSpentCreateQuery entity);

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BudgetSpentItemResponse> Delete(Guid id);



        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BudgetSpentItemResponse> Update(Guid id, BudgetSpentUpdateQuery entity);
    }
}
