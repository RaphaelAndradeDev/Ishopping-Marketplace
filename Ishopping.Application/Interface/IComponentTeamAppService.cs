using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentTeamAppService : IAppServiceBaseT2<ComponentTeam>, IComponentAppServiceBaseT2<ComponentTeam>, IComponentAppServiceBaseT2Async<ComponentTeam>
    {
        ComponentTeam GetByImageId(Guid imageId);
        AdminSocialNetWork GetAdminSocialNetworks(string rede, int templateCod);

        // Async Methods
        Task<ComponentTeam> GetByImageIdAsync(Guid imageId);
        Task<object> GetDefaoutStyleAsync(string userId);        
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string name, string styleName, string functio, string styleFunctio, string description, string styleDescription, string imageFileName);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
        Task<JsonDelete> AppDeleteSnAsync(string id, string userId);
    }
}
