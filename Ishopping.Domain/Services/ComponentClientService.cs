using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentClientService : ServiceBaseT2<ComponentClient>, IComponentClientService
    {
        private readonly IComponentClientRepository _componentClientRepository;
        private readonly IComponentClientDapperRepository _componentClientDapperRepository;

        public ComponentClientService(
            IComponentClientRepository componentClientRepository,
            IComponentClientDapperRepository componentClientDapperRepository)
            : base(componentClientRepository)
        {
            _componentClientRepository = componentClientRepository;
            _componentClientDapperRepository = componentClientDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentClientRepository.Search(startsWith, userId);
        }

        public ComponentClient GetByImageId(Guid imageId)
        {
            return _componentClientRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentClient> GetAllBySiteNumber(int siteNumber)
        {
            return _componentClientDapperRepository.GetAllBySiteNumber(siteNumber);
        }              
      
        public ComponentClient GetBySiteNumber(int siteNumber)
        {
            return _componentClientRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentClient> GetAllByUserId(string userId)
        {
            return _componentClientRepository.GetAllByUserId(userId);
        }

        public ComponentClient GetById(Guid id, string userId)
        {
            return _componentClientRepository.GetById(id, userId);
        }

        public ComponentClient GetByTerm(string title, string userId)
        {
            return _componentClientRepository.GetByTerm(title, userId);
        }   

        public void DeleteAll(string userId)
        {
            _componentClientRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentClientRepository.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentClient> GetByImageIdAsync(Guid imageId)
        {
            return await _componentClientRepository.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentClient> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentClientRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentClient>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentClientDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentClient>> GetAllByUserIdAsync(string userId)
        {
            return await _componentClientRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentClient> GetByIdAsync(Guid id, string userId)
        {
            return await _componentClientRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentClient> GetByTermAsync(string term, string userId)
        {
            return await _componentClientRepository.GetByTermAsync(term, userId);
        }  

    }
}
