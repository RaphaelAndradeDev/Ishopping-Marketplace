using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentSimpleProductAppService : IAppServiceBaseT2<ComponentSimpleProduct>, IComponentAppServiceBaseT2<ComponentSimpleProduct>, IComponentAppServiceBaseT2Async<ComponentSimpleProduct>
    {
        ComponentSimpleProduct GetByImageId(Guid imageId);
       
        // Async Methods
        Task<ComponentSimpleProduct> GetByImageIdAsync(Guid imageId);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, bool displayOnPage, bool displayOnlyPage, string name, string styleName, int category, string styleCategory, int subCategory, string brand, string styleBrand, string model, string styleModel, decimal price, string stylePrice, string description, string styleDescription, string tags, string img1, string img2, string img3);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
