using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentClientAppService : IAppServiceBaseT2<ComponentClient>, IComponentAppServiceBaseT2<ComponentClient>, IComponentAppServiceBaseT2Async<ComponentClient>
    {
        // Sync Methods
        ComponentClient GetByImageId(Guid imageId);
        
        // Async Methods
        Task<ComponentClient> GetByImageIdAsync(Guid imageId);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string name, string styleName, string functio, string styleFunction, string comment, string styleComment, string project, string styleProject, string siteOficial, string fileName);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
