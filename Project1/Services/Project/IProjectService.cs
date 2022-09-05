using Amirez.AmipBackend.Controllers.Project.Model;
using Amirez.AmipBackend.Services.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.Project
{
    public interface IProjectService : IGenericService<
        ProjectListItemResponse,
        ProjectItemResponse,
        ProjectCreateQuery,
        ProjectUpdateQuery>
    {
        Task<IEnumerable<ProjectListItemResponse>> FindByGoal(Guid goalId);
    }
}
