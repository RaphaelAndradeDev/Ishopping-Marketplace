using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentPortofolioService : ServiceBaseT2<ComponentPortofolio>, IComponentPortofolioService
    {
        private readonly IComponentPortofolioRepository _componentPortofolioRepository;
        private readonly IComponentPortofolioDapperRepository _componentPortofolioDapperRepository;

        public ComponentPortofolioService(
            IComponentPortofolioRepository componentPortofolioRepository,
            IComponentPortofolioDapperRepository componentPortofolioDapperRepository)
            : base(componentPortofolioRepository)
        {
            _componentPortofolioRepository = componentPortofolioRepository;
            _componentPortofolioDapperRepository = componentPortofolioDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentPortofolioRepository.Search(startsWith, position, userId);
        }

        public ComponentPortofolio GetByImageId(Guid imageId)
        {
            return _componentPortofolioRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentPortofolio> GetAllBySiteNumber(int siteNumber)
        {
            return _componentPortofolioDapperRepository.GetAllBySiteNumber(siteNumber);
        }        

        public ComponentPortofolio GetBySiteNumber(int siteNumber)
        {
            return _componentPortofolioRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPortofolio> GetAllByUserId(string userId)
        {
            return _componentPortofolioRepository.GetAllByUserId(userId);
        }

        public ComponentPortofolio GetById(Guid id, string userId)
        {
            return _componentPortofolioRepository.GetById(id, userId);
        }

        public ComponentPortofolio GetBy(string title, int position, string userId)
        {
            return _componentPortofolioRepository.GetBy(title, position, userId);
        }   

        public void DeleteAll(string userId)
        {
            _componentPortofolioRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentPortofolioRepository.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentPortofolio> GetByImageIdAsync(Guid imageId)
        {
            return await _componentPortofolioRepository.GetByImageIdAsync(imageId);
        }
        
        public async Task<ComponentPortofolio> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentPortofolioRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPortofolio>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentPortofolioDapperRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPortofolio>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPortofolioRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPortofolio> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPortofolioRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPortofolio> GetByAsync(string search, int position, string userId)
        {
            return await _componentPortofolioRepository.GetByAsync(search, position, userId);
        }


        // Async Methods for AppPortfolio
        public async Task<SimplePortfolio> GetByIdAsync(Guid id)
        {
            return await _componentPortofolioRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<SimplePortfolio>> GetBySiteNumberAsync(int siteNumber, int take)
        {
            return await _componentPortofolioRepository.GetBySiteNumberAsync(siteNumber, take);
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByTitleAsync(int siteNumber, string title, int take)
        {
            return await _componentPortofolioRepository.GetByTitleAsync(siteNumber, title, take);
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByCategoryAsync(int siteNumber, string categoy, int take)
        {
            return await _componentPortofolioRepository.GetByCategoryAsync(siteNumber, categoy, take);
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByCategoryAsync(int siteNumber, string categoy, string subCategory, int take)
        {
            return await _componentPortofolioRepository.GetByCategoryAsync(siteNumber, categoy, subCategory, take);
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByTagAsync(int siteNumber, string tag, int take)
        {
            return await _componentPortofolioDapperRepository.GetByTagAsync(siteNumber, tag, take);
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByTagsAsync(int siteNumber, string tags, int take)
        {
            return await _componentPortofolioDapperRepository.GetByTagsAsync(siteNumber, tags, take);
        }


        // multiplos usuários
        public async Task<IEnumerable<SimplePortfolio>> GetAllBySiteNumberAsync(IEnumerable<int> siteNumber, int take)
        {
            return await _componentPortofolioDapperRepository.GetAllBySiteNumberAsync(siteNumber, take);
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByTitleAsync(string title, int take)
        {
            return await _componentPortofolioRepository.GetAllByTitleAsync(title, take);
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByCategoryAsync(string categoy, int take)
        {
            return await _componentPortofolioRepository.GetAllByCategoryAsync(categoy, take);
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByCategoryAsync(string categoy, string subCategory, int take)
        {
            return await _componentPortofolioRepository.GetAllByCategoryAsync(categoy, subCategory, take);
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByTagAsync(string tag, int take)
        {
            return await _componentPortofolioDapperRepository.GetAllByTagAsync(tag, take);
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByTagsAsync(string tags, int take)
        {
            return await _componentPortofolioDapperRepository.GetAllByTagsAsync(tags, take);
        }

    }
}
