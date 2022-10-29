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

namespace Amirez.Infrastructure.Repositories.Budget.Period
{
    public class PeriodRepository : GenericRepository<PeriodDataModel>, IPeriodRepository
    {
        public PeriodRepository(DatabaseContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Find Period by date
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PeriodDataModel> FindByDate(DateTime date)
        {
            return await _context.Set<PeriodDataModel>()
               .FirstOrDefaultAsync(e => e.Date.Month == date.Month && e.Date.Year == date.Year);
        }

        /// <summary>
        /// Check if period is closed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsClosed(DateTime date)
        {
            return await _context.Set<PeriodDataModel>()
                .AnyAsync(period => period.Date.Month == date.Month && period.Date.Year == date.Year && period.Closed);
        }
    }
}
