using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Project
{
    public class ProjectRepository : GenericRepository<ProjectDataModel>, IProjectRepository
    {
        public ProjectRepository(DatabaseContext context)
            : base(context)
        {

        }

        public override async Task<ProjectDataModel> FindById(Guid? id)
        {
            return await _context.Set<ProjectDataModel>()
                .Include(g => g.Tasks)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
