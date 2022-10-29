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

namespace Amirez.Infrastructure.Repositories.BudgetPlan
{
    public class BudgetPlanRepository : GenericRepository<BudgetPlanDataModel>, IBudgetPlanRepository
    {
        public BudgetPlanRepository(DatabaseContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Find Budget Planing Item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<BudgetPlanDataModel> FindById(Guid? id)
        {
            return await _context.Set<BudgetPlanDataModel>()
                .Include(f => f.Category)
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Find Budget Planing Items by Date
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<BudgetPlanDataModel>> FindByDate(DateTime date)
        {
            return await _context.Set<BudgetPlanDataModel>()
               .Include(f => f.Category)
               .Where(e => !e.Repeat && e.Date.Month == date.Month && e.Date.Year == date.Year)
               .ToListAsync();
        }

        /// <summary>
        /// Find Budget Planing Items by repeated
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<BudgetPlanDataModel>> FindRepeated(bool repeated)
        {
            return await _context.Set<BudgetPlanDataModel>()
               .Include(f => f.Category)
               .Where(e => e.Repeat == repeated)
               .ToListAsync();
        }

        /// <summary>
        /// Find Budget Planing Items by Date
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<BudgetPlanDataModel>> FindByDateNoIncludes(DateTime date)
        {
            return await _context.Set<BudgetPlanDataModel>()
               .Where(e => !e.Repeat && e.Date.Month == date.Month && e.Date.Year == date.Year)
               .AsNoTracking()
               .ToListAsync();
        }

        /// <summary>
        /// Find Budget Planing Items by repeated
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<BudgetPlanDataModel>> FindRepeatedNoIncludes(bool repeated)
        {
            return await _context.Set<BudgetPlanDataModel>()
               .Where(e => e.Repeat == repeated)
               .AsNoTracking()
               .ToListAsync();
        }

        /// <summary>
        /// Find Budget Plans Items by Date
        /// </summary>
        /// <param name="startingFrom"></param>
        /// <returns></returns>
        public async Task<List<BudgetPlanDataModel>> FindRepeatedPlans(DateTime startingFrom)
        {
            return await _context.Set<BudgetPlanDataModel>()
               .Where(e => e.Repeat && e.Date.Year >= startingFrom.Year && e.Date.Month >= startingFrom.Month)
               .Include(f => f.Category)
               .AsNoTracking()
               .ToListAsync();
        }

        /// <summary>
        /// Find card by subject
        /// </summary>
        /// <param name="date"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<BudgetPlanDataModel> FindBySubject(DateTime date, string name)
        {
            return await _context.Set<BudgetPlanDataModel>()
               .Where(e => e.Date.Month == date.Month
                       && e.Date.Year == date.Year
                       && e.Subject == name
                       )
               .FirstOrDefaultAsync();
        }
    }
}
