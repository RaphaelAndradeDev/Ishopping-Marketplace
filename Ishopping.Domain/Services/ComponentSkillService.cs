using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentSkillService : ServiceBaseT2<ComponentSkill>, IComponentSkillService
    {
        private readonly IComponentSkillRepository _componentSkillRepository;
        private readonly IComponentSkillDapperRepository _componentSkillDapperRepository;

        public ComponentSkillService(
            IComponentSkillRepository componentSkillRepository,
            IComponentSkillDapperRepository componentSkillDapperRepository)
            : base(componentSkillRepository)
        {
            _componentSkillRepository = componentSkillRepository;
            _componentSkillDapperRepository = componentSkillDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentSkillRepository.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentSkill> GetAllBySiteNumber(int siteNumber)
        {
            return _componentSkillDapperRepository.GetAllBySiteNumber(siteNumber);
        }

        public ComponentSkill Get(string title, int position, string userId)
        {
            return _componentSkillRepository.GetBy(title, position, userId);
        }

        public ComponentSkill GetBySiteNumber(int siteNumber)
        {
            return _componentSkillRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentSkill> GetAllByUserId(string userId)
        {
            return _componentSkillRepository.GetAllByUserId(userId);
        }

        public ComponentSkill GetById(Guid id, string userId)
        {
            return _componentSkillRepository.GetById(id, userId);
        }

        public ComponentSkill GetBy(string title, int position, string userId)
        {
            return _componentSkillRepository.GetBy(title, position, userId);
        }              

        public void DeleteAll(string userId)
        {
            _componentSkillRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentSkillRepository.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentSkill> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentSkillRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSkill>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentSkillDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSkill>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSkillRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSkill> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSkillRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSkill> GetByAsync(string search, int position, string userId)
        {
            return await _componentSkillRepository.GetByAsync(search, position, userId);
        }
 

    }
}
