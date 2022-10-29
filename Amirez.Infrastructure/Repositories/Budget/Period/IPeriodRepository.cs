using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Budget.Period
{
    public interface IPeriodRepository : IGenericRepository<PeriodDataModel>
    {

        /// <summary>
        /// Find Budget Tracking Items by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<PeriodDataModel> FindByDate(DateTime date);

        /// <summary>
        /// Find All Budget Categories
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> IsClosed(DateTime date);
    }
}
