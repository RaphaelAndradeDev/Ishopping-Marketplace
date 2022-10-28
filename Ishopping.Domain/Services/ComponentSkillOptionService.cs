using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentSkillOptionService : ServiceBaseT2<ComponentSkillOption>, IComponentSkillOptionService
    {
        private readonly IComponentSkillOptionRepository _componentSkillOptionRepository;

        public ComponentSkillOptionService(IComponentSkillOptionRepository componentSkillOptionRepository)
            : base(componentSkillOptionRepository)
        {
            _componentSkillOptionRepository = componentSkillOptionRepository;
        }

        public IEnumerable<ComponentSkillOption> GetAllByUserId(string userId)
        {
            return _componentSkillOptionRepository.GetAllByUserId(userId);
        }

        public ComponentSkillOption GetById(Guid id, string userId)
        {
            return _componentSkillOptionRepository.GetById(id, userId);
        }

        public ComponentSkillOption GetDefault(string userId)
        {
            return _componentSkillOptionRepository.GetDefault(userId);
        }

        public ComponentSkillOption Put(string category, string description, string level, string userId)
        {
            var skillOption = _componentSkillOptionRepository.GetDefault(userId);

            bool alterStyle = category != skillOption.Category || description != skillOption.Description || level != skillOption.Level;
            if (alterStyle)
            {
                return new ComponentSkillOption(userId, false, category, description, level);                
            }
            else
            {
                return skillOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var skill = GetAllByUserId(userId);

            foreach (var item in skill)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Category, name, replace),
                    IsStyle.Rename(item.Description, name, replace),
                    IsStyle.Rename(item.Level, name, replace)
                    );
            }
            _componentSkillOptionRepository.Update(skill);
        }

        public void StyleRemove(string userId, string name)
        {
            var skill = GetAllByUserId(userId);

            foreach (var item in skill)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Category, name),
                    IsStyle.Remove(item.Description, name),
                    IsStyle.Remove(item.Level, name)
                    );
            }
            _componentSkillOptionRepository.Update(skill);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentSkillOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSkillOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSkillOption> GetByIdAsync(Guid id)
        {
            return await _componentSkillOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentSkillOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSkillOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSkillOption> GetDefaultAsync(string userId)
        {
            return await _componentSkillOptionRepository.GetDefaultAsync(userId);
        }
                
        public async Task<ComponentSkillOption> PutAsync(string category, string description, string level, string userId)
        {
            var skillOption = await _componentSkillOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = category != skillOption.Category || description != skillOption.Description || level != skillOption.Level;
            if (alterStyle)
            {
                return new ComponentSkillOption(userId, false, category, description, level);
            }
            else
            {
                return skillOption;
            }
        }
    }
}
