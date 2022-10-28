using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentScopeService : ServiceBaseT2<ComponentScope>, IComponentScopeService
    {
        private readonly IComponentScopeRepository _componentScopeRepository;
        private readonly IComponentScopeDapperRepository _componentScopeDapperRepository;

        public ComponentScopeService(
            IComponentScopeRepository componentScopeRepository,
            IComponentScopeDapperRepository componentScopeDapperRepository)
            : base(componentScopeRepository)
        {
            _componentScopeRepository = componentScopeRepository;
            _componentScopeDapperRepository = componentScopeDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentScopeRepository.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentScope> GetAllBySiteNumber(int siteNumber)
        {
            return _componentScopeDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public ComponentScope GetBySiteNumber(int siteNumber)
        {
            return _componentScopeRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentScope> GetAllByUserId(string userId)
        {
            return _componentScopeRepository.GetAllByUserId(userId);
        }

        public ComponentScope GetById(Guid id, string userId)
        {
            return _componentScopeRepository.GetById(id, userId);
        }

        public ComponentScope GetBy(string title, int position, string userId)
        {
            return _componentScopeRepository.GetBy(title, position, userId);
        }      

        public void DeleteAll(string userId)
        {
            _componentScopeRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentScopeRepository.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentScope> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentScopeRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentScope>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentScopeDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentScope>> GetAllByUserIdAsync(string userId)
        {
            return await _componentScopeRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentScope> GetByIdAsync(Guid id, string userId)
        {
            return await _componentScopeRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentScope> GetByAsync(string search, int position, string userId)
        {
            return await _componentScopeRepository.GetByAsync(search, position, userId);
        }

    }
}
