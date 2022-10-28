using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentTeamOptionService : ServiceBaseT2<ComponentTeamOption>, IComponentTeamOptionService
    {
        private readonly IComponentTeamOptionRepository _componentTeamOptionRepository;

        public ComponentTeamOptionService(IComponentTeamOptionRepository componentTeamOptionRepository)
            : base(componentTeamOptionRepository)
        {
            _componentTeamOptionRepository = componentTeamOptionRepository;
        }

        public IEnumerable<ComponentTeamOption> GetAllByUserId(string userId)
        {
            return _componentTeamOptionRepository.GetAllByUserId(userId);
        }

        public ComponentTeamOption GetById(Guid id, string userId)
        {
            return _componentTeamOptionRepository.GetById(id, userId);
        }

        public ComponentTeamOption GetDefault(string userId)
        {
            return _componentTeamOptionRepository.GetDefault(userId);
        }

        public ComponentTeamOption Put(string name, string functio, string description, string userId)
        {
            var teamOption = _componentTeamOptionRepository.GetDefault(userId);

            bool alterStyle = name != teamOption.Name || functio != teamOption.Functio || description != teamOption.Description;
            if (alterStyle)
            {
                return new ComponentTeamOption(userId, false, name, functio, description);                
            }
            else
            {
                return teamOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var team = GetAllByUserId(userId);

            foreach (var item in team)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Name, name, replace),
                    IsStyle.Rename(item.Functio, name, replace),
                    IsStyle.Rename(item.Description, name, replace)
                    );
            }
            _componentTeamOptionRepository.Update(team);
        }

        public void StyleRemove(string userId, string name)
        {
            var team = GetAllByUserId(userId);

            foreach (var item in team)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Name, name),
                    IsStyle.Remove(item.Functio, name),
                    IsStyle.Remove(item.Description, name)
                    );
            }
            _componentTeamOptionRepository.Update(team);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentTeamOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentTeamOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentTeamOption> GetByIdAsync(Guid id)
        {
            return await _componentTeamOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentTeamOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentTeamOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentTeamOption> GetDefaultAsync(string userId)
        {
            return await _componentTeamOptionRepository.GetDefaultAsync(userId);
        }

        public async Task<ComponentTeamOption> PutAsync(string name, string functio, string description, string userId)
        {
            var teamOption = await _componentTeamOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = name != teamOption.Name || functio != teamOption.Functio || description != teamOption.Description;
            if (alterStyle)
            {
                return new ComponentTeamOption(userId, false, name, functio, description);
            }
            else
            {
                return teamOption;
            }
        }
    }
}
