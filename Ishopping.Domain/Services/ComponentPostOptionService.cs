using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentPostOptionService : ServiceBaseT2<ComponentPostOption>, IComponentPostOptionService
    {
        private readonly IComponentPostOptionRepository _componentPostOptionRepository;

        public ComponentPostOptionService(IComponentPostOptionRepository componentPostOptionRepository)
            : base(componentPostOptionRepository)
        {
            _componentPostOptionRepository = componentPostOptionRepository;
        }

        public IEnumerable<ComponentPostOption> GetAllByUserId(string userId)
        {
            return _componentPostOptionRepository.GetAllByUserId(userId);
        }

        public ComponentPostOption GetById(Guid id, string userId)
        {
            return _componentPostOptionRepository.GetById(id, userId);
        }

        public ComponentPostOption GetDefault(string userId)
        {
            return _componentPostOptionRepository.GetDefault(userId);
        }

        public ComponentPostOption Put(string autor, string categoria, string titulo, string subTitulo, string paragrafo, string userId)
        {
            var postOption = _componentPostOptionRepository.GetDefault(userId);

            bool alterStyle = autor != postOption.Autor || categoria != postOption.Categoria || titulo != postOption.Titulo || subTitulo != postOption.SubTitulo || paragrafo != postOption.Paragrafo;
            if (alterStyle)
            {
                return new ComponentPostOption(userId, false, autor, categoria, titulo, subTitulo, paragrafo);                
            }
            else
            {
                return postOption;   
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var post = GetAllByUserId(userId);

            foreach (var item in post)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Autor, name, replace),
                    IsStyle.Rename(item.Categoria, name, replace),
                    IsStyle.Rename(item.Titulo, name, replace),
                    IsStyle.Rename(item.SubTitulo, name, replace),
                    IsStyle.Rename(item.Paragrafo, name, replace)
                    );
            }
            _componentPostOptionRepository.Update(post);
        }

        public void StyleRemove(string userId, string name)
        {
            var post = GetAllByUserId(userId);

            foreach (var item in post)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Autor, name),
                    IsStyle.Remove(item.Categoria, name),
                    IsStyle.Remove(item.Titulo, name),
                    IsStyle.Remove(item.SubTitulo, name),
                    IsStyle.Remove(item.Paragrafo, name)
                    );
            }
            _componentPostOptionRepository.Update(post);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentPostOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPostOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPostOption> GetByIdAsync(Guid id)
        {
            return await _componentPostOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentPostOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPostOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPostOption> GetDefaultAsync(string userId)
        {
            return await _componentPostOptionRepository.GetDefaultAsync(userId);
        }
        
        public async Task<ComponentPostOption> PutAsync(string autor, string categoria, string titulo, string subTitulo, string paragrafo, string userId)
        {
            var postOption = await _componentPostOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = autor != postOption.Autor || categoria != postOption.Categoria || titulo != postOption.Titulo || subTitulo != postOption.SubTitulo || paragrafo != postOption.Paragrafo;
            if (alterStyle)
            {
                return new ComponentPostOption(userId, false, autor, categoria, titulo, subTitulo, paragrafo);
            }
            else
            {
                return postOption;
            }
        }
    }
}
