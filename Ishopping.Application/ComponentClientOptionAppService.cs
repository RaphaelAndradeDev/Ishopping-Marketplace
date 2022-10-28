using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentClientOptionAppService : AppServiceBaseT2<ComponentClientOption>, IComponentClientOptionAppService
    {
        private readonly IComponentClientOptionService _componentClientOptionService;

        public ComponentClientOptionAppService(IComponentClientOptionService componentClientOptionService)
            :base(componentClientOptionService)
        {
            _componentClientOptionService = componentClientOptionService;
        }

        public IEnumerable<ComponentClientOption> GetAllByUserId(string userId)
        {
            return _componentClientOptionService.GetAllByUserId(userId);
        }

        public ComponentClientOption GetById(Guid id, string userId)
        {
            return _componentClientOptionService.GetById(id, userId);
        }

        public ComponentClientOption GetDefault(string userId)
        {
            return _componentClientOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentClientOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentClientOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentClientOption> GetByIdAsync(Guid id)
        {
            return await _componentClientOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentClientOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentClientOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentClientOption> GetDefaultAsync(string userId)
        {
            return await _componentClientOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string name, string functio, string comment, string projects, string userId)
        {
            JsonResponse json = new JsonResponse();

            var clientOption = await _componentClientOptionService.GetDefaultAsync(userId);
            if (clientOption != null)
            {
                clientOption.Change(clientOption.Default, name, functio, comment, projects);
                _componentClientOptionService.Update(clientOption);
            }

            return json;
        }
    }
}
