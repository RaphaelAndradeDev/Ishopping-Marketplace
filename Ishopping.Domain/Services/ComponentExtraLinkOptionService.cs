using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentExtraLinkOptionService : ServiceBaseT2<ComponentExtraLinkOption>, IComponentExtraLinkOptionService
    {
        private readonly IComponentExtraLinkOptionRepository _componentExtraLinkOptionRepository;

        public ComponentExtraLinkOptionService(IComponentExtraLinkOptionRepository componentExtraLinkOptionRepository)
            : base(componentExtraLinkOptionRepository)
        {
            _componentExtraLinkOptionRepository = componentExtraLinkOptionRepository;
        }

        public IEnumerable<ComponentExtraLinkOption> GetAllByUserId(string userId)
        {
            return _componentExtraLinkOptionRepository.GetAllByUserId(userId);
        }

        public ComponentExtraLinkOption GetById(Guid id, string userId)
        {
            return _componentExtraLinkOptionRepository.GetById(id, userId);
        }

        public ComponentExtraLinkOption GetDefault(string userId)
        {
            return _componentExtraLinkOptionRepository.GetDefault(userId);
        }

        public ComponentExtraLinkOption Put(string textLink, string description, string userId)
        {
            var extraLinkOption = _componentExtraLinkOptionRepository.GetDefault(userId);

            bool alterStyle = textLink != extraLinkOption.TextLink || description != extraLinkOption.Description;
            if (alterStyle)
            {
                return new ComponentExtraLinkOption(userId, false, textLink, description);                
            }
            else
            {
                return extraLinkOption;
            }  
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var extraLink = GetAllByUserId(userId);

            foreach (var item in extraLink)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.TextLink, name, replace),
                    IsStyle.Rename(item.Description, name, replace)
                    );
            }
            _componentExtraLinkOptionRepository.Update(extraLink);
        }

        public void StyleRemove(string userId, string name)
        {
            var extraLink = GetAllByUserId(userId);

            foreach (var item in extraLink)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.TextLink, name),
                    IsStyle.Remove(item.Description, name)
                    );
            }
            _componentExtraLinkOptionRepository.Update(extraLink);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentExtraLinkOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentExtraLinkOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentExtraLinkOption> GetByIdAsync(Guid id)
        {
            return await _componentExtraLinkOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentExtraLinkOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentExtraLinkOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentExtraLinkOption> GetDefaultAsync(string userId)
        {
            return await _componentExtraLinkOptionRepository.GetDefaultAsync(userId);
        }
        
        public async Task<ComponentExtraLinkOption> PutAsync(string textLink, string description, string userId)
        {
            var extraLinkOption = await _componentExtraLinkOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = textLink != extraLinkOption.TextLink || description != extraLinkOption.Description;
            if (alterStyle)
            {
                return new ComponentExtraLinkOption(userId, false, textLink, description);
            }
            else
            {
                return extraLinkOption;
            }  
        }
    }
}
