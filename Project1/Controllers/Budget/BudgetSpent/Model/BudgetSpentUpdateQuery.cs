using Amirez.AmipBackend.Controllers.Generic.Model;
using System;

namespace Amirez.AmipBackend.Controllers.Budget.BudgetSpent.Models
{
    public class BudgetSpentUpdateQuery : UpdateBaseQuery
    {
        public string Subject { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public Guid ParentId { get; set; }
    }
}
