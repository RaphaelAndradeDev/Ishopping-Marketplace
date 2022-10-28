using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentFeaturesAppService : IAppServiceBaseT2<ComponentFeatures>, IComponentAppServiceBaseT2<ComponentFeatures>, IComponentAppServiceBaseT2Async<ComponentFeatures>
    {
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(string search, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string title, string styleTitle, string icon, int count, string styleCount, string description, string styleDescription);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
