using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentExtraLinkAppService : IAppServiceBaseT2<ComponentExtraLink>, IComponentAppServiceBaseT2<ComponentExtraLink>, IComponentAppServiceBaseT2Async<ComponentExtraLink>
    {
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(string search, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string link, string textLink, string styleTextLink, string description, string styleDescription);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
