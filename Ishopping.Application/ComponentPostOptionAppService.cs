using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentPostOptionAppService : AppServiceBaseT2<ComponentPostOption>, IComponentPostOptionAppService
    {
        private readonly IComponentPostOptionService _componentPostOptionService;

        public ComponentPostOptionAppService(IComponentPostOptionService componentPostOptionService)
            : base(componentPostOptionService)
        {
            _componentPostOptionService = componentPostOptionService;
        }

        public IEnumerable<ComponentPostOption> GetAllByUserId(string userId)
        {
            return _componentPostOptionService.GetAllByUserId(userId);
        }

        public ComponentPostOption GetById(Guid id, string userId)
        {
            return _componentPostOptionService.GetById(id, userId);
        }

        public ComponentPostOption GetDefault(string userId)
        {
            return _componentPostOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentPostOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPostOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPostOption> GetByIdAsync(Guid id)
        {
            return await _componentPostOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentPostOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPostOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPostOption> GetDefaultAsync(string userId)
        {
            return await _componentPostOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string autor, string categoria, string titulo, string subTitulo, string paragrafo, string userId)
        {
            JsonResponse json = new JsonResponse();

            var postOption = await _componentPostOptionService.GetDefaultAsync(userId);
            if (postOption != null)
            {
                postOption.Change(postOption.Default, autor, categoria, titulo, subTitulo, paragrafo);                           
                _componentPostOptionService.Update(postOption);
            }

            return json;
        }
    }
}
