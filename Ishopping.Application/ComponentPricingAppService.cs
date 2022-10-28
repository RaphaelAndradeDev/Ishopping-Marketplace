using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;
using Ishopping.Application.Common;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentPricingAppService : AppServiceBaseT2<ComponentPricing>, IComponentPricingAppService
    {
        private readonly IComponentPricingService _componentPricingService;
        private readonly IComponentPricingOptionService _componentPricingOptionService;

        public ComponentPricingAppService(
            IComponentPricingService componentPricingService,
            IComponentPricingOptionService componentPricingOptionService)
            :base(componentPricingService)
        {
            _componentPricingService = componentPricingService;
            _componentPricingOptionService = componentPricingOptionService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentPricingService.Search(startsWith, userId);
        }

        public IEnumerable<ComponentPricing> GetAllBySiteNumber(int siteNumber)
        {
            return _componentPricingService.GetAllBySiteNumber(siteNumber);
        }
             
        public ComponentPricing GetBySiteNumber(int siteNumber)
        {
            return _componentPricingService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPricing> GetAllByUserId(string userId)
        {
            return _componentPricingService.GetAllByUserId(userId);
        }

        public ComponentPricing GetById(Guid id, string userId)
        {
            return _componentPricingService.GetById(id, userId);
        }

        public ComponentPricing GetByTerm(string title, string userId)
        {
            return _componentPricingService.GetByTerm(title, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentPricingService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentPricing> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentPricingService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPricing>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentPricingService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPricing>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPricingService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPricing> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPricingService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPricing> GetByTermAsync(string term, string userId)
        {
            return await _componentPricingService.GetByTermAsync(term, userId);
        }


        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentPricingOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, comment = obj.Comment, description = obj.Description, moeda = obj.Moeda, nomePlano = obj.NomePlano, periodo = obj.Periodo, price = obj.Price, priceCent = obj.PriceCent, priceUnid = obj.PriceUnid, textButton = obj.TextButton };
            }
            else
            {
                return new JsonFileNotFound();
            } 
        }

        public async Task<object> GetObjetoAsync(string search, string userId)
        {
            var obj = await _componentPricingService.GetByTermAsync(search, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, comment = obj._Comment, description = obj._Description, nomePlano = obj._NomePlano, destacar = obj.Destacar, moeda = obj.Moeda, periodo = obj.Periodo, price = obj.Price, priceCent = obj.PriceCent, priceUnid = obj.PriceUnid, textButton = obj.TextButton, stComment = obj.ComponentPricingOption.Comment, stDescription = obj.ComponentPricingOption.Description, stMoeda = obj.ComponentPricingOption.Moeda, stNomePlano = obj.ComponentPricingOption.NomePlano, stPeriodo = obj.ComponentPricingOption.Periodo, stPrice = obj.ComponentPricingOption.Price, stPriceCent = obj.ComponentPricingOption.PriceCent, stPriceUnid = obj.ComponentPricingOption.PriceUnid, stTextButton = obj.ComponentPricingOption.TextButton };
            }
            else
            {
                return new JsonFileNotFound();
            } 
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, bool destacar, string name, string styleName, string moeda, string styleMoeda, string priceU, string stylePriceU, string priceC, string stylePriceC, string periodo, string stylePeriodo, string description, string styleDescription, string comment, string styleComment, string textButton, string styleTextButton, string urlButton)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var pricingOption = await _componentPricingOptionService.PutAsync(styleName, styleMoeda, stylePriceU, stylePriceC, stylePeriodo, styleDescription, styleComment, styleTextButton, stylePriceU, userId);

            if (_id != Guid.Empty)
            {
                var pricing = await _componentPricingService.GetByIdAsync(_id, userId);
                pricing.Change(name, priceU, priceC, periodo, description, comment, textButton, urlButton, moeda, destacar);

                if(pricingOption.Id == Guid.Empty)
                {
                    if(pricing.ComponentPricingOption.Default)
                    {
                        pricing.AddComponentPricingOption(pricingOption);
                    }
                    else
                    {
                        pricing.ComponentPricingOption.Change(false, styleName, styleMoeda, stylePriceU, stylePriceC, stylePeriodo, styleDescription, styleComment, styleTextButton, stylePriceU);
                    }
                    _componentPricingService.Update(pricing);
                }
                else
                {
                    var optionOld = pricing.ComponentPricingOptionId;
                    bool optionDefault = pricing.ComponentPricingOption.Default;

                    pricing.ChangeComponentPricingOption(pricingOption.Id);
                    _componentPricingService.Update(pricing);

                    if (!optionDefault)
                    {
                        var obj = await _componentPricingOptionService.GetByIdAsync(optionOld);
                        _componentPricingOptionService.Remove(obj);
                    } 
                }
                json.Id = pricing.Id.ToString();
                return json;
            }
            else
            {
                if(pricingOption.Id == Guid.Empty)
                {
                    var pricing = new ComponentPricing(userId, siteNumber, pricingOption, name, priceU, priceC, periodo, description, comment, textButton, urlButton, moeda, destacar);
                    _componentPricingService.Add(pricing);
                    json.Id = pricing.Id.ToString();
                    return json;
                }
                else
                {
                    var pricing = new ComponentPricing(userId, siteNumber, pricingOption.Id, name, priceU, priceC, periodo, description, comment, textButton, urlButton, moeda, destacar);
                    _componentPricingService.Add(pricing);
                    json.Id = pricing.Id.ToString();
                    return json;
                }                           
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var pricing = await _componentPricingService.GetByIdAsync(_id, userId);

            if (pricing != null)
            {
                var optionOld = pricing.ComponentPricingOptionId;
                bool optionDefault = pricing.ComponentPricingOption.Default;

                _componentPricingService.Remove(pricing);

                if (!optionDefault)
                {
                    var obj = _componentPricingOptionService.GetById(optionOld);
                    _componentPricingOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(pricing.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentPricingService.DeleteAll(userId);
        }
    }
}
