using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.BudgetSpent
{
    public interface IBudgetSpentRepository : IGenericRepository<BudgetSpentDataModel>
    {
        Task<double> CalculateSpent(Guid parentId);
        Task<List<BudgetSpentDataModel>> FindIdsByParentId(Guid id);

        /// <summary>
        /// Get Spent Amount
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<double> GetSpentAmount(DateTime date);
    }
}