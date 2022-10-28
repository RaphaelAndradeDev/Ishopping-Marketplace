using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentFeaturesService : ServiceBaseT2<ComponentFeatures>, IComponentFeaturesService
    {
        private readonly IComponentFeaturesRepository _componentFeaturesRepository;
        private readonly IComponentFeaturesDapperRepository _componentFeaturesDapperRepository;

        public ComponentFeaturesService(
            IComponentFeaturesRepository componentFeaturesRepository,
            IComponentFeaturesDapperRepository componentFeaturesDapperRepository)
            : base(componentFeaturesRepository)
        {
            _componentFeaturesRepository = componentFeaturesRepository;
            _componentFeaturesDapperRepository = componentFeaturesDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentFeaturesRepository.Search(startsWith, userId);
        }

        public IEnumerable<ComponentFeatures> GetAllBySiteNumber(int siteNumber)
        {
            return _componentFeaturesDapperRepository.GetAllBySiteNumber(siteNumber);
        }       

        public ComponentFeatures GetBySiteNumber(int siteNumber)
        {
            return _componentFeaturesRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentFeatures> GetAllByUserId(string userId)
        {
            return _componentFeaturesRepository.GetAllByUserId(userId);
        }

        public ComponentFeatures GetById(Guid id, string userId)
        {
            return _componentFeaturesRepository.GetById(id, userId);
        }

        public ComponentFeatures GetByTerm(string title, string userId)
        {
            return _componentFeaturesRepository.GetByTerm(title, userId);
        }

        public void DeleteAll(string userId)
        {
            _componentFeaturesRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentFeaturesRepository.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentFeatures> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentFeaturesRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentFeatures>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentFeaturesDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentFeatures>> GetAllByUserIdAsync(string userId)
        {
            return await _componentFeaturesRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentFeatures> GetByIdAsync(Guid id, string userId)
        {
            return await _componentFeaturesRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentFeatures> GetByTermAsync(string term, string userId)
        {
            return await _componentFeaturesRepository.GetByTermAsync(term, userId);
        }  

    }
}
