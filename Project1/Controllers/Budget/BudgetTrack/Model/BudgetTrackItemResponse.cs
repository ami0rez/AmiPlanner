using Amirez.AmipBackend.Controllers.Generic.Model;
using Amirez.AmipBackend.Controllers.Goal.Model;
using System;
using System.Collections.Generic;

namespace Amirez.AmipBackend.Controllers.Budget.BudgetTrack.Models
{
    public class BudgetTrackItemResponse : ItemBaseResponse
    {
        public IEnumerable<BudgetTrackListItemResponse> Incom { get; set; }
        public IEnumerable<BudgetTrackListItemResponse> SpentWants { get; set; }
        public IEnumerable<BudgetTrackListItemResponse> SpentNeeds { get; set; }
        public IEnumerable<BudgetTrackListItemResponse> Savings { get; set; }

        public double PercentIncom { get; set; }
        public double PercentSpentWants { get; set; }
        public double PercentSpentNeeds { get; set; }
        public double PercentSpent { get; set; }
        public double PercentSavings { get; set; }
        public double TotalIncom { get; set; }
        public double TotalSpentWants { get; set; }
        public double TotalSpentNeeds { get; set; }
        public double TotalSpent { get; set; }
        public double TotalSavings { get; set; }
        public double AvailableIncom { get; set; }
        public double AvailableSpentWants { get; set; }
        public double AvailableSpentNeeds { get; set; }
        public double AvailableSavings { get; set; }
        public bool PeriodClosed { get; set; }
    }
}
