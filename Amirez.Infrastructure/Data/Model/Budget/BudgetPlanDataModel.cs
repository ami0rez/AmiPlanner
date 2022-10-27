using Amirez.Infrastructure.Data.Model.Budget.Enumeration;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amirez.Infrastructure.Data.Model.Budget
{
    [Table("budget_plan")]
    public class BudgetPlanDataModel: BaseDataModel
    {
        public DateTime Date { get; set; }
        public bool Repeat { get; set; }
        public string Subject { get; set; }
        public double Ammount { get; set; }
        public Guid? CategoryId { get; set; }
        public BudgetCategoryDataModel Category { get; set; }
        public BudgetTypes Type { get; set; }
    }
}
