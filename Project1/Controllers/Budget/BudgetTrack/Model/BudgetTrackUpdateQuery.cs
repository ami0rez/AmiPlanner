using Amirez.AmipBackend.Controllers.Generic.Model;
using Amirez.Infrastructure.Data.Model.Budget.Enumeration;
using System;

namespace Amirez.AmipBackend.Controllers.Budget.BudgetTrack.Models
{
    public class BudgetTrackUpdateQuery : UpdateBaseQuery
    {
        public string Subject { get; set; }

        public double Ammount { get; set; }

        public DateTime Date { get; set; }

        public Guid? CategoryId { get; set; }

        public BudgetTypes Type { get; set; }
    }
}
