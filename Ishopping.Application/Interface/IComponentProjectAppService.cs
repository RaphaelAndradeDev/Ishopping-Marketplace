using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentProjectAppService : IAppServiceBaseT2<ComponentProject>, IComponentAppServiceBaseT2<ComponentProject>, IComponentAppServiceBaseT2Async<ComponentProject>
    {
        ComponentProject GetByImageId(Guid imageId);
        void AddBy(ComponentProject componentProject);
        void UpdateBy(ComponentProject componentProject);
       
        // Async Methods
        Task<ComponentProject> GetByImageIdAsync(Guid imageId);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string name, string styleName, string title, string styleTitle, string client, string styleClient, string description, string styleDescription, string category, string styleCategory, string team, string styleTeam, string webSite, string urlVideo, string date, string img1, string img2, string img3);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
