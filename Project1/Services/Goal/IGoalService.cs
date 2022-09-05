using Amirez.AmipBackend.Controllers.Goal.Model;
using Amirez.AmipBackend.Services.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.Goal
{
    public interface IGoalService : IGenericService<
        GoalListItemResponse,
        GoalItemResponse,
        GoalCreateQuery,
        GoalUpdateQuery>
    {
        Task<IEnumerable<GoalListItemResponse>> FindByFolder(Guid folderId);
    }
}
