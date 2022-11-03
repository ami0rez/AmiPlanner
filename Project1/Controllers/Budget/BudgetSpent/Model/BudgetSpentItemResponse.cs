using Amirez.AmipBackend.Controllers.Generic.Model;
using System.Collections.Generic;

namespace Amirez.AmipBackend.Controllers.Budget.BudgetSpent.Models
{
    public class BudgetSpentItemResponse : ItemBaseResponse
    {
        public IEnumerable<BudgetSpentListItemResponse> Spendings { get; set; }

        public double Total { get; set; }
    }
}
