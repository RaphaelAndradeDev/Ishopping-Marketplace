using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentPanelAppService : IAppServiceBaseT2<ComponentPanel>, IComponentAppServiceBaseT1<ComponentPanel>, IComponentAppServiceBaseT1Async<ComponentPanel>
    {
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(string search, int position, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string text, string styleText, string icon);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
