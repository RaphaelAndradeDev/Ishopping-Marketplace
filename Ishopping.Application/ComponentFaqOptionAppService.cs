using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentFaqOptionAppService : AppServiceBaseT2<ComponentFaqOption>, IComponentFaqOptionAppService
    {
        private readonly IComponentFaqOptionService _componentFaqOptionService;

        public ComponentFaqOptionAppService(IComponentFaqOptionService componentFaqOptionService)
            :base(componentFaqOptionService)
        {
            _componentFaqOptionService = componentFaqOptionService;
        }

        public IEnumerable<ComponentFaqOption> GetAllByUserId(string userId)
        {
            return _componentFaqOptionService.GetAllByUserId(userId);
        }

        public ComponentFaqOption GetById(Guid id, string userId)
        {
            return _componentFaqOptionService.GetById(id, userId);
        }

        public ComponentFaqOption GetDefault(string userId)
        {
            return _componentFaqOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentFaqOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentFaqOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentFaqOption> GetByIdAsync(Guid id)
        {
            return await _componentFaqOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentFaqOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentFaqOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentFaqOption> GetDefaultAsync(string userId)
        {
            return await _componentFaqOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string pergunta, string resposta, string userId)
        {
            JsonResponse json = new JsonResponse();

            var faqOption = await _componentFaqOptionService.GetDefaultAsync(userId);
            if (faqOption != null)
            {
                faqOption.Change(faqOption.Default, pergunta, resposta);
                _componentFaqOptionService.Update(faqOption);
            }

            return json;
        }
    }
}
