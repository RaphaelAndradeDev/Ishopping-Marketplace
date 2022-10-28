using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentServiceService : ServiceBaseT2<ComponentService>, IComponentServiceService
    {
        private readonly IComponentServiceRepository _componentServiceRepository;
        private readonly IComponentServiceDapperRepository _componentServiceDapperRepository;

        public ComponentServiceService(
            IComponentServiceRepository componentServiceRepository,
            IComponentServiceDapperRepository componentServiceDapperRepository)
            : base(componentServiceRepository)
        {
            _componentServiceRepository = componentServiceRepository;
            _componentServiceDapperRepository = componentServiceDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentServiceRepository.Search(startsWith, position, userId);
        }

        public ComponentService GetByImageId(Guid imageId)
        {
            return _componentServiceRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentService> GetAllBySiteNumber(int siteNumber)
        {
            return _componentServiceDapperRepository.GetAllBySiteNumber(siteNumber);
        }
        
        public ComponentService GetBySiteNumber(int siteNumber)
        {
            return _componentServiceRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentService> GetAllByUserId(string userId)
        {
            return _componentServiceRepository.GetAllByUserId(userId);
        }

        public ComponentService GetById(Guid id, string userId)
        {
            return _componentServiceRepository.GetById(id, userId);
        }

        public ComponentService GetBy(string title, int position, string userId)
        {
            return _componentServiceRepository.GetBy(title, position, userId);
        }    

        public void DeleteAll(string userId)
        {
            _componentServiceRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentServiceRepository.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentService> GetByImageIdAsync(Guid imageId)
        {
            return await _componentServiceRepository.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentService> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentServiceRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentService>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentServiceDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentService>> GetAllByUserIdAsync(string userId)
        {
            return await _componentServiceRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentService> GetByIdAsync(Guid id, string userId)
        {
            return await _componentServiceRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentService> GetByAsync(string search, int position, string userId)
        {
            return await _componentServiceRepository.GetByAsync(search, position, userId);
        }

    }
}
