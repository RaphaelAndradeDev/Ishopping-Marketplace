using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentServiceOptionAppService : AppServiceBaseT2<ComponentServiceOption>, IComponentServiceOptionAppService
    {
        private readonly IComponentServiceOptionService _componentServiceOptionService;

        public ComponentServiceOptionAppService(IComponentServiceOptionService componentServiceOptionService)
            :base(componentServiceOptionService)
        {
            _componentServiceOptionService = componentServiceOptionService;
        }

        public IEnumerable<ComponentServiceOption> GetAllByUserId(string userId)
        {
            return _componentServiceOptionService.GetAllByUserId(userId);
        }

        public ComponentServiceOption GetById(Guid id, string userId)
        {
            return _componentServiceOptionService.GetById(id, userId);
        }

        public ComponentServiceOption GetDefault(string userId)
        {
            return _componentServiceOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentServiceOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentServiceOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentServiceOption> GetByIdAsync(Guid id)
        {
            return await _componentServiceOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentServiceOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentServiceOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentServiceOption> GetDefaultAsync(string userId)
        {
            return await _componentServiceOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string title, string description, string userId)
        {
            JsonResponse json = new JsonResponse();

            var serviceOption = await _componentServiceOptionService.GetDefaultAsync(userId);
            if (serviceOption != null)
            {
                serviceOption.Change(serviceOption.Default, title, description);
                _componentServiceOptionService.Update(serviceOption);
            }

            return json;
        }
    }
}
