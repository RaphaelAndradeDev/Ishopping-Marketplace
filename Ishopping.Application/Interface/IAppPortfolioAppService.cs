using Ishopping.Application.ViewModel.Ishopping;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IAppPortfolioAppService
    {
        Task<AppPortfolioViewModel> GetAppPortfolioAsync(double lat = 0, double lon = 0);
        Task<AppPortfolioViewModel> GetAppPortfolioByCategoryAsync(string category);
        Task<AppPortfolioViewModel> GetAppPortfolioByTagAsync(string tag);

        // Portfolio Users
        Task<AppPortfolioMainViewModel> GetAppPortfolioMainAsync(int siteNumber);
        Task<AppPortfolioCategoryViewModel> GetAppPortfolioCategoryAsync(int siteNumber, string category);
        Task<AppPortfolioSubCategoryViewModel> GetAppPortfolioSubCategoryAsync(int siteNumber, string category, string subCategory);
        Task<AppPortfolioItemViewModel> GetAppPortfolioItemAsync(int siteNumber, Guid id);
    }  
}
