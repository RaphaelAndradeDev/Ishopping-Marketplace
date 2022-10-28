using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentSimpleProductOptionAppService : AppServiceBaseT2<ComponentSimpleProductOption>, IComponentSimpleProductOptionAppService
    {
        private readonly IComponentSimpleProductOptionService _componentSimpleProductOptionService;

        public ComponentSimpleProductOptionAppService(IComponentSimpleProductOptionService componentSimpleProductOptionService)
            :base(componentSimpleProductOptionService)
        {
            _componentSimpleProductOptionService = componentSimpleProductOptionService;
        }

        public IEnumerable<ComponentSimpleProductOption> GetAllByUserId(string userId)
        {
            return _componentSimpleProductOptionService.GetAllByUserId(userId);
        }

        public ComponentSimpleProductOption GetById(Guid id, string userId)
        {
            return _componentSimpleProductOptionService.GetById(id, userId);
        }

        public ComponentSimpleProductOption GetDefault(string userId)
        {
            return _componentSimpleProductOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentSimpleProductOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSimpleProductOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSimpleProductOption> GetByIdAsync(Guid id)
        {
            return await _componentSimpleProductOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentSimpleProductOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSimpleProductOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSimpleProductOption> GetDefaultAsync(string userId)
        {
            return await _componentSimpleProductOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string name, string category, string brand, string model, string description, string price, string userId)
        {
            JsonResponse json = new JsonResponse();

            var productOption = await _componentSimpleProductOptionService.GetDefaultAsync(userId);
            if (productOption != null)
            {
                productOption.Change(productOption.Default, name, category, brand, model, description, price);
                _componentSimpleProductOptionService.Update(productOption);
            }

            return json;
        }

    }
}
