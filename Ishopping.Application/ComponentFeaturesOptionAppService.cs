using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentFeaturesOptionAppService : AppServiceBaseT2<ComponentFeaturesOption>, IComponentFeaturesOptionAppService
    {
        private readonly IComponentFeaturesOptionService _componentFeaturesOptionService;

        public ComponentFeaturesOptionAppService(IComponentFeaturesOptionService componentFeaturesOptionService)
            :base(componentFeaturesOptionService)
        {
            _componentFeaturesOptionService = componentFeaturesOptionService;
        }

        public IEnumerable<ComponentFeaturesOption> GetAllByUserId(string userId)
        {
            return _componentFeaturesOptionService.GetAllByUserId(userId);
        }

        public ComponentFeaturesOption GetById(Guid id, string userId)
        {
            return _componentFeaturesOptionService.GetById(id, userId);
        }

        public ComponentFeaturesOption GetDefault(string userId)
        {
            return _componentFeaturesOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentFeaturesOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentFeaturesOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentFeaturesOption> GetByIdAsync(Guid id)
        {
            return await _componentFeaturesOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentFeaturesOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentFeaturesOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentFeaturesOption> GetDefaultAsync(string userId)
        {
            return await _componentFeaturesOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string title, string count, string description, string userId)
        {
            JsonResponse json = new JsonResponse();

            var featuresOption = await _componentFeaturesOptionService.GetDefaultAsync(userId);
            if (featuresOption != null)
            {
                featuresOption.Change(featuresOption.Default, title, count, description);
                _componentFeaturesOptionService.Update(featuresOption);
            }

            return json;
        }
    }
}
