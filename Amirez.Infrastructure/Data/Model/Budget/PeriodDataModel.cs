using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amirez.Infrastructure.Data.Model.Budget
{

    [Table("budget_period")]
    public class PeriodDataModel : BaseDataModel
    {
        public bool Closed { get; set; }
        public DateTime? ClosedDate { get; set; }
        public DateTime Date { get; set; }
    }
}
