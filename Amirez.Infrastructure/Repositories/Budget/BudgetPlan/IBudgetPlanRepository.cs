using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.BudgetPlan
{
    public interface IBudgetPlanRepository : IGenericRepository<BudgetPlanDataModel>
    {

        /// <summary>
        /// Find Budget Planing Items by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<List<BudgetPlanDataModel>> FindByDate(DateTime date);

        /// <summary>
        /// Find Budget Planing Items by repeated
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<List<BudgetPlanDataModel>> FindRepeated(bool repeated);
        /// <summary>
        /// Find Budget Planing Items by Date No Includes
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<List<BudgetPlanDataModel>> FindByDateNoIncludes(DateTime date);

        /// <summary>
        /// Find Budget Planing Items by repeated No Includes
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<List<BudgetPlanDataModel>> FindRepeatedNoIncludes(bool repeated);

        /// <summary>
        /// Find Budget Plan Items by Date
        /// </summary>
        /// <param name="startingFrom"></param>
        /// <returns></returns>
        Task<List<BudgetPlanDataModel>> FindRepeatedPlans(DateTime startingFrom);

        /// <summary>
        /// Find card by subject
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<BudgetPlanDataModel> FindBySubject(DateTime date, string name);
    }
}
