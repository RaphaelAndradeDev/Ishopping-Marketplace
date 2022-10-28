using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentSocialNetworkAppService : IAppServiceBaseT2<ComponentSocialNetwork>, IComponentAppServiceBaseT2<ComponentSocialNetwork>, IComponentAppServiceBaseT2Async<ComponentSocialNetwork>
    {
        IEnumerable<string> GetAdminSocialNetworks(string userId);
        AdminSocialNetWork GetAdminSocialNetworks(string rede, int templateCod);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, string rede, string link);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
