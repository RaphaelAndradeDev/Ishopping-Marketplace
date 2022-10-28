using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentPanelOptionAppService : AppServiceBaseT2<ComponentPanelOption>, IComponentPanelOptionAppService
    {
        private readonly IComponentPanelOptionService _componentPanelOptionService;

        public ComponentPanelOptionAppService(IComponentPanelOptionService componentPanelOptionService)
            :base(componentPanelOptionService)
        {
            _componentPanelOptionService = componentPanelOptionService;
        }

        public IEnumerable<ComponentPanelOption> GetAllByUserId(string userId)
        {
            return _componentPanelOptionService.GetAllByUserId(userId);
        }

        public ComponentPanelOption GetById(Guid id, string userId)
        {
            return _componentPanelOptionService.GetById(id, userId);
        }

        public ComponentPanelOption GetDefault(string userId)
        {
            return _componentPanelOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentPanelOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPanelOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPanelOption> GetByIdAsync(Guid id)
        {
            return await _componentPanelOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentPanelOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPanelOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPanelOption> GetDefaultAsync(string userId)
        {
            return await _componentPanelOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string title, string text, string userId)
        {
            JsonResponse json = new JsonResponse();

            var panelOption = await _componentPanelOptionService.GetDefaultAsync(userId);
            if (panelOption != null)
            {
                panelOption.Change(panelOption.Default, title, text);
                _componentPanelOptionService.Update(panelOption);
            }

            return json;
        }
    }
}
