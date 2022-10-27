using Amirez.AmipBackend.Controllers.Budget.BudgetPlan.Models;
using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Repositories.BudgetPlan;
using Amirez.Infrastructure.Repositories.BudgetTrack;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.BudgetPlan
{
    public class BudgetPlanService : IBudgetPlanService
    {
        protected readonly IBudgetPlanRepository _context;
        protected readonly IBudgetTrackRepository _trackContext;
        protected readonly IMapper _mapper;

        public BudgetPlanService(IBudgetPlanRepository dbContext, IMapper mapper)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
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
            var dbList = _context.FindAll();
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

        public Task ValidateCreate(BudgetPlanCreateQuery entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateUpdate(Guid id, BudgetPlanUpdateQuery entity)
        {
            return Task.CompletedTask;
        }
    }
}
