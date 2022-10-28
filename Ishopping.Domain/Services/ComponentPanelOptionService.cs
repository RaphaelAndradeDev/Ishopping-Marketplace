using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentPanelOptionService : ServiceBaseT2<ComponentPanelOption>, IComponentPanelOptionService
    {
        private readonly IComponentPanelOptionRepository _componentPanelOptionRepository;

        public ComponentPanelOptionService(IComponentPanelOptionRepository componentPanelOptionRepository)
            : base(componentPanelOptionRepository)
        {
            _componentPanelOptionRepository = componentPanelOptionRepository;
        }

        public IEnumerable<ComponentPanelOption> GetAllByUserId(string userId)
        {
            return _componentPanelOptionRepository.GetAllByUserId(userId);
        }

        public ComponentPanelOption GetById(Guid id, string userId)
        {
            return _componentPanelOptionRepository.GetById(id, userId);
        }

        public ComponentPanelOption GetDefault(string userId)
        {
            return _componentPanelOptionRepository.GetDefault(userId);
        }

        public ComponentPanelOption Put(string title, string text, string userId)
        {
            var panelOption = _componentPanelOptionRepository.GetDefault(userId);

            bool alterStyle = title != panelOption.Title || text != panelOption.Text;
            if (alterStyle)
            {
                return new ComponentPanelOption(userId, false, title, text);                
            }
            else
            {
                return panelOption;
            }  
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var panel = GetAllByUserId(userId);

            foreach (var item in panel)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Title, name, replace),
                    IsStyle.Rename(item.Text, name, replace)
                    );
            }
            _componentPanelOptionRepository.Update(panel);
        }

        public void StyleRemove(string userId, string name)
        {
            var panel = GetAllByUserId(userId);

            foreach (var item in panel)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Title, name),
                    IsStyle.Remove(item.Text, name)
                    );
            }
            _componentPanelOptionRepository.Update(panel);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentPanelOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPanelOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPanelOption> GetByIdAsync(Guid id)
        {
            return await _componentPanelOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentPanelOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPanelOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPanelOption> GetDefaultAsync(string userId)
        {
            return await _componentPanelOptionRepository.GetDefaultAsync(userId);
        }
        
        public async Task<ComponentPanelOption> PutAsync(string title, string text, string userId)
        {
            var panelOption = await _componentPanelOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = title != panelOption.Title || text != panelOption.Text;
            if (alterStyle)
            {
                return new ComponentPanelOption(userId, false, title, text);
            }
            else
            {
                return panelOption;
            }  
        }
    }
}
