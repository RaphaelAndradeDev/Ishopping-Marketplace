using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentScopeOptionService : ServiceBaseT2<ComponentScopeOption>, IComponentScopeOptionService
    {
        private readonly IComponentScopeOptionRepository _componentScopeOptionRepository;

        public ComponentScopeOptionService(IComponentScopeOptionRepository componentScopeOptionRepository)
            : base(componentScopeOptionRepository)
        {
            _componentScopeOptionRepository = componentScopeOptionRepository;
        }

        public IEnumerable<ComponentScopeOption> GetAllByUserId(string userId)
        {
            return _componentScopeOptionRepository.GetAllByUserId(userId);
        }

        public ComponentScopeOption GetById(Guid id, string userId)
        {
            return _componentScopeOptionRepository.GetById(id, userId);
        }

        public ComponentScopeOption GetDefault(string userId)
        {
            return _componentScopeOptionRepository.GetDefault(userId);
        }

        public ComponentScopeOption Put(string title, string category, string description, string userId)
        {
            var scopeOption = _componentScopeOptionRepository.GetDefault(userId);

            bool alterStyle = title != scopeOption.Title || category != scopeOption.Category || description != scopeOption.Description;
            if (alterStyle)
            {
                return new ComponentScopeOption(userId, false, title, category, description);                
            }
            else
            {
                return scopeOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var scope = GetAllByUserId(userId);

            foreach (var item in scope)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Title, name, replace),
                    IsStyle.Rename(item.Category, name, replace),
                    IsStyle.Rename(item.Description, name, replace)
                    );
            }
            _componentScopeOptionRepository.Update(scope);
        }

        public void StyleRemove(string userId, string name)
        {
            var scope = GetAllByUserId(userId);

            foreach (var item in scope)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Title, name),
                    IsStyle.Remove(item.Category, name),
                    IsStyle.Remove(item.Description, name)
                    );
            }
            _componentScopeOptionRepository.Update(scope);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentScopeOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentScopeOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentScopeOption> GetByIdAsync(Guid id)
        {
            return await _componentScopeOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentScopeOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentScopeOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentScopeOption> GetDefaultAsync(string userId)
        {
            return await _componentScopeOptionRepository.GetDefaultAsync(userId);
        }
                
        public async Task<ComponentScopeOption> PutAsync(string title, string category, string description, string userId)
        {
            var scopeOption = await _componentScopeOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = title != scopeOption.Title || category != scopeOption.Category || description != scopeOption.Description;
            if (alterStyle)
            {
                return new ComponentScopeOption(userId, false, title, category, description);
            }
            else
            {
                return scopeOption;
            }
        }
    }
}
