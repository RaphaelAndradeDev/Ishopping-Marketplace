using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentProjectOptionAppService : AppServiceBaseT2<ComponentProjectOption>, IComponentProjectOptionAppService
    {
        private readonly IComponentProjectOptionService _componentProjectOptionService;

        public ComponentProjectOptionAppService(IComponentProjectOptionService componentProjectOptionService)
            :base(componentProjectOptionService)
        {
            _componentProjectOptionService = componentProjectOptionService;
        }

        public IEnumerable<ComponentProjectOption> GetAllByUserId(string userId)
        {
            return _componentProjectOptionService.GetAllByUserId(userId);
        }

        public ComponentProjectOption GetById(Guid id, string userId)
        {
            return _componentProjectOptionService.GetById(id, userId);
        }

        public ComponentProjectOption GetDefault(string userId)
        {
            return _componentProjectOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentProjectOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentProjectOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentProjectOption> GetByIdAsync(Guid id)
        {
            return await _componentProjectOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentProjectOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentProjectOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentProjectOption> GetDefaultAsync(string userId)
        {
            return await _componentProjectOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string name, string title, string client, string description, string category, string team, string userId)
        {
            JsonResponse json = new JsonResponse();

            var projectOption = await _componentProjectOptionService.GetDefaultAsync(userId);
            if (projectOption != null)
            {
                projectOption.Change(projectOption.Default, name, title, client, description, category, team);
                _componentProjectOptionService.Update(projectOption);
            }

            return json;
        }
    }
}
