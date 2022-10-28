using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentPresentationOptionAppService : AppServiceBaseT2<ComponentPresentationOption>, IComponentPresentationOptionAppService
    {
        private readonly IComponentPresentationOptionService _componentPresentationOptionService;

        public ComponentPresentationOptionAppService(IComponentPresentationOptionService componentPresentationOptionService)
            :base(componentPresentationOptionService)
        {
            _componentPresentationOptionService = componentPresentationOptionService;
        }

        public IEnumerable<ComponentPresentationOption> GetAllByUserId(string userId)
        {
            return _componentPresentationOptionService.GetAllByUserId(userId);
        }

        public ComponentPresentationOption GetById(Guid id, string userId)
        {
            return _componentPresentationOptionService.GetById(id, userId);
        }

        public ComponentPresentationOption GetDefault(string userId)
        {
            return _componentPresentationOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentPresentationOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPresentationOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPresentationOption> GetByIdAsync(Guid id)
        {
            return await _componentPresentationOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentPresentationOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPresentationOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPresentationOption> GetDefaultAsync(string userId)
        {
            return await _componentPresentationOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string title, string category, string description, string userId)
        {
            JsonResponse json = new JsonResponse();

            var presentationOption = await _componentPresentationOptionService.GetDefaultAsync(userId);
            if (presentationOption != null)
            {
                presentationOption.Change(presentationOption.Default, title, category, description);         
                _componentPresentationOptionService.Update(presentationOption);
            }

            return json;
        }
    }
}
