using Amirez.AmipBackend.Controllers.Generic.Model;
using System;

namespace Amirez.AmipBackend.Controllers.Common.Dashboard
{
    public class BudgetDashboardResponse : CreateBaseQuery
    {
        public double PaymentPaidAmount { get; set; }
        public double PaymentSpentsAmount { get; set; }
        public double PaymentTotalAmount { get; set; }
        public double AvailableAmount { get; set; }
        public double AvailableNotUsedAmount { get; set; }
        public double AvailableEndAmount { get; set; }
    }
}
