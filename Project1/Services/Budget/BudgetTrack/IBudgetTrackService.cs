using Amirez.AmipBackend.Controllers.Budget.BudgetTrack.Models;
using Amirez.AmiPlanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.BudgetTrack
{
    public interface IBudgetTrackService
    {

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<BudgetTrackItemResponse> Create(BudgetTrackCreateQuery entity);


        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<IEnumerable<ListItem>> GetCategoryOptions();

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BudgetTrackItemResponse> Delete(Guid id);


        /// <summary>
        /// Find Entity by id.
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        Task<BudgetTrackItemResponse> FindByDate(DateTime? month);



        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BudgetTrackItemResponse> Update(Guid id, BudgetTrackUpdateQuery entity);
    }
}
