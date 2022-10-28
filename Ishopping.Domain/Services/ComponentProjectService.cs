using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentProjectService : ServiceBaseT2<ComponentProject>, IComponentProjectService
    {
        private readonly IComponentProjectRepository _componentProjectRepository;
        private readonly IComponentProjectDapperRepository _componentProjectDapperRepository;

        public ComponentProjectService(
            IComponentProjectRepository componentProjectRepository,
            IComponentProjectDapperRepository componentProjectDapperRepository)
            : base(componentProjectRepository)
        {
            _componentProjectRepository = componentProjectRepository;
            _componentProjectDapperRepository = componentProjectDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentProjectRepository.Search(startsWith, userId);
        }

        public ComponentProject GetByImageId(Guid imageId)
        {
            return _componentProjectRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentProject> GetAllBySiteNumber(int siteNumber)
        {
            return _componentProjectRepository.GetAllBySiteNumber(siteNumber);
        }

        public ComponentProject GetBySiteNumber(int siteNumber)
        {
            return _componentProjectRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentProject> GetAllByUserId(string userId)
        {
            return _componentProjectRepository.GetAllByUserId(userId);
        }

        public ComponentProject GetById(Guid id, string userId)
        {
            return _componentProjectRepository.GetById(id, userId);
        }

        public ComponentProject GetByTerm(string term, string userId)
        {
            return _componentProjectRepository.GetByTerm(term, userId);
        }    

        public void DeleteAll(string userId)
        {
            _componentProjectRepository.DeleteAll(userId);
        }
        
        public void AddBy(ComponentProject componentProject)
        {
            _componentProjectRepository.AddBy(componentProject);
        }

        public void UpdateBy(ComponentProject componentProject)
        {
            _componentProjectRepository.UpdateBy(componentProject);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentProjectRepository.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentProject> GetByImageIdAsync(Guid imageId)
        {
            return await _componentProjectRepository.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentProject> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentProjectRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentProject>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentProjectRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentProject>> GetAllByUserIdAsync(string userId)
        {
            return await _componentProjectRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentProject> GetByIdAsync(Guid id, string userId)
        {
            return await _componentProjectRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentProject> GetByTermAsync(string term, string userId)
        {
            return await _componentProjectRepository.GetByTermAsync(term, userId);
        }  

    }
}
