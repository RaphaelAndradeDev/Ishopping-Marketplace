using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentPricingService : ServiceBaseT2<ComponentPricing>, IComponentPricingService
    {
        private readonly IComponentPricingRepository _componentPricingRepository;
        private readonly IComponentPricingDapperRepository _componentPricingDapperRepository;

        public ComponentPricingService(
            IComponentPricingRepository componentPricingRepository,
            IComponentPricingDapperRepository componentPricingDapperRepository)
            : base(componentPricingRepository)
        {
            _componentPricingRepository = componentPricingRepository;
            _componentPricingDapperRepository = componentPricingDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentPricingRepository.Search(startsWith, userId);
        }

        public IEnumerable<ComponentPricing> GetAllBySiteNumber(int siteNumber)
        {
            return _componentPricingDapperRepository.GetAllBySiteNumber(siteNumber);
        }
       
        public ComponentPricing GetBySiteNumber(int siteNumber)
        {
            return _componentPricingRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPricing> GetAllByUserId(string userId)
        {
            return _componentPricingRepository.GetAllByUserId(userId);
        }

        public ComponentPricing GetById(Guid id, string userId)
        {
            return _componentPricingRepository.GetById(id, userId);
        }

        public ComponentPricing GetByTerm(string term, string userId)
        {
            return _componentPricingRepository.GetByTerm(term, userId);
        }            

        public void DeleteAll(string userId)
        {
            _componentPricingRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentPricingRepository.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentPricing> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentPricingRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPricing>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentPricingDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPricing>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPricingRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPricing> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPricingRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPricing> GetByTermAsync(string term, string userId)
        {
            return await _componentPricingRepository.GetByTermAsync(term, userId);
        }  

    }
}
