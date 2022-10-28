using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentProjectOptionService : ServiceBaseT2<ComponentProjectOption>, IComponentProjectOptionService
    {
        private readonly IComponentProjectOptionRepository _componentProjectOptionRepository;

        public ComponentProjectOptionService(IComponentProjectOptionRepository componentProjectOptionRepository)
            : base(componentProjectOptionRepository)
        {
            _componentProjectOptionRepository = componentProjectOptionRepository;
        }

        public IEnumerable<ComponentProjectOption> GetAllByUserId(string userId)
        {
            return _componentProjectOptionRepository.GetAllByUserId(userId);
        }

        public ComponentProjectOption GetById(Guid id, string userId)
        {
            return _componentProjectOptionRepository.GetById(id, userId);
        }

        public ComponentProjectOption GetDefault(string userId)
        {
            return _componentProjectOptionRepository.GetDefault(userId);
        }

        public ComponentProjectOption Put(string name, string title, string client, string description, string category, string team, string userId)
        {
            var projectOption = _componentProjectOptionRepository.GetDefault(userId);

            bool alterStyle = name != projectOption.Name || title != projectOption.Title || client != projectOption.Client || description != projectOption.Description || category != projectOption.Category || team != projectOption.Team;
            if (alterStyle)
            {
                return new ComponentProjectOption(userId, false, name, title, client, description, category, team);                
            }
            else
            {
                return projectOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var project = GetAllByUserId(userId);

            foreach (var item in project)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Name, name, replace),
                    IsStyle.Rename(item.Title, name, replace),
                    IsStyle.Rename(item.Client, name, replace),
                    IsStyle.Rename(item.Description, name, replace),
                    IsStyle.Rename(item.Category, name, replace),
                    IsStyle.Rename(item.Team, name, replace)
                    );
            }
            _componentProjectOptionRepository.Update(project);
        }

        public void StyleRemove(string userId, string name)
        {
            var project = GetAllByUserId(userId);

            foreach (var item in project)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Name, name),
                    IsStyle.Remove(item.Title, name),
                    IsStyle.Remove(item.Client, name),
                    IsStyle.Remove(item.Description, name),
                    IsStyle.Remove(item.Category, name),
                    IsStyle.Remove(item.Team, name)
                    );
            }
            _componentProjectOptionRepository.Update(project);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentProjectOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentProjectOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentProjectOption> GetByIdAsync(Guid id)
        {
            return await _componentProjectOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentProjectOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentProjectOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentProjectOption> GetDefaultAsync(string userId)
        {
            return await _componentProjectOptionRepository.GetDefaultAsync(userId);
        }
        
        public async Task<ComponentProjectOption> PutAsync(string name, string title, string client, string description, string category, string team, string userId)
        {
            var projectOption = await _componentProjectOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = name != projectOption.Name || title != projectOption.Title || client != projectOption.Client || description != projectOption.Description || category != projectOption.Category || team != projectOption.Team;
            if (alterStyle)
            {
                return new ComponentProjectOption(userId, false, name, title, client, description, category, team);
            }
            else
            {
                return projectOption;
            }
        }
    }
}
