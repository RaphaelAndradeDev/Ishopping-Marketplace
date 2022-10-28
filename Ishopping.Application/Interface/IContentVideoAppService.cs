using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IContentVideoAppService : IAppServiceBaseT2<ContentVideo>, IContentAppServiceBaseT1<ContentVideo>, IContentAppServiceBaseT1Async<ContentVideo>
    {
        // Async Methods
        Task<object> GetObjetoAsync(int viewCod, int position, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int viewCod, int position, string url);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
