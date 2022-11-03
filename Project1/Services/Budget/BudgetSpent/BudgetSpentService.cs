using Amirez.AmipBackend.Controllers.Budget.BudgetSpent.Models;
using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Repositories.Budget.Period;
using Amirez.Infrastructure.Repositories.BudgetPlan;
using Amirez.Infrastructure.Repositories.BudgetSpent;
using Amirez.Infrastructure.Repositories.BudgetTrack;
using AutoMapper;
using Involys.Common.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.BudgetSpent
{
    public class BudgetSpentService : IBudgetSpentService
    {
        protected readonly IBudgetSpentRepository _spentRepository;
        protected readonly IPeriodRepository _periodRepository;
        protected readonly IBudgetPlanRepository _planContext;
        protected readonly IBudgetTrackRepository _trackRepository;
        protected readonly IMapper _mapper;

        public BudgetSpentService(
            IBudgetSpentRepository spentRepository,
            IBudgetPlanRepository planContext,
            IBudgetTrackRepository trackRepository,
             IPeriodRepository periodRepository,
            IMapper mapper)
        {
            _spentRepository = spentRepository ?? throw new ArgumentNullException(nameof(spentRepository));
            _planContext = planContext ?? throw new ArgumentNullException(nameof(planContext));
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
            _periodRepository = periodRepository ?? throw new ArgumentNullException(nameof(periodRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<BudgetSpentItemResponse> Create(BudgetSpentCreateQuery entity)
        {
            await ValidateCreate(entity);
            var mappedEntity = _mapper.Map<BudgetSpentDataModel>(entity);
            await _spentRepository.Create(mappedEntity);
            return await FindByParentId(mappedEntity.ParentId);
        }

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<BudgetSpentItemResponse> FindByParentId(Guid? parentId)
        {
            if (!parentId.HasValue)
            {
                return new BudgetSpentItemResponse();
            }

            var items = await _spentRepository.FindIdsByParentId(parentId.Value);
            var response = new BudgetSpentItemResponse
            {
                Spendings = _mapper.ProjectTo<BudgetSpentListItemResponse>(items.AsQueryable()),
                Total = items.Sum(spent => spent.Amount)
            };
            return response;
        }

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<BudgetSpentItemResponse> Delete(Guid id)
        {
            var item = await _spentRepository.FindById(id);
            await _spentRepository.Delete(id);
            return await FindByParentId(item.ParentId);
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<BudgetSpentItemResponse> Update(Guid id, BudgetSpentUpdateQuery entity)
        {
            await ValidateUpdate(id, entity);
            var mappedEntity = _mapper.Map<BudgetSpentDataModel>(entity);
            await _spentRepository.Update(id, mappedEntity);
            return await FindByParentId(mappedEntity.ParentId);
        }

        public async Task ValidateCreate(BudgetSpentCreateQuery entity)
        {
            if(!await CanAddAmount(entity))
            {
                throw new ResponseException("Spendings Exceeded budget Amount");
            }
        }

        public async Task<bool> CanAddAmount(BudgetSpentCreateQuery entity)
        {
            var spentAmountSum = await _spentRepository.CalculateSpent(entity.ParentId);
            var budgetItem = await _trackRepository.GetbyId(entity.ParentId);
            return spentAmountSum + entity.Amount <= budgetItem.Ammount; 
        }

        public async Task ValidateUpdate(Guid id, BudgetSpentUpdateQuery entity)
        {
            if (!await CanUpdateAmount(entity))
            {
                throw new ResponseException("Spendings Exceeded budget Amount");
            }
        }

        public async Task<bool> CanUpdateAmount(BudgetSpentUpdateQuery entity)
        {
            var spentAmountSum = await _spentRepository.CalculateSpent(entity.ParentId);
            var spentItem = await _spentRepository.FindById(entity.Id);
            var budgetItem = await _trackRepository.GetbyId(entity.ParentId);
            return spentAmountSum - spentItem.Amount + entity.Amount <= budgetItem.Ammount;
        }
    }
}
