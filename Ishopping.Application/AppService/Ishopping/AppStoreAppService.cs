using Ishopping.Application.Interface;
using Ishopping.Application.ViewModel.Ishopping;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Ishopping.Application.AppService.Ishopping
{
    public class AppStoreAppService : IAppStoreAppService
    {
        private readonly AdminImageGalleryService _adminImageGalleryService;
        private readonly IConfigUserDisplayService _configUserDisplay;
        private readonly IContentTextService _contentTextService;
        private readonly IContentButtonService _contentButtonService;
        private readonly IContentVideoService _contentVideoService;
        private readonly IConfigUserViewItemService _configUserViewItemService;      
        private readonly IComponentPostService _componentPostService;
        private readonly IComponentSimpleProductService _componentSimpleProductService;
        private readonly IUserImageGalleryService _userImageGalleryService;
        private readonly IUserRegisterProfileService _userRegisterProfileService;


        public AppStoreAppService(
            AdminImageGalleryService adminImageGalleryService,
            IConfigUserDisplayService configUserDisplay,
            IContentTextService contentTextService,
            IContentButtonService contentButtonService,
            IContentVideoService contentVideoService,
            IConfigUserViewItemService configUserViewItemService,
            IComponentActivityService componentActivityService,
            IComponentPostService componentPostService,
            IComponentSimpleProductService componentSimpleProductService,
            IUserImageGalleryService userImageGalleryService,
            IUserRegisterProfileService userRegisterProfileService)
        {
            _adminImageGalleryService = adminImageGalleryService;
            _configUserDisplay = configUserDisplay;
            _contentTextService = contentTextService;
            _contentButtonService = contentButtonService;
            _contentVideoService = contentVideoService;
            _configUserViewItemService = configUserViewItemService;      
            _componentPostService = componentPostService;
            _componentSimpleProductService = componentSimpleProductService;
            _userImageGalleryService = userImageGalleryService;
            _userRegisterProfileService = userRegisterProfileService;
        }


        // Buscas
        public async Task<IEnumerable<string>> SearchAsync(string siteNumber, string terms)
        {           
            return await _componentSimpleProductService.SearchAsync(ConvertStringToInt(siteNumber, 60), terms, 60);
        }        

        // Inicio da página
        public AppStoreViewModel GetAppStore()
        {         
            return new AppStoreViewModel();       
        }

        public AppStoreViewModel GetAppStore(string term, int? category, int? subCategory) 
        {
            return new AppStoreViewModel(term, category, subCategory);
        }

        // Carregamento da página (index, filter)       
        public async Task<StoreDataPage> GetDataPageAsync(double lat, double lon, string storeFilter)
        {
            var _storeFilter = string.IsNullOrEmpty(storeFilter) ? new StoreFilter() : new JavaScriptSerializer().Deserialize<StoreFilter>(storeFilter);
            return await _componentSimpleProductService.GetStoreDataPageAsync(
                await _configUserDisplay.GetAllBasicByGeolocationAsync(lat, lon), _storeFilter, 300);
        }

        // Carregamento da página filter com filtros
        public async Task<StoreDataPage> GetAppStoreByParametersAsync(string siteNumber, string storeFilter)
        {
            var _storeFilter = string.IsNullOrEmpty(storeFilter) ? new StoreFilter() : new JavaScriptSerializer().Deserialize<StoreFilter>(storeFilter);
            var basicDisplay = new JavaScriptSerializer().Deserialize<List<BasicDisplay>>(siteNumber);
            basicDisplay.ForEach(x => x.RemoveProductDataPage());         
            return await _componentSimpleProductService.GetStoreDataPageAsync(basicDisplay, _storeFilter, 300);
        }

        // Carregamento do filtro da página filter 
        public AppStorePartialPageFilterViewModel GetPartialPageFilterAsync(string productDataFilter)
        {
            var _productDataFilter = new JavaScriptSerializer().Deserialize<IEnumerable<ProductDataPage>>(productDataFilter);
            return new AppStorePartialPageFilterViewModel(_productDataFilter);
        }        
        
        // Itens por página
        public async Task<AppStoreProductListT1ViewModel> GetProductT1Async(string productIds, int currentPage, int productCount)
        {
            return new AppStoreProductListT1ViewModel(await _componentSimpleProductService.GetAllByIdAsync(ConvertStringToGuids(productIds), 300), currentPage, productCount);
        }

        public async Task<AppStoreProductListT2ViewModel> GetProductT2Async(string siteNumber, string category)
        {
            return category == "00" ?
                new AppStoreProductListT2ViewModel() :
                new AppStoreProductListT2ViewModel(await _componentSimpleProductService.GetAllByCategoryAsync(ConvertStringToInt(siteNumber, 60), ConvertStringToInt(category, 3), 16));
        }

        public async Task<AppStoreProductListT3ViewModel> GetProductT3Async(string productIds, int currentPage, int productCount, int sortBy)
        {
            return new AppStoreProductListT3ViewModel(await _componentSimpleProductService.GetAllByIdAsync(ConvertStringToGuids(productIds), 300), currentPage, productCount, sortBy);
        }

        public AppStoreProductListT4ViewModel GetProductT4Async(string category)
        {
            return new AppStoreProductListT4ViewModel(ConvertStringToInt(category, 3));
        }



        // Store users
        public async Task<AppStoreMainViewModel> GetAppStoreMainAsync(int siteNumber)
        {
            return new AppStoreMainViewModel(await _userRegisterProfileService.GetProfileContactAsync(siteNumber));
        }

        public async Task<AppStoreItemViewModel> GetAppStoreItemAsync(int siteNumber, Guid id)
        {
            return new AppStoreItemViewModel(
                await _componentSimpleProductService.GetByIdAsync(siteNumber, id),
                await _userRegisterProfileService.GetProfileContactAsync(siteNumber));
        }

        public async Task<IEnumerable<Guid>> GetListProductIdAsync(int siteNumber)
        {
            return await _componentSimpleProductService.GetListProductIdAsync(siteNumber, 300);
        }


        // Private Methods
        private IEnumerable<Guid> ConvertStringToGuids(string str)
        {        
            foreach (var guid in str.Split(','))
            {
                yield return Guid.Parse(guid);
            }
        }

        private IEnumerable<int> ConvertStringToInt(string str, int take)
        {          
            foreach (var item in str.Split(',').Distinct().Take(take))
            {
                yield return Convert.ToInt32(item);
            }
        }
    }
}
