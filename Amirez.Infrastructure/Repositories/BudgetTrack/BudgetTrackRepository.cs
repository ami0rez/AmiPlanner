using Amirez.AmiPlanner.Infrastructure.Constants;
using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Data.Model.Budget.Enumeration;
using Amirez.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.BudgetTrack
{
    public class BudgetTrackRepository : GenericRepository<BudgetTrackDataModel>, IBudgetTrackRepository
    {
        public BudgetTrackRepository(DatabaseContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Find Budget Tracking Item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<BudgetTrackDataModel> FindById(Guid? id)
        {
            return await _context.Set<BudgetTrackDataModel>()
                .Include(f => f.Category)
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Find Budget Tracking Items by Date
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<BudgetTrackDataModel>> FindByDate(DateTime date)
        {
            return await _context.Set<BudgetTrackDataModel>()
                .Include(f => f.Category)
               .Where(e => e.Date.Month == date.Month && e.Date.Year == date.Year)
               .AsNoTracking()
               .ToListAsync();
        }

        /// <summary>
        /// Find card by subject
        /// </summary>
        /// <param name="date"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<BudgetTrackDataModel> FindBySubject(DateTime date, string name)
        {
            return await _context.Set<BudgetTrackDataModel>()
               .Where(e => e.Date.Month == date.Month
                       && e.Date.Year == date.Year
                       && e.Subject == name
                       )
               .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Find Budget Saving Tracking Item by Date
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BudgetTrackDataModel> FindSavingCard(DateTime date)
        {
            return await _context.Set<BudgetTrackDataModel>()
               .Where(e => e.Date.Month == date.Month
                       && e.Date.Year == date.Year
                       && e.Type == BudgetTypes.Saving
                       && e.Subject == Constants.DefaultSavings
                       )
               .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Calculate Incom by Date
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<double> CalculateIncom(DateTime date)
        {
            return await _context.Set<BudgetTrackDataModel>()
               .Where(e => e.Date.Month == date.Month && e.Date.Year == date.Year && e.Type == BudgetTypes.Incom)
               .SumAsync(e => e.Ammount);
        }

        /// <summary>
        /// Calculate Savings by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<double> CalculateSavings(DateTime date)
        {
            return await _context.Set<BudgetTrackDataModel>()
               .Where(e => e.Date.Month == date.Month && e.Date.Year == date.Year && e.Type == BudgetTypes.Saving)
               .SumAsync(e => e.Ammount);
        }

        /// <summary>
        /// Find All Budget Categories
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<BudgetCategoryDataModel>> FindCategories()
        {
            return await _context.Set<BudgetCategoryDataModel>()
               .AsNoTracking()
               .ToListAsync();
        }
    }
}
