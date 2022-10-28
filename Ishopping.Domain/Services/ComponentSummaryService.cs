using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentSummaryService : ServiceBaseT2<ComponentSummary>, IComponentSummaryService
    {
        private readonly IComponentSummaryRepository _componentSummaryRepository;
        private readonly IComponentSummaryDapperRepository _componentSummaryDapperRepository;

        public ComponentSummaryService(
            IComponentSummaryRepository componentSummaryRepository,
            IComponentSummaryDapperRepository componentSummaryDapperRepository)
            : base(componentSummaryRepository)
        {
            _componentSummaryRepository = componentSummaryRepository;
            _componentSummaryDapperRepository = componentSummaryDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentSummaryRepository.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentSummary> GetAllBySiteNumber(int siteNumber)
        {
            return _componentSummaryDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public ComponentSummary GetBySiteNumber(int siteNumber)
        {
            return _componentSummaryRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentSummary> GetAllByUserId(string userId)
        {
            return _componentSummaryRepository.GetAllByUserId(userId);
        }

        public ComponentSummary GetById(Guid id, string userId)
        {
            return _componentSummaryRepository.GetById(id, userId);
        }

        public ComponentSummary GetBy(string title, int position, string userId)
        {
            return _componentSummaryRepository.GetBy(title, position, userId);
        }      

        public void DeleteAll(string userId)
        {
            _componentSummaryRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentSummaryRepository.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentSummary> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentSummaryRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSummary>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentSummaryDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSummary>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSummaryRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSummary> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSummaryRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSummary> GetByAsync(string search, int position, string userId)
        {
            return await _componentSummaryRepository.GetByAsync(search, position, userId);
        }

    }
}
