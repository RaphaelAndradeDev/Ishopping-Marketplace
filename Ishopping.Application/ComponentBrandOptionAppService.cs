using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentBrandOptionAppService : AppServiceBaseT2<ComponentBrandOption>, IComponentBrandOptionAppService
    {
        private readonly IComponentBrandOptionService _componentBrandOptionService;

        public ComponentBrandOptionAppService(IComponentBrandOptionService componentBrandOptionService)
            :base(componentBrandOptionService)
        {
            _componentBrandOptionService = componentBrandOptionService;
        }

        // Sync Methods
        public IEnumerable<ComponentBrandOption> GetAllByUserId(string userId)
        {
            return _componentBrandOptionService.GetAllByUserId(userId);
        }

        public ComponentBrandOption GetById(Guid id, string userId)
        {
            return _componentBrandOptionService.GetById(id, userId);
        }

        public ComponentBrandOption GetDefault(string userId)
        {
            return _componentBrandOptionService.GetDefault(userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentBrandOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentBrandOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentBrandOption> GetByIdAsync(Guid id)
        {
            return await _componentBrandOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentBrandOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentBrandOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentBrandOption> GetDefaultAsync(string userId)
        {
            return await _componentBrandOptionService.GetDefaultAsync(userId);
        }

        // Other Methods
        public async Task<JsonResponse> AppUpdateAsync(string marca, string comment, string userId)
        {
            JsonResponse json = new JsonResponse();

            var brandOption = await _componentBrandOptionService.GetDefaultAsync(userId);
            if (brandOption != null)
            {
                brandOption.Change(brandOption.Default, marca, comment);
                _componentBrandOptionService.Update(brandOption);
            }

            return json;
        }
    }
}
