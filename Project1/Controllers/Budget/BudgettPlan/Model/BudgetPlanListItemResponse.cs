using Amirez.Infrastructure.Data.Model.Budget.Enumeration;
using System;

namespace Amirez.AmipBackend.Controllers.Budget.BudgetPlan.Models
{
    public class BudgetPlanListItemResponse
    {
        public Guid Id { get; set; }

        public string Subject { get; set; }

        public bool Repeat { get; set; }

        public bool Paid { get; set; }

        public double Ammount { get; set; }

        public DateTime Date { get; set; }

        public Guid? CategoryId { get; set; }

        public BudgetTypes Type { get; set; }
    }
}
