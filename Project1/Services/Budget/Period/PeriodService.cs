using Amirez.AmipBackend.Common.Constants;
using Amirez.AmiPlanner.Common.Constants;
using Amirez.Common.Exceptions;
using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Data.Model.Budget.Enumeration;
using Amirez.Infrastructure.Repositories.Budget.Period;
using Amirez.Infrastructure.Repositories.BudgetPlan;
using Amirez.Infrastructure.Repositories.BudgetTrack;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.Budget.Period
{
    public class PeriodService : IPeriodService
    {
        protected readonly IBudgetTrackRepository _trackRepository;
        protected readonly IBudgetPlanRepository _planRepository;
        protected readonly IPeriodRepository _periodRepository;
        protected readonly IMapper _mapper;

        public PeriodService(
            IBudgetTrackRepository trackRepository,
            IBudgetPlanRepository planRepository,
            IPeriodRepository periodRepository,
            IMapper mapper
            )
        {
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
            _planRepository = planRepository ?? throw new ArgumentNullException(nameof(planRepository));
            _periodRepository = periodRepository ?? throw new ArgumentNullException(nameof(periodRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        /// <summary>
        /// Init a month.
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual async Task InitPeriod(DateTime date)
        {
            await ValidatePeriodClearInit(date);
            await CreatePeriodIfNotExist(date);
            await ClearPeriod(date);
            var repeatedPlanCards = await _planRepository.FindRepeatedNoIncludes(true);
            var monthPlanedCards = await _planRepository.FindByDateNoIncludes(date);
            repeatedPlanCards.AddRange(monthPlanedCards);

            foreach (var item in repeatedPlanCards)
            {
                if (item != null)
                {
                    var card = _mapper.Map<BudgetTrackDataModel>(item);
                    card.Date = date;
                    await _trackRepository.Create(card);
                }
            }
            await ManageSavings(date);
        }



        /// <summary>
        /// Clear a month.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual async Task ValidatePeriodClearInit(DateTime date)
        {
            var period = await _periodRepository.FindByDate(date);
            if (period != null && period.Closed)
            {
                throw new ResponseException(ErrorConstants.PeriodClosed);
            }
        }



        /// <summary>
        /// Create poeriod if not exists.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual async Task CreatePeriodIfNotExist(DateTime date)
        {
            var period = await _periodRepository.FindByDate(date);
            if (period == null)
            {
                period = new PeriodDataModel
                {
                    Date = date,
                    Closed = false
                };
                await _periodRepository.Create(period);
            }
        }



        /// <summary>
        /// Clear a month.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual async Task ClearPeriod(DateTime date)
        {
            await ValidatePeriodClearInit(date);
            var cardIds = await _trackRepository.FindIdsByDate(date);
            await _trackRepository.DeleteRange(cardIds);
        }

        /// <summary>
        /// Manage Incom Update for a month.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual async Task ManageSavings(DateTime date)
        {
            var incom = await _trackRepository.CalculateIncom(date);

            //Create saving card if not found
            var savingCard = await _trackRepository.FindSavingCard(date);
            if (savingCard == null)
            {
                savingCard = new BudgetTrackDataModel
                {
                    Ammount = incom * 20 / 100,
                    Subject = Constants.DefaultSavings,
                    Date = date,
                    Type = BudgetTypes.Saving
                };
                await _trackRepository.Create(savingCard);
            }
            else
            {
                savingCard.Ammount = incom * 20 / 100;
                await _trackRepository.Update(savingCard.Id, savingCard);
            }
        }

        /// <summary>
        /// Close a period.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual async Task ClosePeriod(DateTime date)
        {
            var period = await _periodRepository.FindByDate(date);
            if (period != null)
            {
                period.Closed = true;
                period.ClosedDate = DateTime.Now;
                await _periodRepository.Update(period.Id, period);
            }
        }



        /// <summary>
        /// Validate if can close period.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual async Task ValidatePeriodClose(DateTime date)
        {
            var period = await _periodRepository.FindByDate(date);
            if (period != null && !period.Closed)
            {
                throw new ResponseException(ErrorConstants.PeriodAlreadyOpen);
            }
        }

        /// <summary>
        /// open a period.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual async Task OpenPeriod(DateTime date)
        {
            await ValidatePeriodOpen(date);
            var period = await _periodRepository.FindByDate(date);
            if (period != null)
            {
                period.Closed = false;
                period.ClosedDate = null;
                await _periodRepository.Update(period.Id, period);
            }
        }



        /// <summary>
        /// Validate if can open period.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual async Task ValidatePeriodOpen(DateTime date)
        {
            var period = await _periodRepository.FindByDate(date);
            if (period != null && !period.Closed)
            {
                throw new ResponseException(ErrorConstants.PeriodAlreadyOpen);
            }
        }
    }
}
