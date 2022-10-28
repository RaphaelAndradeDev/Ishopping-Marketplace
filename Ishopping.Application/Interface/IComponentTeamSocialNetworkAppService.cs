using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentTeamSocialNetworkAppService : IAppServiceBaseT2<ComponentTeamSocialNetwork>
    {
        IEnumerable<string> GetAdminSocialNetworks(string userId);
        AdminSocialNetWork GetAdminSocialNetworks(string rede, int templateCod);        
        void DeleteAll(Guid componentTeamId);

        // Async Methods
        Task<JsonResponse> AppUpdateAsync(string id, string idSn, string userId, string link, string rede);

    }
}
