using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentExtraLinkOptionAppService : AppServiceBaseT2<ComponentExtraLinkOption>, IComponentExtraLinkOptionAppService
    {
        private readonly IComponentExtraLinkOptionService _componentExtraLinkOptionService;

        public ComponentExtraLinkOptionAppService(IComponentExtraLinkOptionService componentExtraLinkOptionService)
            :base(componentExtraLinkOptionService)
        {
            _componentExtraLinkOptionService = componentExtraLinkOptionService;
        }

        public IEnumerable<ComponentExtraLinkOption> GetAllByUserId(string userId)
        {
            return _componentExtraLinkOptionService.GetAllByUserId(userId);
        }

        public ComponentExtraLinkOption GetById(Guid id, string userId)
        {
            return _componentExtraLinkOptionService.GetById(id, userId);
        }

        public ComponentExtraLinkOption GetDefault(string userId)
        {
            return _componentExtraLinkOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentExtraLinkOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentExtraLinkOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentExtraLinkOption> GetByIdAsync(Guid id)
        {
            return await _componentExtraLinkOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentExtraLinkOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentExtraLinkOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentExtraLinkOption> GetDefaultAsync(string userId)
        {
            return await _componentExtraLinkOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string textLink, string description, string userId)
        {
            JsonResponse json = new JsonResponse();

            var extraLinkOption = await _componentExtraLinkOptionService.GetDefaultAsync(userId);
            if (extraLinkOption != null)
            {
                extraLinkOption.Change(extraLinkOption.Default, textLink, description);
                _componentExtraLinkOptionService.Update(extraLinkOption);
            }

            return json;
        }
    }
}
