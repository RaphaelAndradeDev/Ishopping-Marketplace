using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentPanelService : ServiceBaseT2<ComponentPanel>, IComponentPanelService
    {
        private readonly IComponentPanelRepository _componentPanelRepository;
        private readonly IComponentPanelDapperRepository _componentPanelDapperRepository;

        public ComponentPanelService(
            IComponentPanelRepository componentPanelRepository,
            IComponentPanelDapperRepository componentPanelDapperRepository)
            : base(componentPanelRepository)
        {
            _componentPanelRepository = componentPanelRepository;
            _componentPanelDapperRepository = componentPanelDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentPanelRepository.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentPanel> GetAllBySiteNumber(int siteNumber)
        {
            return _componentPanelDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public ComponentPanel GetBySiteNumber(int siteNumber)
        {
            return _componentPanelRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPanel> GetAllByUserId(string userId)
        {
            return _componentPanelRepository.GetAllByUserId(userId);
        }

        public ComponentPanel GetById(Guid id, string userId)
        {
            return _componentPanelRepository.GetById(id, userId);
        }

        public ComponentPanel GetBy(string title, int position, string userId)
        {
            return _componentPanelRepository.GetBy(title, position, userId);
        }

        public void DeleteAll(string userId)
        {
            _componentPanelRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentPanelRepository.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentPanel> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentPanelRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPanel>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentPanelDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPanel>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPanelRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPanel> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPanelRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPanel> GetByAsync(string search, int position, string userId)
        {
            return await _componentPanelRepository.GetByAsync(search, position, userId);
        }

    }
}
