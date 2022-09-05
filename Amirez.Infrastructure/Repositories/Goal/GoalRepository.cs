using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Goal
{
    public class GoalRepository : GenericRepository<GoalDataModel>, IGoalRepository
    {
        public GoalRepository(DatabaseContext context)
            : base(context)
        {

        }

        public override async Task<GoalDataModel> FindById(Guid? id)
        {
            return await _context.Set<GoalDataModel>()
                .Include(g => g.Projects)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
