using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentScopeAppService : IAppServiceBaseT2<ComponentScope>, IComponentAppServiceBaseT1<ComponentScope>, IComponentAppServiceBaseT1Async<ComponentScope>
    {
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(string search, int position, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string category, string styleCategory, string description, string styleDescription, string icon);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
