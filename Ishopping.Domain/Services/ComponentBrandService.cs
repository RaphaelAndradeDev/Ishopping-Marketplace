using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentBrandService : ServiceBaseT2<ComponentBrand>, IComponentBrandService
    {
        private readonly IComponentBrandRepository _componentBrandRepository;
        private readonly IComponentBrandDapperRepository _componentBrandDapperRepository;

        public ComponentBrandService(
            IComponentBrandRepository componentBrandRepository,
            IComponentBrandDapperRepository componentBrandDapperRepository)
            : base(componentBrandRepository)
        {
            _componentBrandRepository = componentBrandRepository;
            _componentBrandDapperRepository = componentBrandDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentBrandRepository.Search(startsWith, userId);
        }

        public ComponentBrand GetByImageId(Guid imageId)
        {
            return _componentBrandRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentBrand> GetAllBySiteNumber(int siteNumber)
        {
            return _componentBrandDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public ComponentBrand GetBySiteNumber(int siteNumber)
        {
            return _componentBrandRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentBrand> GetAllByUserId(string userId)
        {
            return _componentBrandRepository.GetAllByUserId(userId);
        }

        public ComponentBrand GetById(Guid id, string userId)
        {
            return _componentBrandRepository.GetById(id, userId);
        }

        public ComponentBrand GetByTerm(string title, string userId)
        {
            return _componentBrandRepository.GetByTerm(title, userId);
        }

        public void DeleteAll(string userId)
        {
            _componentBrandRepository.DeleteAll(userId);
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentBrandRepository.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentBrand> GetByImageIdAsync(Guid imageId)
        {
            return await _componentBrandRepository.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentBrand> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentBrandRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentBrand>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentBrandDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentBrand>> GetAllByUserIdAsync(string userId)
        {
            return await _componentBrandRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentBrand> GetByIdAsync(Guid id, string userId)
        {
            return await _componentBrandRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentBrand> GetByTermAsync(string term, string userId)
        {
            return await _componentBrandRepository.GetByTermAsync(term, userId);
        }                
      
    }
}
