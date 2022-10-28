using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentExtraLinkService : ServiceBaseT2<ComponentExtraLink>, IComponentExtraLinkService
    {
        private readonly IComponentExtraLinkRepository _componentExtraLinkRepository;
        private readonly IComponentExtraLinkDapperRepository _componentExtraLinkDapperRepository;

        public ComponentExtraLinkService(
            IComponentExtraLinkRepository componentExtraLinkRepository,
            IComponentExtraLinkDapperRepository componentExtraLinkDapperRepository)
            : base(componentExtraLinkRepository)
        {
            _componentExtraLinkRepository = componentExtraLinkRepository;
            _componentExtraLinkDapperRepository = componentExtraLinkDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentExtraLinkRepository.Search(startsWith, userId);
        }

        public IEnumerable<ComponentExtraLink> GetAllBySiteNumber(int siteNumber)
        {
            return _componentExtraLinkDapperRepository.GetAllBySiteNumber(siteNumber);
        }                       

        public ComponentExtraLink GetBySiteNumber(int siteNumber)
        {
            return _componentExtraLinkRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentExtraLink> GetAllByUserId(string userId)
        {
            return _componentExtraLinkRepository.GetAllByUserId(userId);
        }

        public ComponentExtraLink GetById(Guid id, string userId)
        {
            return _componentExtraLinkRepository.GetById(id, userId);
        }

        public ComponentExtraLink GetByTerm(string term, string userId)
        {
            return _componentExtraLinkRepository.GetByTerm(term, userId);
        }    

        public void DeleteAll(string userId)
        {
            _componentExtraLinkRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentExtraLinkRepository.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentExtraLink> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentExtraLinkRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentExtraLink>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentExtraLinkDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentExtraLink>> GetAllByUserIdAsync(string userId)
        {
            return await _componentExtraLinkRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentExtraLink> GetByIdAsync(Guid id, string userId)
        {
            return await _componentExtraLinkRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentExtraLink> GetByTermAsync(string term, string userId)
        {
            return await _componentExtraLinkRepository.GetByTermAsync(term, userId);
        }  

    }
}
