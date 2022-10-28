using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentSimpleProductService : IServiceBaseT2<ComponentSimpleProduct>, IComponentServiceBaseT2<ComponentSimpleProduct>, IComponentServiceBaseT2Async<ComponentSimpleProduct>
    {

        void AddBy(ComponentSimpleProduct componentSimpleProduct);
        void UpdateBy(ComponentSimpleProduct componentSimpleProduct);
        ComponentSimpleProduct GetByImageId(Guid imageId);

        // Async Methods 
        Task<ComponentSimpleProduct> GetByImageIdAsync(Guid imageId);

        // Async Methods for store               
        Task<SimpleProduct> GetByIdAsync(int siteNumber, Guid id);        
        Task<IEnumerable<Guid>> GetListProductIdAsync(int siteNumber, int take);

        Task<IEnumerable<SimpleProduct>> GetByTitleAsync(int siteNumber, string name, int take);
        Task<IEnumerable<SimpleProduct>> GetByCategoryAsync(int siteNumber, int category, int take);
        Task<IEnumerable<SimpleProduct>> GetBySubCategoryAsync(int siteNumber, int subCategory, int take);
        Task<IEnumerable<SimpleProduct>> GetByTagsAsync(int siteNumber, string tags, int take);
        Task<IEnumerable<SimpleProduct>> GetByParametersAsync(int siteNumber, string tags, int category, int subCategory, decimal priceMin, decimal priceMax, int take);

        // multiplos usuários
        Task<IEnumerable<string>> SearchAsync(IEnumerable<int> siteNumber, string terms, int take);

        Task<StoreDataPage> GetStoreDataPageAsync(IEnumerable<BasicDisplay> basicDisplay, StoreFilter storeFilter, int take); 

        Task<IEnumerable<SimpleProduct>> GetAllByIdAsync(IEnumerable<Guid> id, int take);       
        Task<IEnumerable<SimpleProduct>> GetAllByCategoryAsync(IEnumerable<int> siteNumber, IEnumerable<int> category, int take);        
    }
}
