using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentMenuAppService : IAppServiceBaseT2<ComponentMenu>, IComponentAppServiceBaseT2<ComponentMenu>, IComponentAppServiceBaseT2Async<ComponentMenu>
    {
        ComponentMenu GetByImageId(Guid imageId);

        // Async Methods
        Task<ComponentMenu> GetByImageIdAsync(Guid imageId);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string title, string styleTitle, string description, string styleDescription, string category, decimal price, string stylePrice, bool isDynamic, string dayOfWeek, string imageFileName);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);

    
    }
}
