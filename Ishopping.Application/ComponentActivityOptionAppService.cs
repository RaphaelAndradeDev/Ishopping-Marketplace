using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentActivityOptionAppService : AppServiceBaseT2<ComponentActivityOption>, IComponentActivityOptionAppService
    {
        private readonly IComponentActivityOptionService _componentActivityOptionService;

        public ComponentActivityOptionAppService(IComponentActivityOptionService componentActivityOptionService)
            :base(componentActivityOptionService)
        {
            _componentActivityOptionService = componentActivityOptionService;
        }       

        // Sync Methods
        public IEnumerable<ComponentActivityOption> GetAllByUserId(string userId)
        {
            return _componentActivityOptionService.GetAllByUserId(userId);
        }

        public ComponentActivityOption GetById(Guid id, string userId)
        {
            return _componentActivityOptionService.GetById(id, userId);
        }
        
        public ComponentActivityOption GetDefault(string userId)
        {
            return _componentActivityOptionService.GetDefault(userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentActivityOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentActivityOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentActivityOption> GetByIdAsync(Guid id)
        {
            return await _componentActivityOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentActivityOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentActivityOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentActivityOption> GetDefaultAsync(string userId)
        {
            return await _componentActivityOptionService.GetDefaultAsync(userId);
        }

        // Other Methods
        public async Task<JsonResponse> AppUpdateAsync(string title, string description, string userId)
        {
            JsonResponse json = new JsonResponse();

            var activityOption = await _componentActivityOptionService.GetDefaultAsync(userId);
            if (activityOption != null)
            {
                activityOption.Change(activityOption.Default, title, description);            
                _componentActivityOptionService.Update(activityOption);
            }

            return json;
        }
                
    }
}
