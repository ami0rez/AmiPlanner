using Amirez.AmipBackend.Controllers.Budget.BudgetPlan.Models;
using Amirez.AmiPlanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.BudgetPlan
{
    public interface IBudgetPlanService
    {

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<IEnumerable<BudgetPlanListItemResponse>> Create(BudgetPlanCreateQuery entity);

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<BudgetPlanListItemResponse>> Delete(Guid id);


        /// <summary>
        /// Find Entity Plans
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        Task<IEnumerable<BudgetPlanListItemResponse>> FindPlans();



        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<BudgetPlanListItemResponse>> Update(Guid id, BudgetPlanUpdateQuery entity);
    }
}
