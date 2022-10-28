using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentPricingOptionService : ServiceBaseT2<ComponentPricingOption>, IComponentPricingOptionService
    {
        private readonly IComponentPricingOptionRepository _componentPricingOptionRepository;

        public ComponentPricingOptionService(IComponentPricingOptionRepository componentPricingOptionRepository)
            : base(componentPricingOptionRepository)
        {
            _componentPricingOptionRepository = componentPricingOptionRepository;
        }

        public IEnumerable<ComponentPricingOption> GetAllByUserId(string userId)
        {
            return _componentPricingOptionRepository.GetAllByUserId(userId);
        }

        public ComponentPricingOption GetById(Guid id, string userId)
        {
            return _componentPricingOptionRepository.GetById(id, userId);
        }

        public ComponentPricingOption GetDefault(string userId)
        {
            return _componentPricingOptionRepository.GetDefault(userId);
        }

        public ComponentPricingOption Put(string nomePlano, string moeda, string priceUnid, string priceCent, string periodo, string description, string comment, string textButton, string price, string userId)
        {
            var pricingOption = _componentPricingOptionRepository.GetDefault(userId);

            bool alterStyle = nomePlano != pricingOption.NomePlano || moeda != pricingOption.Moeda || priceUnid != pricingOption.PriceUnid || priceCent != pricingOption.PriceCent || periodo != pricingOption.Periodo || description != pricingOption.Description || comment != pricingOption.Comment || textButton != pricingOption.TextButton || price != pricingOption.Price;
            if (alterStyle)
            {
                return new ComponentPricingOption(userId, false, nomePlano, moeda, priceUnid, priceCent, periodo, description, comment, textButton, price);                
            }
            else
            {
                return pricingOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var pricing = GetAllByUserId(userId);

            foreach (var item in pricing)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.NomePlano, name, replace),
                    IsStyle.Rename(item.Moeda, name, replace),
                    IsStyle.Rename(item.PriceUnid, name, replace),
                    IsStyle.Rename(item.PriceUnid, name, replace),
                    IsStyle.Rename(item.Periodo, name, replace),
                    IsStyle.Rename(item.Description, name, replace),
                    IsStyle.Rename(item.Comment, name, replace),
                    IsStyle.Rename(item.TextButton, name, replace),
                    IsStyle.Rename(item.Price, name, replace)
                    );
            }
            _componentPricingOptionRepository.Update(pricing);
        }

        public void StyleRemove(string userId, string name)
        {
            var pricing = GetAllByUserId(userId);

            foreach (var item in pricing)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.NomePlano, name),
                    IsStyle.Remove(item.Moeda, name),
                    IsStyle.Remove(item.PriceUnid, name),
                    IsStyle.Remove(item.PriceUnid, name),
                    IsStyle.Remove(item.Periodo, name),
                    IsStyle.Remove(item.Description, name),
                    IsStyle.Remove(item.Comment, name),
                    IsStyle.Remove(item.TextButton, name),
                    IsStyle.Remove(item.Price, name)
                    );
            }
            _componentPricingOptionRepository.Update(pricing);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentPricingOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPricingOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPricingOption> GetByIdAsync(Guid id)
        {
            return await _componentPricingOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentPricingOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPricingOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPricingOption> GetDefaultAsync(string userId)
        {
            return await _componentPricingOptionRepository.GetDefaultAsync(userId);
        }
                
        public async Task<ComponentPricingOption> PutAsync(string nomePlano, string moeda, string priceUnid, string priceCent, string periodo, string description, string comment, string textButton, string price, string userId)
        {
            var pricingOption = await _componentPricingOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = nomePlano != pricingOption.NomePlano || moeda != pricingOption.Moeda || priceUnid != pricingOption.PriceUnid || priceCent != pricingOption.PriceCent || periodo != pricingOption.Periodo || description != pricingOption.Description || comment != pricingOption.Comment || textButton != pricingOption.TextButton || price != pricingOption.Price;
            if (alterStyle)
            {
                return new ComponentPricingOption(userId, false, nomePlano, moeda, priceUnid, priceCent, periodo, description, comment, textButton, price);
            }
            else
            {
                return pricingOption;
            }
        }
    }
}
