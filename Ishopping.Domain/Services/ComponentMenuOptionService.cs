using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentMenuOptionService : ServiceBaseT2<ComponentMenuOption>, IComponentMenuOptionService
    {
        private readonly IComponentMenuOptionRepository _componentMenuOptionRepository;

        public ComponentMenuOptionService(IComponentMenuOptionRepository componentMenuOptionRepository)
            : base(componentMenuOptionRepository)
        {
            _componentMenuOptionRepository = componentMenuOptionRepository;
        }

        public IEnumerable<ComponentMenuOption> GetAllByUserId(string userId)
        {
            return _componentMenuOptionRepository.GetAllByUserId(userId);
        }

        public ComponentMenuOption GetById(Guid id, string userId)
        {
            return _componentMenuOptionRepository.GetById(id, userId);
        }

        public ComponentMenuOption GetDefault(string userId)
        {
            return _componentMenuOptionRepository.GetDefault(userId);
        }

        public ComponentMenuOption Put(string title, string description, string price, string userId)
        {
            var menuOption = _componentMenuOptionRepository.GetDefault(userId);

            bool alterStyle = title != menuOption.Title || description != menuOption.Description || price != menuOption.Price;
            if (alterStyle)
            {
                return new ComponentMenuOption(userId, false, title, description, price);                
            }
            else
            {
                return menuOption;
            } 
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var menu = GetAllByUserId(userId);

            foreach (var item in menu)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Title, name, replace),
                    IsStyle.Rename(item.Description, name, replace),
                    IsStyle.Rename(item.Price, name, replace)
                    );
            }
            _componentMenuOptionRepository.Update(menu);
        }

        public void StyleRemove(string userId, string name)
        {
            var menu = GetAllByUserId(userId);

            foreach (var item in menu)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Title, name),
                    IsStyle.Remove(item.Description, name),
                    IsStyle.Remove(item.Price, name)
                    );
            }
            _componentMenuOptionRepository.Update(menu);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentMenuOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentMenuOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentMenuOption> GetByIdAsync(Guid id)
        {
            return await _componentMenuOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentMenuOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentMenuOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentMenuOption> GetDefaultAsync(string userId)
        {
            return await _componentMenuOptionRepository.GetDefaultAsync(userId);
        }
        
        public async Task<ComponentMenuOption> PutAsync(string title, string description, string price, string userId)
        {
            var menuOption = await _componentMenuOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = title != menuOption.Title || description != menuOption.Description || price != menuOption.Price;
            if (alterStyle)
            {
                return new ComponentMenuOption(userId, false, title, description, price);
            }
            else
            {
                return menuOption;
            } 
        }
    }
}
