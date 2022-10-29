using System;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.Budget.Period
{
    public interface IPeriodService
    {
        Task InitPeriod(DateTime date);


        /// <summary>
        /// Clear a month.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task ClearPeriod(DateTime date);


        /// <summary>
        /// Close a period.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task ClosePeriod(DateTime date);

        /// <summary>
        /// open a period.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task OpenPeriod(DateTime date);
    }
}