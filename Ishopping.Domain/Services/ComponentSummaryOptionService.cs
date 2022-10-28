using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentSummaryOptionService : ServiceBaseT2<ComponentSummaryOption>, IComponentSummaryOptionService
    {
        private readonly IComponentSummaryOptionRepository _componentSummaryOptionRepository;

        public ComponentSummaryOptionService(IComponentSummaryOptionRepository componentSummaryOptionRepository)
            : base(componentSummaryOptionRepository)
        {
            _componentSummaryOptionRepository = componentSummaryOptionRepository;
        }

        public IEnumerable<ComponentSummaryOption> GetAllByUserId(string userId)
        {
            return _componentSummaryOptionRepository.GetAllByUserId(userId);
        }

        public ComponentSummaryOption GetById(Guid id, string userId)
        {
            return _componentSummaryOptionRepository.GetById(id, userId);
        }

        public ComponentSummaryOption GetDefault(string userId)
        {
            return _componentSummaryOptionRepository.GetDefault(userId);
        }

        public ComponentSummaryOption Put(string title, string catetory, string description, string userId)
        {
            var summaryOption = _componentSummaryOptionRepository.GetDefault(userId);

            bool alterStyle = title != summaryOption.Title || catetory != summaryOption.Category || description != summaryOption.Description;
            if (alterStyle)
            {
                return new ComponentSummaryOption(userId, false, title, catetory, description);                
            }
            else
            {
                return summaryOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var summary = GetAllByUserId(userId);

            foreach (var item in summary)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Title, name, replace),
                    IsStyle.Rename(item.Category, name, replace),
                    IsStyle.Rename(item.Description, name, replace)
                    );
            }
            _componentSummaryOptionRepository.Update(summary);
        }

        public void StyleRemove(string userId, string name)
        {
            var summary = GetAllByUserId(userId);

            foreach (var item in summary)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Title, name),
                    IsStyle.Remove(item.Category, name),
                    IsStyle.Remove(item.Description, name)
                    );
            }
            _componentSummaryOptionRepository.Update(summary);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentSummaryOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSummaryOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSummaryOption> GetByIdAsync(Guid id)
        {
            return await _componentSummaryOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentSummaryOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSummaryOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSummaryOption> GetDefaultAsync(string userId)
        {
            return await _componentSummaryOptionRepository.GetDefaultAsync(userId);
        }

        public async Task<ComponentSummaryOption> PutAsync(string title, string catetory, string description, string userId)
        {
            var summaryOption = await _componentSummaryOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = title != summaryOption.Title || catetory != summaryOption.Category || description != summaryOption.Description;
            if (alterStyle)
            {
                return new ComponentSummaryOption(userId, false, title, catetory, description);
            }
            else
            {
                return summaryOption;
            }
        }
    }
}
