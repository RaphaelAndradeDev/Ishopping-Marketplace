using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentFeaturesOptionService : ServiceBaseT2<ComponentFeaturesOption>, IComponentFeaturesOptionService
    {
        private readonly IComponentFeaturesOptionRepository _componentFeaturesOptionRepository;

        public ComponentFeaturesOptionService(IComponentFeaturesOptionRepository componentFeaturesOptionRepository)
            : base(componentFeaturesOptionRepository)
        {
            _componentFeaturesOptionRepository = componentFeaturesOptionRepository;
        }

        public IEnumerable<ComponentFeaturesOption> GetAllByUserId(string userId)
        {
            return _componentFeaturesOptionRepository.GetAllByUserId(userId);
        }

        public ComponentFeaturesOption GetById(Guid id, string userId)
        {
            return _componentFeaturesOptionRepository.GetById(id, userId);
        }

        public ComponentFeaturesOption GetDefault(string userId)
        {
            return _componentFeaturesOptionRepository.GetDefault(userId);
        }

        public ComponentFeaturesOption Put(string title, string count, string description, string userId)
        {
            var featuresOption = _componentFeaturesOptionRepository.GetDefault(userId);

            bool alterStyle = title != featuresOption.Title || count != featuresOption.Count || description != featuresOption.Description;
            if (alterStyle)
            {
                return new ComponentFeaturesOption(userId, false, title, count, description);                
            }
            else
            {
                return featuresOption;
            } 
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var features = GetAllByUserId(userId);

            foreach (var item in features)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Title, name, replace),
                    IsStyle.Rename(item.Count, name, replace),
                    IsStyle.Rename(item.Description, name, replace)
                    );
            }
            _componentFeaturesOptionRepository.Update(features);
        }

        public void StyleRemove(string userId, string name)
        {
            var features = GetAllByUserId(userId);

            foreach (var item in features)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Title, name),
                    IsStyle.Remove(item.Count, name),
                    IsStyle.Remove(item.Description, name)
                    );
            }
            _componentFeaturesOptionRepository.Update(features);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentFeaturesOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentFeaturesOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentFeaturesOption> GetByIdAsync(Guid id)
        {
            return await _componentFeaturesOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentFeaturesOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentFeaturesOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentFeaturesOption> GetDefaultAsync(string userId)
        {
            return await _componentFeaturesOptionRepository.GetDefaultAsync(userId);
        }

        public async Task<ComponentFeaturesOption> PutAsync(string title, string count, string description, string userId)
        {
            var featuresOption = await _componentFeaturesOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = title != featuresOption.Title || count != featuresOption.Count || description != featuresOption.Description;
            if (alterStyle)
            {
                return new ComponentFeaturesOption(userId, false, title, count, description);
            }
            else
            {
                return featuresOption;
            } 
        }
    }
}
