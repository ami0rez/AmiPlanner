using Amirez.AmipBackend.Controllers.Common.Dashboard;
using Amirez.Infrastructure.Repositories.Budget.Period;
using Amirez.Infrastructure.Repositories.BudgetPlan;
using Amirez.Infrastructure.Repositories.BudgetSpent;
using Amirez.Infrastructure.Repositories.BudgetTrack;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.BudgetTrack
{
    public class DashboardService : IDashboardService
    {
        protected readonly IBudgetTrackRepository _trackRepository;
        protected readonly IBudgetPlanRepository _planContext;
        protected readonly IPeriodRepository _periodRepository;
        protected readonly IBudgetSpentRepository _spentRepository;
        protected readonly IMapper _mapper;

        public DashboardService(
            IBudgetTrackRepository dbContext,
            IBudgetPlanRepository planContext,
            IPeriodRepository periodRepository,
            IBudgetSpentRepository spentRepository,
            IMapper mapper)
        {
            _trackRepository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _planContext = planContext ?? throw new ArgumentNullException(nameof(planContext));
            _spentRepository = spentRepository ?? throw new ArgumentNullException(nameof(spentRepository));
            _periodRepository = periodRepository ?? throw new ArgumentNullException(nameof(periodRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BudgetDashboardResponse> BudgetDashboard(DateTime? date)
        {
            var response = new BudgetDashboardResponse();

            //Paiments
            response.PaymentPaidAmount = await _trackRepository.GetPaidAmount(date ?? DateTime.Today);
            response.PaymentSpentsAmount = await _spentRepository.GetSpentAmount(date ?? DateTime.Today);
            response.PaymentTotalAmount = response.PaymentPaidAmount + response.PaymentSpentsAmount;


            //Available
            var spent = await _trackRepository.CalculateSpent(date ?? DateTime.Today);
            response.AvailableAmount = spent - response.PaymentPaidAmount;
            response.AvailableNotUsedAmount = spent - (response.AvailableAmount + response.PaymentSpentsAmount);

            return response;
        }
    }
}
