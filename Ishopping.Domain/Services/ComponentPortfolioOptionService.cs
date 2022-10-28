using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentPortfolioOptionService : ServiceBaseT2<ComponentPortofolioOption>, IComponentPortfolioOptionService
    {
        private readonly IComponentPortfolioOptionRepository _componentPortfolioOptionRepository;

        public ComponentPortfolioOptionService(IComponentPortfolioOptionRepository componentPortfolioOptionRepository)
            : base(componentPortfolioOptionRepository)
        {
            _componentPortfolioOptionRepository = componentPortfolioOptionRepository;
        }

        public IEnumerable<ComponentPortofolioOption> GetAllByUserId(string userId)
        {
            return _componentPortfolioOptionRepository.GetAllByUserId(userId);
        }

        public ComponentPortofolioOption GetById(Guid id, string userId)
        {
            return _componentPortfolioOptionRepository.GetById(id, userId);
        }

        public ComponentPortofolioOption GetDefault(string userId)
        {
            return _componentPortfolioOptionRepository.GetDefault(userId);
        }

        public ComponentPortofolioOption Put(string category, string title, string description, string list, string userId)
        {
            var portfolioOption = _componentPortfolioOptionRepository.GetDefault(userId);

            bool alterStyle = category != portfolioOption.Category || title != portfolioOption.Title || description != portfolioOption.Description || list != portfolioOption.List;
            if (alterStyle)
            {               
                return new ComponentPortofolioOption(userId, false, category, title, description, list);
            }
            else
            {
                return portfolioOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var portfolio = GetAllByUserId(userId);

            foreach (var item in portfolio)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Category, name, replace),
                    IsStyle.Rename(item.Title, name, replace),
                    IsStyle.Rename(item.Description, name, replace),
                    IsStyle.Rename(item.List, name, replace)
                    );
            }
            _componentPortfolioOptionRepository.Update(portfolio);
        }

        public void StyleRemove(string userId, string name)
        {
            var portfolio = GetAllByUserId(userId);

            foreach (var item in portfolio)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Category, name),
                     IsStyle.Remove(item.Title, name),
                    IsStyle.Remove(item.Description, name),
                     IsStyle.Remove(item.List, name)
                    );
            }
            _componentPortfolioOptionRepository.Update(portfolio);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentPortofolioOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPortfolioOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPortofolioOption> GetByIdAsync(Guid id)
        {
            return await _componentPortfolioOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentPortofolioOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPortfolioOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPortofolioOption> GetDefaultAsync(string userId)
        {
            return await _componentPortfolioOptionRepository.GetDefaultAsync(userId);
        }
        
        public async Task<ComponentPortofolioOption> PutAsync(string category, string title, string description, string list, string userId)
        {
            var portfolioOption = await _componentPortfolioOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = category != portfolioOption.Category || title != portfolioOption.Title || description != portfolioOption.Description || list != portfolioOption.List;
            if (alterStyle)
            {
                return new ComponentPortofolioOption(userId, false, category, title, description, list);
            }
            else
            {
                return portfolioOption;
            }
        }
    }
}
