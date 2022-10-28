using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentPricingOptionAppService : AppServiceBaseT2<ComponentPricingOption>, IComponentPricingOptionAppService
    {
        private readonly IComponentPricingOptionService _componentPricingOptionService;

        public ComponentPricingOptionAppService(IComponentPricingOptionService componentPricingOptionService)
            :base(componentPricingOptionService)
        {
            _componentPricingOptionService = componentPricingOptionService;
        }

        public IEnumerable<ComponentPricingOption> GetAllByUserId(string userId)
        {
            return _componentPricingOptionService.GetAllByUserId(userId);
        }

        public ComponentPricingOption GetById(Guid id, string userId)
        {
            return _componentPricingOptionService.GetById(id, userId);
        }

        public ComponentPricingOption GetDefault(string userId)
        {
            return _componentPricingOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentPricingOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPricingOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPricingOption> GetByIdAsync(Guid id)
        {
            return await _componentPricingOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentPricingOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPricingOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPricingOption> GetDefaultAsync(string userId)
        {
            return await _componentPricingOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string nomePlano, string moeda, string priceUnid, string priceCent, string periodo, string description, string comment, string textButton, string price, string userId)
        {
            JsonResponse json = new JsonResponse();

            var pricingtOption = await _componentPricingOptionService.GetDefaultAsync(userId);
            if (pricingtOption != null)
            {
                pricingtOption.Change(pricingtOption.Default, nomePlano, moeda, priceUnid, priceCent, periodo, description, comment, textButton, price);     
                _componentPricingOptionService.Update(pricingtOption);
            }

            return json;
        }
    }
}
