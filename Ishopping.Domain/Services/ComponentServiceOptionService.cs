using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentServiceOptionService : ServiceBaseT2<ComponentServiceOption>, IComponentServiceOptionService
    {
        private readonly IComponentServiceOptionRepository _componentServiceOptionRepository;

        public ComponentServiceOptionService(IComponentServiceOptionRepository componentServiceOptionRepository)
            : base(componentServiceOptionRepository)
        {
            _componentServiceOptionRepository = componentServiceOptionRepository;
        }

        public IEnumerable<ComponentServiceOption> GetAllByUserId(string userId)
        {
            return _componentServiceOptionRepository.GetAllByUserId(userId);
        }

        public ComponentServiceOption GetById(Guid id, string userId)
        {
            return _componentServiceOptionRepository.GetById(id, userId);
        }

        public ComponentServiceOption GetDefault(string userId)
        {
            return _componentServiceOptionRepository.GetDefault(userId);
        }

        public ComponentServiceOption Put(string title, string description, string userId)
        {
            var serviceOption = _componentServiceOptionRepository.GetDefault(userId);

            bool alterStyle = title != serviceOption.Title || description != serviceOption.Description;
            if (alterStyle)
            {
                return new ComponentServiceOption(userId, false, title, description);                
            }
            else
            {
                return serviceOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var service = GetAllByUserId(userId);

            foreach (var item in service)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Title, name, replace),
                    IsStyle.Rename(item.Description, name, replace)
                    );
            }
            _componentServiceOptionRepository.Update(service);
        }

        public void StyleRemove(string userId, string name)
        {
            var service = GetAllByUserId(userId);

            foreach (var item in service)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Title, name),
                    IsStyle.Remove(item.Description, name)
                    );
            }
            _componentServiceOptionRepository.Update(service);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentServiceOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentServiceOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentServiceOption> GetByIdAsync(Guid id)
        {
            return await _componentServiceOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentServiceOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentServiceOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentServiceOption> GetDefaultAsync(string userId)
        {
            return await _componentServiceOptionRepository.GetDefaultAsync(userId);
        }
        
        public async Task<ComponentServiceOption> PutAsync(string title, string description, string userId)
        {
            var serviceOption = await _componentServiceOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = title != serviceOption.Title || description != serviceOption.Description;
            if (alterStyle)
            {
                return new ComponentServiceOption(userId, false, title, description);
            }
            else
            {
                return serviceOption;
            }
        }
    }
}
