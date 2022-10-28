using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentTeamOptionAppService : AppServiceBaseT2<ComponentTeamOption>, IComponentTeamOptionAppService
    {
        private readonly IComponentTeamOptionService _componentTeamOptionService;

        public ComponentTeamOptionAppService(IComponentTeamOptionService componentTeamOptionService)
            :base(componentTeamOptionService)
        {
            _componentTeamOptionService = componentTeamOptionService;
        }

        public IEnumerable<ComponentTeamOption> GetAllByUserId(string userId)
        {
            return _componentTeamOptionService.GetAllByUserId(userId);
        }

        public ComponentTeamOption GetById(Guid id, string userId)
        {
            return _componentTeamOptionService.GetById(id, userId);
        }

        public ComponentTeamOption GetDefault(string userId)
        {
            return _componentTeamOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentTeamOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentTeamOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentTeamOption> GetByIdAsync(Guid id)
        {
            return await _componentTeamOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentTeamOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentTeamOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentTeamOption> GetDefaultAsync(string userId)
        {
            return await _componentTeamOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string name, string functio, string description, string userId)
        {
            JsonResponse json = new JsonResponse();

            var teamOption = await _componentTeamOptionService.GetDefaultAsync(userId);
            if (teamOption != null)
            {
                teamOption.Change(teamOption.Default, name, functio, description);
                _componentTeamOptionService.Update(teamOption);
            }

            return json;
        }
    }
}
