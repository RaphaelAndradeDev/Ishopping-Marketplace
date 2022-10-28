using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentSkillOptionAppService : AppServiceBaseT2<ComponentSkillOption>, IComponentSkillOptionAppService
    {
        private readonly IComponentSkillOptionService _componentSkillOptionService;

        public ComponentSkillOptionAppService(IComponentSkillOptionService componentSkillOptionService)
            :base(componentSkillOptionService)
        {
            _componentSkillOptionService = componentSkillOptionService;
        }

        public IEnumerable<ComponentSkillOption> GetAllByUserId(string userId)
        {
            return _componentSkillOptionService.GetAllByUserId(userId);
        }

        public ComponentSkillOption GetById(Guid id, string userId)
        {
            return _componentSkillOptionService.GetById(id, userId);
        }

        public ComponentSkillOption GetDefault(string userId)
        {
            return _componentSkillOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentSkillOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSkillOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSkillOption> GetByIdAsync(Guid id)
        {
            return await _componentSkillOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentSkillOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSkillOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSkillOption> GetDefaultAsync(string userId)
        {
            return await _componentSkillOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string category, string description, string level, string userId)
        {
            JsonResponse json = new JsonResponse();

            var skillOption = await _componentSkillOptionService.GetDefaultAsync(userId);
            if (skillOption != null)
            {
                skillOption.Change(skillOption.Default, category, description, level);
                _componentSkillOptionService.Update(skillOption);
            }

            return json;
        }

    }
}
