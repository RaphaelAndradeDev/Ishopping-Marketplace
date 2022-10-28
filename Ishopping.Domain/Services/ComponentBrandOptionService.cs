using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentBrandOptionService : ServiceBaseT2<ComponentBrandOption>, IComponentBrandOptionService
    {
        private readonly IComponentBrandOptionRepository _componentBrandOptionRepository;

        public ComponentBrandOptionService(IComponentBrandOptionRepository componentBrandOptionRepository)
            : base(componentBrandOptionRepository)
        {
            _componentBrandOptionRepository = componentBrandOptionRepository;
        }

        // Sync Methods
        public IEnumerable<ComponentBrandOption> GetAllByUserId(string userId)
        {
            return _componentBrandOptionRepository.GetAllByUserId(userId);
        }

        public ComponentBrandOption GetById(Guid id, string userId)
        {
            return _componentBrandOptionRepository.GetById(id, userId);
        }

        public ComponentBrandOption GetDefault(string userId)
        {
            return _componentBrandOptionRepository.GetDefault(userId);
        }


        public void StyleReplace(string userId, string name, string replace)
        {
            var activity = _componentBrandOptionRepository.GetAllByUserId(userId);

            foreach (var item in activity)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Marca, name, replace),
                    IsStyle.Rename(item.Comment, name, replace)
                    );
            }
            _componentBrandOptionRepository.Update(activity);
        }

        public void StyleRemove(string userId, string name)
        {
            var activity = _componentBrandOptionRepository.GetAllByUserId(userId);

            foreach (var item in activity)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Marca, name),
                    IsStyle.Remove(item.Comment, name)
                    );
            }
            _componentBrandOptionRepository.Update(activity);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentBrandOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentBrandOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentBrandOption> GetByIdAsync(Guid id)
        {
            return await _componentBrandOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentBrandOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentBrandOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentBrandOption> GetDefaultAsync(string userId)
        {
            return await _componentBrandOptionRepository.GetDefaultAsync(userId);
        }

        public async Task<ComponentBrandOption> PutAsync(string marca, string comment, string userId)
        {
            var brandOption = await _componentBrandOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = marca != brandOption.Marca || comment != brandOption.Comment;
            if (alterStyle)
            {
                return new ComponentBrandOption(userId, false, marca, comment);
            }
            else
            {
                return brandOption;
            }
        }
    }

}
