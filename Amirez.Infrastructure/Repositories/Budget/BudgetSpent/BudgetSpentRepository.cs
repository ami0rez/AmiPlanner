using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.BudgetSpent
{
    public class BudgetSpentRepository : GenericRepository<BudgetSpentDataModel>, IBudgetSpentRepository
    {
        public BudgetSpentRepository(DatabaseContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Find Budget Spending Ids by Date No Includes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<BudgetSpentDataModel>> FindIdsByParentId(Guid parentId)
        {
            return await _context.Set<BudgetSpentDataModel>()
               .Where(e => e.ParentId == parentId)
               .AsNoTracking()
               .ToListAsync();
        }

        /// <summary>
        /// Calculate Savings by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<double> CalculateSpent(Guid parentId)
        {
            return await _context.Set<BudgetSpentDataModel>()
               .Where(e => e.ParentId == parentId)
               .SumAsync(e => e.Amount);
        }

        /// <summary>
        /// Calculate Savings by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<double> GetSpentAmount(DateTime date)
        {
            return await _context.Set<BudgetSpentDataModel>()
               .Where(e => e.Date.Month == date.Month && e.Date.Year == date.Year && !e.Parent.Paid)
               .SumAsync(e => e.Amount);
        }
    }
}
