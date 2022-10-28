using Ishopping.Application.ViewModel.Ishopping;
using Ishopping.Domain.ApplicationClass;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IAppStoreAppService
    {
        // Buscas
        Task<IEnumerable<string>> SearchAsync(string siteNumber, string terms);

        // Inicio da página
        AppStoreViewModel GetAppStore();
        AppStoreViewModel GetAppStore(string term, int? category, int? subCategory);

        // Carregamento da página        
        Task<StoreDataPage> GetDataPageAsync(double lat, double lon, string storeFilter);
        Task<StoreDataPage> GetAppStoreByParametersAsync(string siteNumber, string storeFilter);

        Task<AppStoreProductListT1ViewModel> GetProductT1Async(string productId, int currentPage, int productCount);
        Task<AppStoreProductListT2ViewModel> GetProductT2Async(string siteNumber, string category);
        Task<AppStoreProductListT3ViewModel> GetProductT3Async(string productId, int currentPage, int productCount, int sortBy);
        AppStoreProductListT4ViewModel GetProductT4Async(string category);

        AppStorePartialPageFilterViewModel GetPartialPageFilterAsync(string productDataFilter);              
        

        // Store users
        Task<AppStoreMainViewModel> GetAppStoreMainAsync(int siteNumber);

        Task<AppStoreItemViewModel> GetAppStoreItemAsync(int siteNumber, Guid id);
        Task<IEnumerable<Guid>> GetListProductIdAsync(int siteNumber);
    }
}
