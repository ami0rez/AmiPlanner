using Amirez.AmipBackend.Common.Constants;
using Amirez.AmipBackend.Controllers.Budget.BudgetPlan.Models;
using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Repositories.Budget.Period;
using Amirez.Infrastructure.Repositories.BudgetPlan;
using Amirez.Infrastructure.Repositories.BudgetTrack;
using AutoMapper;
using Involys.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.BudgetPlan
{
    public class BudgetPlanService : IBudgetPlanService
    {
        protected readonly IBudgetPlanRepository _context;
        protected readonly IBudgetTrackRepository _trackContext;
        protected readonly IPeriodRepository _periodRepository;
        protected readonly IMapper _mapper;

        public BudgetPlanService(
            IBudgetPlanRepository dbContext,
            IBudgetTrackRepository trackContext,
            IPeriodRepository periodRepository,
            IMapper mapper)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _trackContext = trackContext ?? throw new ArgumentNullException(nameof(trackContext));
            _periodRepository = periodRepository ?? throw new ArgumentNullException(nameof(periodRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<BudgetPlanListItemResponse>> Create(BudgetPlanCreateQuery entity)
        {
            await ValidateCreate(entity);
            var mappedEntity = _mapper.Map<BudgetPlanDataModel>(entity);
            await _context.Create(mappedEntity);
            await ManagePlannedItems(mappedEntity);
            return await FindPlans();
        }

        /// <summary>
        /// Manage Planned Items Properties.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task ManagePlannedItems(BudgetPlanDataModel entity)
        {
            if (entity.Repeat)
            {
                var item = await _context.FindBySubject(DateTime.Today, entity.Subject);
                if (item == null)
                {
                    var card = _mapper.Map<BudgetPlanDataModel>(entity);
                    await _context.Create(card);
                }
            }
        }

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<BudgetPlanListItemResponse>> Delete(Guid id)
        {
            var item = await _context.FindById(id);
            await _context.Delete(id);
            return await FindPlans();
        }

        /// <summary>
        /// Find Entity by id.
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        public async Task<IEnumerable<BudgetPlanListItemResponse>> FindPlans()
        {
            var dbList = _context.FindAll(plan => !plan.Paid);
            var mappedItems = _mapper.ProjectTo<BudgetPlanListItemResponse>(dbList);
            return mappedItems;

        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<BudgetPlanListItemResponse>> Update(Guid id, BudgetPlanUpdateQuery entity)
        {
            await ValidateUpdate(id, entity);
            var mappedEntity = _mapper.Map<BudgetPlanDataModel>(entity);
            await _context.Update(id, mappedEntity);
            return await FindPlans();
        }

        /// <summary>
        /// Validate creation
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected async Task ValidateCreate(BudgetPlanCreateQuery entity)
        {
            if (string.IsNullOrEmpty(entity.Subject?.Trim()))
            {
                throw new ResponseException(ErrorConstants.InvalidSubject);
            }
            if (entity.Ammount <= 0)
            {
                throw new ResponseException(ErrorConstants.InvalidAmout);
            }
            if (entity.Date.HasValue)
            {
                if (!entity.Repeat && entity.Date.Value.Month <= DateTime.Today.Month && entity.Date.Value.Year <= DateTime.Today.Year)
                {
                    throw new ResponseException(ErrorConstants.PlanDateMustBeFutureMonths);
                }
            }

            var subjectFound = await _context.AnyAsync(plan => plan.Subject == entity.Subject);
            if (subjectFound)
            {
                throw new ResponseException(ErrorConstants.SubjectAlreadyUsed);
            }

            if (entity.Date.HasValue)
            {
                var periodClosed = await _periodRepository.IsClosed(entity.Date.Value);
                if (subjectFound)
                {
                    throw new ResponseException(ErrorConstants.PeriodClosed);
                }
            }

        }

        /// <summary>
        /// Validate update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        public async Task ValidateUpdate(Guid id, BudgetPlanUpdateQuery entity)
        {
            if (string.IsNullOrEmpty(entity.Subject?.Trim()))
            {
                throw new ResponseException(ErrorConstants.InvalidSubject);
            }
            if (entity.Ammount <= 0)
            {
                throw new ResponseException(ErrorConstants.InvalidAmout);
            }

            var oldEntity = await _context.FindById(id);
            if (oldEntity == null)
            {
                throw new ResponseException(ErrorConstants.InvalidPlan);
            }
            if (!entity.Repeat && entity.Date != oldEntity.Date && (entity.Date < DateTime.Today || entity.Date.Month <= DateTime.Today.Month))
            {
                throw new ResponseException(ErrorConstants.PlanDateMustBeFutureMonths);
            }

            var subjectFound = await _context.AnyAsync(plan => plan.Subject == entity.Subject && plan.Id != id);
            if (subjectFound)
            {
                throw new ResponseException(ErrorConstants.SubjectAlreadyUsed);
            }

            var periodClosed = await _periodRepository.IsClosed(entity.Date);
            if (subjectFound)
            {
                throw new ResponseException(ErrorConstants.PeriodClosed);
            }
        }
    }
}
