using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentSummaryOptionAppService : AppServiceBaseT2<ComponentSummaryOption>, IComponentSummaryOptionAppService
    {
        private readonly IComponentSummaryOptionService _componentSummaryOptionService;

        public ComponentSummaryOptionAppService(IComponentSummaryOptionService componentSummaryOptionService)
            :base(componentSummaryOptionService)
        {
            _componentSummaryOptionService = componentSummaryOptionService;
        }

        public IEnumerable<ComponentSummaryOption> GetAllByUserId(string userId)
        {
            return _componentSummaryOptionService.GetAllByUserId(userId);
        }

        public ComponentSummaryOption GetById(Guid id, string userId)
        {
            return _componentSummaryOptionService.GetById(id, userId);
        }

        public ComponentSummaryOption GetDefault(string userId)
        {
            return _componentSummaryOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentSummaryOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSummaryOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSummaryOption> GetByIdAsync(Guid id)
        {
            return await _componentSummaryOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentSummaryOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSummaryOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSummaryOption> GetDefaultAsync(string userId)
        {
            return await _componentSummaryOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string title, string catetory, string description, string userId)
        {
            JsonResponse json = new JsonResponse();

            var summaryOption = await _componentSummaryOptionService.GetDefaultAsync(userId);
            if (summaryOption != null)
            {
                summaryOption.Change(summaryOption.Default, title, catetory, description);
                _componentSummaryOptionService.Update(summaryOption);
            }

            return json;
        }
    }
}
