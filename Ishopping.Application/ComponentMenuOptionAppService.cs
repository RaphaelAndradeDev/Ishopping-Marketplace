using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentMenuOptionAppService : AppServiceBaseT2<ComponentMenuOption>, IComponentMenuOptionAppService
    {
        private readonly IComponentMenuOptionService _componentMenuOptionService;

        public ComponentMenuOptionAppService(IComponentMenuOptionService componentMenuOptionService)
            :base(componentMenuOptionService)
        {
            _componentMenuOptionService = componentMenuOptionService;
        }

        public IEnumerable<ComponentMenuOption> GetAllByUserId(string userId)
        {
            return _componentMenuOptionService.GetAllByUserId(userId);
        }

        public ComponentMenuOption GetById(Guid id, string userId)
        {
            return _componentMenuOptionService.GetById(id, userId);
        }

        public ComponentMenuOption GetDefault(string userId)
        {
            return _componentMenuOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentMenuOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentMenuOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentMenuOption> GetByIdAsync(Guid id)
        {
            return await _componentMenuOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentMenuOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentMenuOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentMenuOption> GetDefaultAsync(string userId)
        {
            return await _componentMenuOptionService.GetDefaultAsync(userId);
        }

        public async Task<JsonResponse> AppUpdateAsync(string title, string description, string price, string userId)
        {
            JsonResponse json = new JsonResponse();

            var menuOption = await _componentMenuOptionService.GetDefaultAsync(userId);
            if (menuOption != null)
            {
                menuOption.Change(menuOption.Default, title, description, price);
                _componentMenuOptionService.Update(menuOption);
            }

            return json;
        }
    }
}
