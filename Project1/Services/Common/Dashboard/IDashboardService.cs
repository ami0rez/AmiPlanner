using Amirez.AmipBackend.Controllers.Common.Dashboard;
using System;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.BudgetTrack
{
    public interface IDashboardService
    {
        /// <summary>
        /// BudgetDashboard
        /// </summary>
        /// <returns></returns>
        Task<BudgetDashboardResponse> BudgetDashboard(DateTime? date);
    }
}
