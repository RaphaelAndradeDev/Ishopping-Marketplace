using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentPortfolioOptionAppService : AppServiceBaseT2<ComponentPortofolioOption>, IComponentPortfolioOptionAppService
    {
        private readonly IComponentPortfolioOptionService _componentPortfolioOptionService;

        public ComponentPortfolioOptionAppService(IComponentPortfolioOptionService componentPortfolioOptionService)
            :base(componentPortfolioOptionService)
        {
            _componentPortfolioOptionService = componentPortfolioOptionService;
        }

        public IEnumerable<ComponentPortofolioOption> GetAllByUserId(string userId)
        {
            return _componentPortfolioOptionService.GetAllByUserId(userId);
        }

        public ComponentPortofolioOption GetById(Guid id, string userId)
        {
            return _componentPortfolioOptionService.GetById(id, userId);
        }

        public ComponentPortofolioOption GetDefault(string userId)
        {
            return _componentPortfolioOptionService.GetDefault(userId);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentPortofolioOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPortfolioOptionService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPortofolioOption> GetByIdAsync(Guid id)
        {
            return await _componentPortfolioOptionService.GetByIdAsync(id);
        }

        public async Task<ComponentPortofolioOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPortfolioOptionService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPortofolioOption> GetDefaultAsync(string userId)
        {
            return await _componentPortfolioOptionService.GetDefaultAsync(userId);
        }


        public async Task<JsonResponse> AppUpdateAsync(string category, string title, string description, string list, string userId)
        {
            JsonResponse json = new JsonResponse();

            var portfolioOption = await _componentPortfolioOptionService.GetDefaultAsync(userId);
            if (portfolioOption != null)
            {
                portfolioOption.Change(portfolioOption.Default, category, title, description, list);
                _componentPortfolioOptionService.Update(portfolioOption);
            }

            return json;
        }
    }
}
