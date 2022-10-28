using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentPortofolioAppService : IAppServiceBaseT2<ComponentPortofolio>, IComponentAppServiceBaseT1<ComponentPortofolio>, IComponentAppServiceBaseT1Async<ComponentPortofolio>
    {
        ComponentPortofolio GetByImageId(Guid imageId);

        // Async Methods
        Task<ComponentPortofolio> GetByImageIdAsync(Guid imageId);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, bool displayOnPage, bool displayOnlyPage, bool portfolioHead, bool portfolioChild, int position, string title, string styleTitle, string description, string styleDescription, string category, string styleCategory, string subCategory, string list, string styleList, string tags, string imageFileName);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);        
    }
}
