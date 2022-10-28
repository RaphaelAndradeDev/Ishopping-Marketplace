using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IComponentSimpleProductDapperRepository : IComponentDapperRepositoryBase<ComponentSimpleProduct>
    {
        // Async Methods for store               
        Task<IEnumerable<SimpleProduct>> GetByIdAsync(int siteNumber, Guid id, int take);
        Task<IEnumerable<SimpleProduct>> GetBySiteNumberAsync(int siteNumber, int take);
        Task<IEnumerable<SimpleProduct>> GetByTitleAsync(int siteNumber, string name, int take);
        Task<IEnumerable<SimpleProduct>> GetByCategoryAsync(int siteNumber, int category, int take);
        Task<IEnumerable<SimpleProduct>> GetBySubCategoryAsync(int siteNumber, int subCategory, int take);
        Task<IEnumerable<SimpleProduct>> GetByTagsAsync(int siteNumber, string tags, int take);
        Task<IEnumerable<SimpleProduct>> GetByParametersAsync(int siteNumber, string tags, int category, int subCategory, decimal priceMin, decimal priceMax, int take);


        // multiplos usuários
        Task<IEnumerable<string>> SearchAsync(IEnumerable<int> siteNumber, string terms, int take);
        Task<StoreDataPage> GetStoreDataPageAsync(List<BasicDisplay> basicDisplay, StoreFilter storeFilter, int take);
        Task<IEnumerable<SimpleProduct>> GetAllByIdAsync(IEnumerable<Guid> id, int take);
        Task<IEnumerable<SimpleProduct>> GetAllByCategoryAsync(IEnumerable<int> siteNumber, IEnumerable<int> category, int take);
    }
}
