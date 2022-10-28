using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentClientOptionService : ServiceBaseT2<ComponentClientOption>, IComponentClientOptionService
    {
        private readonly IComponentClientOptionRepository _componentClientOptionRepository;

        public ComponentClientOptionService(IComponentClientOptionRepository componentClientOptionRepository)
            : base(componentClientOptionRepository)
        {
            _componentClientOptionRepository = componentClientOptionRepository;
        }

        public IEnumerable<ComponentClientOption> GetAllByUserId(string userId)
        {
            return _componentClientOptionRepository.GetAllByUserId(userId);
        }

        public ComponentClientOption GetById(Guid id, string userId)
        {
            return _componentClientOptionRepository.GetById(id, userId);
        }

        public ComponentClientOption GetDefault(string userId)
        {
            return _componentClientOptionRepository.GetDefault(userId);
        }

        public ComponentClientOption Put(string name, string functio, string comment, string styleProjects, string userId)
        {
            var clientOption = _componentClientOptionRepository.GetDefault(userId);

            bool alterStyle = name != clientOption.Name || functio != clientOption.Functio || comment != clientOption.Comment ||styleProjects != clientOption.Projects;
            if (alterStyle)
            {
                return new ComponentClientOption(userId, false, name, functio, comment, styleProjects);                
            }
            else
            {
                return clientOption;
            } 
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var client = _componentClientOptionRepository.GetAllByUserId(userId);

            foreach (var item in client)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Name, name, replace),
                    IsStyle.Rename(item.Functio, name, replace),
                    IsStyle.Rename(item.Comment, name, replace),
                    IsStyle.Rename(item.Projects, name, replace)
                    );
            }
            _componentClientOptionRepository.Update(client);
        }

        public void StyleRemove(string userId, string name)
        {
            var client = _componentClientOptionRepository.GetAllByUserId(userId);

            foreach (var item in client)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Name, name),
                    IsStyle.Remove(item.Functio, name),
                    IsStyle.Remove(item.Comment, name),
                    IsStyle.Remove(item.Projects, name)
                    );
            }
            _componentClientOptionRepository.Update(client);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentClientOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentClientOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentClientOption> GetByIdAsync(Guid id)
        {
            return await _componentClientOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentClientOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentClientOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentClientOption> GetDefaultAsync(string userId)
        {
            return await _componentClientOptionRepository.GetDefaultAsync(userId);
        }
        
        public async Task<ComponentClientOption> PutAsync(string name, string functio, string comment, string projects, string userId)
        {
            var clientOption = await _componentClientOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = name != clientOption.Name || functio != clientOption.Functio || comment != clientOption.Comment || projects != clientOption.Projects;
            if (alterStyle)
            {
                return new ComponentClientOption(userId, false, name, functio, comment, projects);
            }
            else
            {
                return clientOption;
            }
        }
    }
}
