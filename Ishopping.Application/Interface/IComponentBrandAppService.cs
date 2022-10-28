using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentBrandAppService : IAppServiceBaseT2<ComponentBrand>, IComponentAppServiceBaseT2<ComponentBrand>, IComponentAppServiceBaseT2Async<ComponentBrand>
    {    
        ComponentBrand GetByImageId(Guid imageId);
        
        // Async Methods
        Task<ComponentBrand> GetByImageIdAsync(Guid imageId);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string marca, string styleMarca, string comment, string styleComment, string siteOficial, string fileName);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
