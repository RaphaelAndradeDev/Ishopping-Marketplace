using Ishopping.Application.Interface;
using Ishopping.Application.SectionModels.BasicModels;
using Ishopping.Application.SectionModels.Content;
using Ishopping.Application.SectionModels.User;
using Ishopping.Application.ViewModel.Ishopping;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Application.AppService.Ishopping
{
    public class AppPortfolioAppService : IAppPortfolioAppService
    {
        private readonly AdminImageGalleryService _adminImageGalleryService;
        private readonly IConfigUserDisplayService _configUserDisplay;
        private readonly IContentTextService _contentTextService;
        private readonly IContentButtonService _contentButtonService;
        private readonly IContentVideoService _contentVideoService;
        private readonly IConfigUserViewItemService _configUserViewItemService;
        private readonly IComponentActivityService _componentActivityService;
        private readonly IComponentPostService _componentPostService;
        private readonly IComponentPortofolioService _componentPortofolioService;
        private readonly IUserImageGalleryService _userImageGalleryService;
        private readonly IUserRegisterProfileService _userRegisterProfileService;
        

        public AppPortfolioAppService(
            AdminImageGalleryService adminImageGalleryService,
            IConfigUserDisplayService configUserDisplay,
            IContentTextService contentTextService,
            IContentButtonService contentButtonService,
            IContentVideoService contentVideoService,
            IConfigUserViewItemService configUserViewItemService,
            IComponentActivityService componentActivityService,
            IComponentPostService componentPostService,
            IComponentPortofolioService componentPortofolioService,
            IUserImageGalleryService userImageGalleryService,
            IUserRegisterProfileService userRegisterProfileService)
        {
            _adminImageGalleryService = adminImageGalleryService;
            _configUserDisplay = configUserDisplay;
            _contentTextService = contentTextService;
            _contentButtonService = contentButtonService;
            _contentVideoService = contentVideoService;
            _configUserViewItemService = configUserViewItemService;
            _componentActivityService = componentActivityService;
            _componentPostService = componentPostService;
            _componentPortofolioService = componentPortofolioService;
            _userImageGalleryService = userImageGalleryService;
            _userRegisterProfileService = userRegisterProfileService;
        }

        public async Task<AppPortfolioViewModel> GetAppPortfolioAsync(double lat = 0, double lon = 0)
        {
            var result = await _configUserDisplay.GetAllBasicByGeolocationAsync(lat, lon);                 
            return new AppPortfolioViewModel(
                await _componentPortofolioService.GetAllBySiteNumberAsync(result.Select(x => x.SiteNumber), 18));        
        }

        public async Task<AppPortfolioViewModel> GetAppPortfolioByCategoryAsync(string category)
        {         
            return new AppPortfolioViewModel(
                await _componentPortofolioService.GetAllByCategoryAsync(category, 18), category);
        }

        public async Task<AppPortfolioViewModel> GetAppPortfolioByTagAsync(string tag)
        {         
            return new AppPortfolioViewModel(
                await _componentPortofolioService.GetAllByTagAsync(tag, 18), tag);
        }

        // Portfolio Users
        public async Task<AppPortfolioMainViewModel> GetAppPortfolioMainAsync(int siteNumber)
        {
            int[] viewCod = new int[] {21, 29, 30};    
            var basicUserViewItens = await _configUserViewItemService.GetAllBasicViewItemAsync(viewCod, siteNumber);
            
            return new AppPortfolioMainViewModel(
                new ContentTextSectionModel(siteNumber, _contentTextService, 1111, "1,2,1,1,1,1,2"),
                new ContentButtonSectionModel(siteNumber, _contentButtonService, 1111, 2),
                new ContentVideoSectionModel(siteNumber, _contentVideoService, 1111, 1),
                new UserImageGallerySectionModel(siteNumber, _userImageGalleryService, _adminImageGalleryService, 1, 1111, 2),
                new BasicActivitySectionModels(siteNumber, _componentActivityService, basicUserViewItens),
                await new BasicPostSectionModels().Execute(siteNumber, _componentPostService, basicUserViewItens),
                await _componentPortofolioService.GetBySiteNumberAsync(siteNumber, 36), 
                basicUserViewItens.First(x => x.ViewTypeCod == 29),
                await _userRegisterProfileService.GetProfileContactAsync(siteNumber));
        }

        public async Task<AppPortfolioCategoryViewModel> GetAppPortfolioCategoryAsync(int siteNumber, string category)
        {
            return new AppPortfolioCategoryViewModel(
                new ContentTextSectionModel(siteNumber, _contentTextService, 1111, "1,2,1,1,1,1,2"),
                new ContentButtonSectionModel(siteNumber, _contentButtonService, 1111, 2),
                await _componentPortofolioService.GetByCategoryAsync(siteNumber, category, 32),
                await _userRegisterProfileService.GetProfileContactAsync(siteNumber));
        }

        public async Task<AppPortfolioSubCategoryViewModel> GetAppPortfolioSubCategoryAsync(int siteNumber, string category, string subCategory) 
        {
            return new AppPortfolioSubCategoryViewModel(
                new ContentTextSectionModel(siteNumber, _contentTextService, 1111, "1,2,1,1,1,1,2"),
                new ContentButtonSectionModel(siteNumber, _contentButtonService, 1111, 2),
                await _componentPortofolioService.GetByCategoryAsync(siteNumber, category, subCategory, 36),
                await _userRegisterProfileService.GetProfileContactAsync(siteNumber));
        }

        public async Task<AppPortfolioItemViewModel> GetAppPortfolioItemAsync(int siteNumber, Guid id)
        {
            return new AppPortfolioItemViewModel(
                new ContentTextSectionModel(siteNumber, _contentTextService, 1111, "1,2,1,1,1,1,2"),
                new ContentButtonSectionModel(siteNumber, _contentButtonService, 1111, 2),
                await _componentPortofolioService.GetBySiteNumberAsync(siteNumber, 36),
                await _componentPortofolioService.GetByIdAsync(id),
                await _userRegisterProfileService.GetProfileContactAsync(siteNumber));
        }
    }
}
