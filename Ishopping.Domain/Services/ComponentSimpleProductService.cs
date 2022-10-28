using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentSimpleProductService : ServiceBaseT2<ComponentSimpleProduct>, IComponentSimpleProductService
    {
        private readonly IComponentSimpleProductRepository _componentSimpleProductRepository;
        private readonly IComponentSimpleProductDapperRepository _componentSimpleProductDapperRepository;

        public ComponentSimpleProductService(
            IComponentSimpleProductRepository componentSimpleProductRepository,
            IComponentSimpleProductDapperRepository componentSimpleProductDapperRepository)
            : base(componentSimpleProductRepository)
        {
            _componentSimpleProductRepository = componentSimpleProductRepository;
            _componentSimpleProductDapperRepository = componentSimpleProductDapperRepository;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentSimpleProductRepository.Search(startsWith, userId);
        }

        public ComponentSimpleProduct GetByImageId(Guid imageId)
        {
            return _componentSimpleProductRepository.GetByImageId(imageId);
        }

        public IEnumerable<ComponentSimpleProduct> GetAllBySiteNumber(int siteNumber)
        {
            return _componentSimpleProductRepository.GetAllBySiteNumber(siteNumber);
        }

        public ComponentSimpleProduct GetBySiteNumber(int siteNumber)
        {
            return _componentSimpleProductRepository.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentSimpleProduct> GetAllByUserId(string userId)
        {
            return _componentSimpleProductRepository.GetAllByUserId(userId);
        }

        public ComponentSimpleProduct GetById(Guid id, string userId)
        {
            return _componentSimpleProductRepository.GetById(id, userId);
        }

        public ComponentSimpleProduct GetByTerm(string title, string userId)
        {
            return _componentSimpleProductRepository.GetByTerm(title, userId);
        }

        public void AddBy(ComponentSimpleProduct componentSimpleProduct)
        {
            _componentSimpleProductRepository.AddBy(componentSimpleProduct);
        }

        public void UpdateBy(ComponentSimpleProduct componentSimpleProduct)
        {
            _componentSimpleProductRepository.UpdateBy(componentSimpleProduct);
        }

        public void DeleteAll(string userId)
        {
            _componentSimpleProductRepository.DeleteAll(userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentSimpleProductRepository.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentSimpleProduct> GetByImageIdAsync(Guid imageId)
        {
            return await _componentSimpleProductRepository.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentSimpleProduct> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentSimpleProductRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSimpleProduct>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentSimpleProductRepository.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSimpleProduct>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSimpleProductRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSimpleProduct> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSimpleProductRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSimpleProduct> GetByTermAsync(string term, string userId)
        {
            return await _componentSimpleProductRepository.GetByTermAsync(term, userId);
        }


        // Async Methods for store
        public async Task<SimpleProduct> GetByIdAsync(int siteNumber, Guid id)
        {
            return await _componentSimpleProductRepository.GetByIdAsync(siteNumber, id);
        }

        public async Task<IEnumerable<Guid>> GetListProductIdAsync(int siteNumber, int take)
        {
            return await _componentSimpleProductRepository.GetListProductIdAsync(siteNumber, take);
        }

        public async Task<IEnumerable<SimpleProduct>> GetByTitleAsync(int siteNumber, string name, int take)
        {
            return await _componentSimpleProductRepository.GetByTitleAsync(siteNumber, name, take);
        }

        public async Task<IEnumerable<SimpleProduct>> GetByCategoryAsync(int siteNumber, int category, int take)
        {
            return await _componentSimpleProductRepository.GetByCategoryAsync(siteNumber, category, take);
        }

        public async Task<IEnumerable<SimpleProduct>> GetBySubCategoryAsync(int siteNumber, int subCategory, int take)
        {
            return await _componentSimpleProductRepository.GetBySubCategoryAsync(siteNumber, subCategory, take);
        }

        public async Task<IEnumerable<SimpleProduct>> GetByTagsAsync(int siteNumber, string tags, int take) // decimal priceMin, decimal priceMax,
        {
            return await _componentSimpleProductDapperRepository.GetByTagsAsync(siteNumber, tags, take);
        }

        public async Task<IEnumerable<SimpleProduct>> GetByParametersAsync(int siteNumber, string tags, int category, int subCategory, decimal priceMin, decimal priceMax, int take)
        {
            return await _componentSimpleProductDapperRepository.GetByParametersAsync(siteNumber, tags, category, subCategory, priceMin, priceMax, take);
        }


        // multiplos usuários
        public async Task<IEnumerable<string>> SearchAsync(IEnumerable<int> siteNumber, string terms, int take)
        {
            return await _componentSimpleProductDapperRepository.SearchAsync(siteNumber, terms, take);
        }

        public async Task<StoreDataPage> GetStoreDataPageAsync(IEnumerable<BasicDisplay> basicDisplay, StoreFilter storeFilter, int take)
        {
            return await _componentSimpleProductDapperRepository.GetStoreDataPageAsync(basicDisplay.ToList(), storeFilter, take);
        }  

        public async Task<IEnumerable<SimpleProduct>> GetAllByIdAsync(IEnumerable<Guid> siteNumber, int take)
        {
            return await _componentSimpleProductDapperRepository.GetAllByIdAsync(siteNumber, take);
        }  

        public async Task<IEnumerable<SimpleProduct>> GetAllByCategoryAsync(IEnumerable<int> siteNumber, IEnumerable<int> category, int take)
        {
            return await _componentSimpleProductDapperRepository.GetAllByCategoryAsync(siteNumber, category, take);
        }                       
    }
}
