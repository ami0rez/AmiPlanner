using Amirez.Infrastructure.Data.Model.Budget.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amirez.Infrastructure.Data.Model.Budget
{
    [Table("budget_track")]
    public class BudgetTrackDataModel: BaseDataModel
    {
        public DateTime Date { get; set; }
        public bool Repeat { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Subject { get; set; }
        public double Ammount { get; set; }
        public Guid? CategoryId { get; set; }
        public BudgetCategoryDataModel Category { get; set; }
        public BudgetTypes Type { get; set; }
        public IEnumerable<BudgetSpentDataModel> Spendings { get; set; }
    }
}
