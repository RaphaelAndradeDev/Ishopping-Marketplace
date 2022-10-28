using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentSimpleProductRepository : IRepositoryBaseT2<ComponentSimpleProduct>, IComponentRepositoryBaseT2<ComponentSimpleProduct>, IComponentRepositoryBaseT2Async<ComponentSimpleProduct>
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

        // multiplos usuários
        Task<IEnumerable<string>> SearchAsync(IEnumerable<int> siteNumber, string terms, int take);
        Task<StoreDataPage> GetStoreDataPageAsync(List<BasicDisplay> basicDisplay, StoreFilter storeFilter, int take);     
        Task<IEnumerable<SimpleProduct>> GetAllByIdAsync(IEnumerable<Guid> id, int take);
        Task<IEnumerable<SimpleProduct>> GetAllByCategoryAsync(IEnumerable<int> siteNumber, IEnumerable<int> category, int take);        
    }
}
