﻿using Amirez.Infrastructure.Data.Model.Budget;
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
        /// Find Budget Tracking Item
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<BudgetTrackDataModel> GetbyId(Guid id);

        /// <summary>
        /// Find Budget Tracking Ids by Date No Includes
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<List<Guid>> FindIdsByDate(DateTime date);

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
        /// Calculate spent by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<double> CalculateSpent(DateTime date);

        /// <summary>
        /// Find All Budget Categories
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<BudgetCategoryDataModel>> FindCategories();


        /// <summary>
        /// Get PaidAmount
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<double> GetPaidAmount(DateTime date);

        /// <summary>
        /// Get Unpaid Amount
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<double> GetUnpaidAmount(DateTime date);
    }
}
