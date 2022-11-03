using Amirez.Infrastructure.Data.Model.Budget.Enumeration;
using System;

namespace Amirez.AmipBackend.Controllers.Budget.BudgetSpent.Models
{
    public class BudgetSpentListItemResponse
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public Guid ParentId { get; set; }
    }
}
