using Amirez.AmipBackend.Controllers.Budget.BudgetTrack.Models;
using Amirez.AmiPlanner.Common.Constants;
using Amirez.AmiPlanner.Common.Models;
using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Data.Model.Budget.Enumeration;
using Amirez.Infrastructure.Repositories.Budget.Period;
using Amirez.Infrastructure.Repositories.BudgetPlan;
using Amirez.Infrastructure.Repositories.BudgetTrack;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.BudgetTrack
{
    public class BudgetTrackService : IBudgetTrackService
    {
        protected readonly IBudgetTrackRepository _context;
        protected readonly IBudgetPlanRepository _planContext;
        protected readonly IPeriodRepository _periodRepository;
        protected readonly IMapper _mapper;

        public BudgetTrackService(
            IBudgetTrackRepository dbContext,
            IBudgetPlanRepository planContext,
             IPeriodRepository periodRepository,
            IMapper mapper)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _planContext = planContext ?? throw new ArgumentNullException(nameof(planContext));
            _periodRepository = periodRepository ?? throw new ArgumentNullException(nameof(periodRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<BudgetTrackItemResponse> Create(BudgetTrackCreateQuery entity)
        {
            await ValidateCreate(entity);
            var mappedEntity = _mapper.Map<BudgetTrackDataModel>(entity);
            await _context.Create(mappedEntity);
            //if (entity.Type == BudgetTypes.Incom)
            //{
            //    await ManageIncomUpdate(mappedEntity);
            //}
            return await FindByDate(mappedEntity.Date);
        }

        /// <summary>
        /// Manage Incom Update for a month.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task ManageIncomUpdate(BudgetTrackDataModel entity)
        {
            if (entity.Type == BudgetTypes.Incom)
            {
                var incom = await _context.CalculateIncom(entity?.Date ?? DateTime.Today);

                //Create saving card if not found
                var savingCard = await _context.FindSavingCard(entity?.Date ?? DateTime.Today);
                if (savingCard == null)
                {
                    savingCard = new BudgetTrackDataModel
                    {
                        Ammount = incom * 20 / 100,
                        Subject = Constants.DefaultSavings,
                        Date = entity?.Date ?? DateTime.Today,
                        Type = BudgetTypes.Saving
                    };
                    await _context.Create(savingCard);
                }
                else
                {
                    savingCard.Ammount = incom * 20 / 100;
                    await _context.Update(savingCard.Id, savingCard);
                }

                //Add repeat plans for month 
                var repeatedPlans = await _planContext.FindRepeatedPlans(entity?.Date ?? DateTime.Today);
                foreach (var item in repeatedPlans)
                {
                    if (item != null)
                    {
                        var card = _mapper.Map<BudgetTrackDataModel>(item);
                        card.Category = null;
                        card.Date = entity.Date;
                        await _context.Create(card);
                    }
                }
            }
        }

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<ListItem>> GetCategoryOptions()
        {
            var dblist = await _context.FindCategories();
            var mappedList = _mapper.ProjectTo<ListItem>(dblist.AsQueryable());
            return mappedList.AsEnumerable();
        }

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<BudgetTrackItemResponse> Delete(Guid id)
        {
            var item = await _context.FindById(id);
            await _context.Delete(id);
            return await FindByDate(item.Date);
        }

        /// <summary>
        /// Find Entity by id.
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        public virtual async Task<BudgetTrackItemResponse> FindByDate(DateTime? month)
        {
            var dbList = await _context.FindByDate(month.HasValue ? month.Value : DateTime.Today);
            var mappedItems = _mapper.ProjectTo<BudgetTrackListItemResponse>(dbList.AsQueryable());
            var budgetTracking = new BudgetTrackItemResponse
            {
                Incom = mappedItems.Where(item => item.Type == BudgetTypes.Incom),
                SpentNeeds = mappedItems.Where(item => item.Type == BudgetTypes.Need),
                SpentWants = mappedItems.Where(item => item.Type == BudgetTypes.Want),
                Savings = mappedItems.Where(item => item.Type == BudgetTypes.Saving),
            };
            budgetTracking.PeriodClosed = await _periodRepository.IsClosed(month.HasValue ? month.Value : DateTime.Today);
            await CalculateAmmounts(budgetTracking);
            return budgetTracking;

        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Task CalculateAmmounts(BudgetTrackItemResponse budget)
        {
            //Totals
            budget.TotalIncom = budget.Incom.Sum(incom => incom.Ammount);
            budget.TotalSavings = budget.Savings.Sum(incom => incom.Ammount);
            budget.TotalSpentNeeds = budget.SpentNeeds.Sum(incom => incom.Ammount);
            budget.TotalSpentWants = budget.SpentWants.Sum(incom => incom.Ammount);
            budget.TotalSpent = budget.TotalSpentNeeds + budget.TotalSpentWants;

            //Percents
            budget.PercentIncom = budget.TotalIncom;
            budget.PercentSavings = budget.TotalIncom * 20 / 100;
            budget.PercentSpentNeeds = budget.TotalIncom * 50 / 100;
            budget.PercentSpentWants = budget.TotalIncom * 30 / 100;
            budget.PercentSpent = budget.PercentSpentNeeds + budget.PercentSpentWants;

            //Availables
            budget.AvailableIncom = budget.TotalIncom - (budget.TotalSavings + budget.TotalSpent);
            budget.AvailableSavings = budget.TotalSavings;
            budget.AvailableSpentNeeds = budget.PercentSpentNeeds - budget.TotalSpentNeeds;
            budget.AvailableSpentWants = budget.PercentSpentWants - budget.TotalSpentWants;

            //If there is some rest of savings then add the savings percent to the spent
            if (budget.TotalSavings < budget.PercentSavings)
            {
                var restSavings = budget.PercentSavings - budget.TotalSavings;
                budget.AvailableSpentWants += budget.PercentSavings / 2;
                budget.AvailableSpentNeeds += budget.PercentSavings / 2;
            }

            //if there is no spents
            if (budget.AvailableSpentNeeds < 0 && budget.AvailableSpentWants > budget.AvailableSpentNeeds)
            {
                budget.AvailableSpentWants += budget.AvailableSpentNeeds;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<BudgetTrackItemResponse> Update(Guid id, BudgetTrackUpdateQuery entity)
        {
            await ValidateUpdate(id, entity);
            var mappedEntity = _mapper.Map<BudgetTrackDataModel>(entity);
            await _context.Update(id, mappedEntity);
            await ManageIncomUpdate(mappedEntity);
            return await FindByDate(mappedEntity.Date);
        }

        public Task ValidateCreate(BudgetTrackCreateQuery entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateUpdate(Guid id, BudgetTrackUpdateQuery entity)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Pay a budget item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<BudgetTrackItemResponse> Pay(Guid id)
        {
            var item = await _context.FindById(id);
            if(item != null)
            {
                item.Paid = true;
                item.PaymentDate = DateTime.Now;
                await _context.Update(item.Id, item);
            }
            var planeItem = await _planContext.FindBySubject(item.Date, item.Subject);
            if(planeItem != null && !planeItem.Repeat)
            {
                planeItem.Paid = true;
                await _planContext.Update(planeItem.Id, planeItem);
            }
            return await FindByDate(item.Date);
        }


        /// <summary>
        /// Refund a budget item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<BudgetTrackItemResponse> Refund(Guid id)
        {
            var item = await _context.FindById(id);
            if (item != null)
            {
                item.Paid = false;
                item.PaymentDate = null;
                await _context.Update(item.Id, item);
            }
            var planeItem = await _planContext.FindBySubject(item.Date, item.Subject);
            if (planeItem != null && !planeItem.Repeat)
            {
                planeItem.Paid = false;
                await _planContext.Update(planeItem.Id, planeItem);
            }
            return await FindByDate(item.Date);
        }
    }
}
