using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.BudgetTrack
{
    public interface IBudgetTrackRepository : IGenericRepository<BudgetTrackDataModel>
    {

        /// <summary>
        /// Find Budget Tracking Items by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<List<BudgetTrackDataModel>> FindByDate(DateTime date);

        /// <summary>
        /// Find card by subject
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<BudgetTrackDataModel> FindBySubject(DateTime date, string name);

        /// <summary>
        /// Find First Budget Tracking Item for saving by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<BudgetTrackDataModel> FindSavingCard(DateTime date);

        /// <summary>
        /// Calculate Savings by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<double> CalculateSavings(DateTime date);

        /// <summary>
        /// Calculate Incom by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<double> CalculateIncom(DateTime date);

        /// <summary>
        /// Find All Budget Categories
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<BudgetCategoryDataModel>> FindCategories();
    }
}
