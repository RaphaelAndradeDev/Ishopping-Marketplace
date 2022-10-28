using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentSocialNetworkService : ServiceBaseT2<ComponentSocialNetwork>, IComponentSocialNetworkService
    {
        private readonly IComponentSocialNetworkRepository _componentSocialNetworkRepository;
        private readonly IComponentSocialNetworkDapperRepository _componentSocialNetworkDapperRepository;

        public ComponentSocialNetworkService(
            IComponentSocialNetworkRepository componentSocialNetworkRepository,
            IComponentSocialNetworkDapperRepository componentSocialNetworkDapperRepository)
            : base(componentSocialNetworkRepository)
        {
            _componentSocialNetworkRepository = componentSocialNetworkRepository;
            _componentSocialNetworkDapperRepository = componentSocialNetworkDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentSocialNetworkRepository.Search(startsWith, userId);
        }

        public IEnumerable<ComponentSocialNetwork> GetAllBySiteNumber(int siteNumber)
        {
            return _componentSocialNetworkDapperRepository.GetAllBySiteNumber(siteNumber);
        }
        
        public ComponentSocialNetwork GetBySiteNumber(int siteNumber)
        {
            return _componentSocialNetworkRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentSocialNetwork> GetAllByUserId(string userId)
        {
            return _componentSocialNetworkRepository.GetAllByUserId(userId);
        }

        public ComponentSocialNetwork GetById(Guid id, string userId)
        {
            return _componentSocialNetworkRepository.GetById(id, userId);
        }

        public ComponentSocialNetwork GetByTerm(string term, string userId)
        {
            return _componentSocialNetworkRepository.GetByTerm(term, userId);
        }    

        public void DeleteAll(string userId)
        {
            _componentSocialNetworkRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentSocialNetworkRepository.SearchAsync(startsWith, userId);
        }        

        public async Task<ComponentSocialNetwork> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentSocialNetworkRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSocialNetwork>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentSocialNetworkDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSocialNetwork>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSocialNetworkRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSocialNetwork> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSocialNetworkRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSocialNetwork> GetByTermAsync(string term, string userId)
        {
            return await _componentSocialNetworkRepository.GetByTermAsync(term, userId);
        }  

    }
}
