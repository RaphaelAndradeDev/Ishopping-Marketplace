using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentPresentationService : ServiceBaseT2<ComponentPresentation>, IComponentPresentationService
    {
        private readonly IComponentPresentationRepository _componentPresentationRepository;
        private readonly IComponentPresentationDapperRepository _componentPresentationDapperRepository;

        public ComponentPresentationService(
            IComponentPresentationRepository componentPresentationRepository,
            IComponentPresentationDapperRepository componentPresentationDapperRepository)
            : base(componentPresentationRepository)
        {
            _componentPresentationRepository = componentPresentationRepository;
            _componentPresentationDapperRepository = componentPresentationDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentPresentationRepository.Search(startsWith, position, userId);
        }

        public ComponentPresentation GetByImageId(Guid imageId)
        {
            return _componentPresentationRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentPresentation> GetAllBySiteNumber(int siteNumber)
        {
            return _componentPresentationDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public ComponentPresentation GetBySiteNumber(int siteNumber)
        {
            return _componentPresentationRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPresentation> GetAllByUserId(string userId)
        {
            return _componentPresentationRepository.GetAllByUserId(userId);
        }

        public ComponentPresentation GetById(Guid id, string userId)
        {
            return _componentPresentationRepository.GetById(id, userId);
        }

        public ComponentPresentation GetBy(string title, int position, string userId)
        {
            return _componentPresentationRepository.GetBy(title, position, userId);
        }      

        public void DeleteAll(string userId)
        {
            _componentPresentationRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentPresentationRepository.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentPresentation> GetByImageIdAsync(Guid imageId)
        {
            return await _componentPresentationRepository.GetByImageIdAsync(imageId);
        }
        
        public async Task<ComponentPresentation> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentPresentationRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPresentation>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentPresentationDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPresentation>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPresentationRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPresentation> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPresentationRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPresentation> GetByAsync(string search, int position, string userId)
        {
            return await _componentPresentationRepository.GetByAsync(search, position, userId);
        }

    }
}
