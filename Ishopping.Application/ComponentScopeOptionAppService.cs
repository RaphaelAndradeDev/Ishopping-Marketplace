using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentScopeOptionAppService : AppServiceBaseT2<ComponentScopeOption>, IComponentScopeOptionAppService
    {
        private readonly IComponentScopeOptionService _componentScopeOptionService;

        public ComponentScopeOptionAppService(IComponentScopeOptionService componentScopeOptionService)
            :base(componentScopeOptionService)
        {
            _componentScopeOptionService = componentScopeOptionService;
        }

        public IEnumerable<ComponentScopeOption> GetAllByUserId(string userId)
        {
            return _componentScopeOptionService.GetAllByUserId(userId);
        }

        public ComponentScopeOption GetById(Guid id, string userId)
        {
            return _componentScopeOptionService.GetById(id, userId);
        }

        public ComponentScopeOption GetDefault(string userId)
        {
            return _componentScopeOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentScopeOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentScopeOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentScopeOption> GetByIdAsync(Guid id)
        {
            return await _componentScopeOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentScopeOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentScopeOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentScopeOption> GetDefaultAsync(string userId)
        {
            return await _componentScopeOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string title, string category, string description, string userId)
        {
            JsonResponse json = new JsonResponse();

            var scopeOption = await _componentScopeOptionService.GetDefaultAsync(userId);
            if (scopeOption != null)
            {
                scopeOption.Change(scopeOption.Default, title, category, description);
                _componentScopeOptionService.Update(scopeOption);
            }

            return json;
        }
    }
}
