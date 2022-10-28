using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentPresentationOptionService : ServiceBaseT2<ComponentPresentationOption>, IComponentPresentationOptionService
    {
        private readonly IComponentPresentationOptionRepository _componentPresentationOptionRepository;

        public ComponentPresentationOptionService(IComponentPresentationOptionRepository componentPresentationOptionRepository)
            : base(componentPresentationOptionRepository)
        {
            _componentPresentationOptionRepository = componentPresentationOptionRepository;
        }

        public IEnumerable<ComponentPresentationOption> GetAllByUserId(string userId)
        {
            return _componentPresentationOptionRepository.GetAllByUserId(userId);
        }

        public ComponentPresentationOption GetById(Guid id, string userId)
        {
            return _componentPresentationOptionRepository.GetById(id, userId);
        }

        public ComponentPresentationOption GetDefault(string userId)
        {
            return _componentPresentationOptionRepository.GetDefault(userId);
        }

        public ComponentPresentationOption Put(string title, string category, string description, string userId)
        {
            var presentationOption = _componentPresentationOptionRepository.GetDefault(userId);

            bool alterStyle = title != presentationOption.Title || category != presentationOption.Category || description != presentationOption.Description;
            if (alterStyle)
            {
                return new ComponentPresentationOption(userId, false, title, category, description);                
            }
            else
            {
                return presentationOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var presentation = GetAllByUserId(userId);

            foreach (var item in presentation)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Title, name, replace),
                    IsStyle.Rename(item.Category, name, replace),
                    IsStyle.Rename(item.Description, name, replace)
                    );
            }
            _componentPresentationOptionRepository.Update(presentation);
        }

        public void StyleRemove(string userId, string name)
        {
            var presentation = GetAllByUserId(userId);

            foreach (var item in presentation)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Title, name),
                    IsStyle.Remove(item.Category, name),
                    IsStyle.Remove(item.Description, name)
                    );
            }
            _componentPresentationOptionRepository.Update(presentation);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentPresentationOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPresentationOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPresentationOption> GetByIdAsync(Guid id)
        {
            return await _componentPresentationOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentPresentationOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPresentationOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPresentationOption> GetDefaultAsync(string userId)
        {
            return await _componentPresentationOptionRepository.GetDefaultAsync(userId);
        }
        
        public async Task<ComponentPresentationOption> PutAsync(string title, string category, string description, string userId)
        {
            var presentationOption = await _componentPresentationOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = title != presentationOption.Title || category != presentationOption.Category || description != presentationOption.Description;
            if (alterStyle)
            {
                return new ComponentPresentationOption(userId, false, title, category, description);
            }
            else
            {
                return presentationOption;
            }
        }
    }
}
