using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentFaqService : ServiceBaseT2<ComponentFaq>, IComponentFaqService
    {
        private readonly IComponentFaqRepository _componentFaqRepository;
        private readonly IComponentFaqDapperRepository _componentFaqDapperRepository;

        public ComponentFaqService(
            IComponentFaqRepository componentFaqRepository,
            IComponentFaqDapperRepository componentFaqDapperRepository)
            : base(componentFaqRepository)
        {
            _componentFaqRepository = componentFaqRepository;
            _componentFaqDapperRepository = componentFaqDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentFaqRepository.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentFaq> GetAllBySiteNumber(int siteNumber)
        {
            return _componentFaqDapperRepository.GetAllBySiteNumber(siteNumber);
        }        
        
        public ComponentFaq GetBySiteNumber(int siteNumber)
        {
            return _componentFaqRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentFaq> GetAllByUserId(string userId)
        {
            return _componentFaqRepository.GetAllByUserId(userId);
        }

        public ComponentFaq GetById(Guid id, string userId)
        {
            return _componentFaqRepository.GetById(id, userId);
        }

        public ComponentFaq GetBy(string title, int position, string userId)
        {
            return _componentFaqRepository.GetBy(title, position, userId);
        }             

        public void DeleteAll(string userId)
        {
            _componentFaqRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentFaqRepository.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentFaq> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentFaqRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentFaq>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentFaqDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentFaq>> GetAllByUserIdAsync(string userId)
        {
            return await _componentFaqRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentFaq> GetByIdAsync(Guid id, string userId)
        {
            return await _componentFaqRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentFaq> GetByAsync(string search, int position, string userId)
        {
            return await _componentFaqRepository.GetByAsync(search, position, userId);
        }

    }
}
