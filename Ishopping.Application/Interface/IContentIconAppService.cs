using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IContentIconAppService : IAppServiceBaseT2<ContentIcon>, IContentAppServiceBaseT1<ContentIcon>, IContentAppServiceBaseT1Async<ContentIcon>
    {
        // Sync Methods
        IEnumerable<string> Search(string startsWith, int viewCod, string userId);
        ContentIcon GetBy(int viewCod, string term, string userId);

        // Async Methods
        Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId);
        Task<ContentIcon> GetByAsync(int viewCod, string term, string userId);
        Task<object> GetObjetoAsync(int viewCod, int position, string userId);
        Task<object> GetObjetoAsync(int viewCod, string search, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int viewCod, int position, string icon);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
