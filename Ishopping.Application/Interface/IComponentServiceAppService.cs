using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentServiceAppService : IAppServiceBaseT2<ComponentService>, IComponentAppServiceBaseT1<ComponentService>, IComponentAppServiceBaseT1Async<ComponentService>
    {
        ComponentService GetByImageId(Guid imageId);        

        // Async Methods
        Task<ComponentService> GetByImageIdAsync(Guid imageId);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string description, string styleDescription, string imageFileName);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
