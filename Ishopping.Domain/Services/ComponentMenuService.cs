using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentMenuService : ServiceBaseT2<ComponentMenu>, IComponentMenuService
    {
        private readonly IComponentMenuRepository _componentMenuRepository;
        private readonly IComponentMenuDapperRepository _componentMenuDapperRepository;

        public ComponentMenuService(
            IComponentMenuRepository componentMenuRepository,
            IComponentMenuDapperRepository componentMenuDapperRepository)
            : base(componentMenuRepository)
        {
            _componentMenuRepository = componentMenuRepository;
            _componentMenuDapperRepository = componentMenuDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentMenuRepository.Search(startsWith, userId);
        }

        public ComponentMenu GetByImageId(Guid imageId)
        {
            return _componentMenuRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentMenu> GetAllBySiteNumber(int siteNumber)
        {
            return _componentMenuDapperRepository.GetAllBySiteNumber(siteNumber);
        }              

        public ComponentMenu GetBySiteNumber(int siteNumber)
        {
            return _componentMenuRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentMenu> GetAllByUserId(string userId)
        {
            return _componentMenuRepository.GetAllByUserId(userId);
        }

        public ComponentMenu GetById(Guid id, string userId)
        {
            return _componentMenuRepository.GetById(id, userId);
        }

        public ComponentMenu GetByTerm(string title, string userId)
        {
            return _componentMenuRepository.GetByTerm(title, userId);
        }

        public void DeleteAll(string userId)
        {
            _componentMenuRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentMenuRepository.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentMenu> GetByImageIdAsync(Guid imageId)
        {
            return await _componentMenuRepository.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentMenu> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentMenuRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentMenu>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentMenuDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentMenu>> GetAllByUserIdAsync(string userId)
        {
            return await _componentMenuRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentMenu> GetByIdAsync(Guid id, string userId)
        {
            return await _componentMenuRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentMenu> GetByTermAsync(string term, string userId)
        {
            return await _componentMenuRepository.GetByTermAsync(term, userId);
        }  

    }
}
