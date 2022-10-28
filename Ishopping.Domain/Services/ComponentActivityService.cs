using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentActivityService : ServiceBaseT2<ComponentActivity>, IComponentActivityService
    {
        private readonly IComponentActivityRepository _componentActivityRepository;
        private readonly IComponentActivityDapperRepository _componentActivityDapperRepository;

        public ComponentActivityService(
            IComponentActivityRepository componentActivityRepository,
            IComponentActivityDapperRepository componentActivityDapperRepository)
            : base(componentActivityRepository)
        {
            _componentActivityRepository = componentActivityRepository;
            _componentActivityDapperRepository = componentActivityDapperRepository;
        }

        // Sync Methods
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {     
            return _componentActivityRepository.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentActivity> GetAllBySiteNumber(int siteNumber)
        {
            return _componentActivityDapperRepository.GetAllBySiteNumber(siteNumber);
        }          

        public ComponentActivity GetBySiteNumber(int siteNumber)
        {
            return _componentActivityRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentActivity> GetAllByUserId(string userId)
        {
            return _componentActivityRepository.GetAllByUserId(userId);
        }

        public ComponentActivity GetById(Guid id, string userId)
        {
            return _componentActivityRepository.GetById(id, userId);
        }

        public ComponentActivity GetBy(string title, int position, string userId)
        {
            return _componentActivityRepository.GetBy(title, position, userId);
        }      

        public void DeleteAll(string userId)
        {
            _componentActivityRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentActivityRepository.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentActivity> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentActivityRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentActivity>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentActivityDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentActivity>> GetAllByUserIdAsync(string userId)
        {
            return await _componentActivityRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentActivity> GetByIdAsync(Guid id, string userId)
        {
            return await _componentActivityRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentActivity> GetByAsync(string search, int position, string userId)
        {
            return await _componentActivityRepository.GetByAsync(search, position, userId);
        }
    }
}
