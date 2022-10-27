using System.ComponentModel.DataAnnotations.Schema;

namespace Amirez.Infrastructure.Data.Model.Budget
{
    [Table("budget_category")]
    public class BudgetCategoryDataModel: BaseDataModel
    {
        public string Name { get; set; }
    }
}
