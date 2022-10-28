using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentThumbnailAppService : IAppServiceBaseT2<ComponentThumbnail>, IComponentAppServiceBaseT2<ComponentThumbnail>, IComponentAppServiceBaseT2Async<ComponentThumbnail>
    {
        ComponentThumbnail GetByImageId(Guid imageId);

        // Async Methods
        Task<ComponentThumbnail> GetByImageIdAsync(Guid imageId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string category, string icon, string webSite, string imageFileName);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
