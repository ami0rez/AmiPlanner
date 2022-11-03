using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amirez.Infrastructure.Data.Model.Budget
{
    [Table("budget_spent")]
    public class BudgetSpentDataModel : BaseDataModel
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public Guid ParentId { get; set; }
        public BudgetTrackDataModel Parent { get; set; }
    }
}
