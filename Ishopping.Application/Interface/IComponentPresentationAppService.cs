using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentPresentationAppService : IAppServiceBaseT2<ComponentPresentation>, IComponentAppServiceBaseT1<ComponentPresentation>, IComponentAppServiceBaseT1Async<ComponentPresentation>
    {
        ComponentPresentation GetByImageId(Guid imageId);   

        // Async Methods
        Task<ComponentPresentation> GetByImageIdAsync(Guid imageId);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string category, string styleCategory, string icon, string description, string styleDescription, string imageFileName);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
