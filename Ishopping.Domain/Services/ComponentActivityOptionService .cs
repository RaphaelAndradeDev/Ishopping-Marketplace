using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentActivityOptionService : ServiceBaseT2<ComponentActivityOption>, IComponentActivityOptionService
    {
        private readonly IComponentActivityOptionRepository _componentActivityOptionRepository;

        public ComponentActivityOptionService(IComponentActivityOptionRepository componentActivityOptionRepository)
            : base(componentActivityOptionRepository)
        {
            _componentActivityOptionRepository = componentActivityOptionRepository;
        }

        public IEnumerable<ComponentActivityOption> GetAllByUserId(string userId)
        {
            return _componentActivityOptionRepository.GetAllByUserId(userId);
        }

        public ComponentActivityOption GetById(Guid id, string userId)
        {
            return _componentActivityOptionRepository.GetById(id, userId);
        }
        
        public ComponentActivityOption GetDefault(string userId)
        {
            return _componentActivityOptionRepository.GetDefault(userId);
        }
                
        public void UpdateAll(IEnumerable<ComponentActivityOption> componentActivityOption)
        {
            _componentActivityOptionRepository.UpdateAll(componentActivityOption);
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var activity = _componentActivityOptionRepository.GetAllByUserId(userId);

            foreach (var item in activity)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Title, name, replace),
                    IsStyle.Rename(item.Description, name, replace)
                    );                
            }
            _componentActivityOptionRepository.UpdateAll(activity);         
        }

        public void StyleRemove(string userId, string name)
        {
            var activity = _componentActivityOptionRepository.GetAllByUserId(userId);

            foreach (var item in activity)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Title, name),
                    IsStyle.Remove(item.Description, name)
                    );               
            }
            _componentActivityOptionRepository.UpdateAll(activity);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentActivityOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentActivityOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentActivityOption> GetByIdAsync(Guid id)
        {
            return await _componentActivityOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentActivityOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentActivityOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentActivityOption> GetDefaultAsync(string userId)
        {
            return await _componentActivityOptionRepository.GetDefaultAsync(userId);
        }

        public async Task<ComponentActivityOption> PutAsync(string userId, string title, string description)
        {
            var activityOption = await _componentActivityOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = title != activityOption.Title || description != activityOption.Description;
            if (alterStyle)
            {
                return new ComponentActivityOption(userId, false, title, description);
            }
            else
            {
                return activityOption;
            }
        }
    }
}
