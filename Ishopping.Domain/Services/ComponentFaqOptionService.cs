using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentFaqOptionService : ServiceBaseT2<ComponentFaqOption>, IComponentFaqOptionService
    {
        private readonly IComponentFaqOptionRepository _componentFaqOptionRepository;

        public ComponentFaqOptionService(IComponentFaqOptionRepository componentFaqOptionRepository)
            : base(componentFaqOptionRepository)
        {
            _componentFaqOptionRepository = componentFaqOptionRepository;
        }

        public IEnumerable<ComponentFaqOption> GetAllByUserId(string userId)
        {
            return _componentFaqOptionRepository.GetAllByUserId(userId);
        }

        public ComponentFaqOption GetById(Guid id, string userId)
        {
            return _componentFaqOptionRepository.GetById(id, userId);
        }

        public ComponentFaqOption GetDefault(string userId)
        {
            return _componentFaqOptionRepository.GetDefault(userId);
        }

        public ComponentFaqOption Put(string pergunta, string resposta, string userId)
        {
            var extraLinkOption = _componentFaqOptionRepository.GetDefault(userId);

            bool alterStyle = pergunta != extraLinkOption.Pergunta || resposta != extraLinkOption.Resposta;
            if (alterStyle)
            {
                return new ComponentFaqOption(userId, false, pergunta, resposta);                
            }
            else
            {
                return extraLinkOption;
            }  
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var faq = GetAllByUserId(userId);

            foreach (var item in faq)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Pergunta, name, replace),
                    IsStyle.Rename(item.Resposta, name, replace)
                    );
            }
            _componentFaqOptionRepository.Update(faq);
        }

        public void StyleRemove(string userId, string name)
        {
            var faq = GetAllByUserId(userId);

            foreach (var item in faq)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Pergunta, name),
                    IsStyle.Remove(item.Resposta, name)
                    );
            }
            _componentFaqOptionRepository.Update(faq);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentFaqOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentFaqOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentFaqOption> GetByIdAsync(Guid id)
        {
            return await _componentFaqOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentFaqOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentFaqOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentFaqOption> GetDefaultAsync(string userId)
        {
            return await _componentFaqOptionRepository.GetDefaultAsync(userId);
        }
                
        public async Task<ComponentFaqOption> PutAsync(string pergunta, string resposta, string userId)
        {
            var extraLinkOption = await _componentFaqOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = pergunta != extraLinkOption.Pergunta || resposta != extraLinkOption.Resposta;
            if (alterStyle)
            {
                return new ComponentFaqOption(userId, false, pergunta, resposta);
            }
            else
            {
                return extraLinkOption;
            } 
        }
    }
}
