using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IContentListAppService : IAppServiceBaseT2<ContentList>, IContentAppServiceBaseT1<ContentList>, IContentAppServiceBaseT1Async<ContentList>
    {
        // Async Methods
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(int viewCod, int position, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int viewCod, int position, string lista, string styleLista);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
