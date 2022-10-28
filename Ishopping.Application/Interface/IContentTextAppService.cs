using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IContentTextAppService : IAppServiceBaseT2<ContentText>, IContentAppServiceBaseT1<ContentText>, IContentAppServiceBaseT1Async<ContentText>
    {
        // Sync Methods
        IEnumerable<string> Search(string startsWith, int viewCod, string userId);
        ContentText GetBy(int viewCod, string term, string userId);

        // Async Methods
        Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId);
        Task<ContentText> GetByAsync(int viewCod, string term, string userId);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(int viewCod, int position, string userId);
        Task<object> GetObjetoAsync(int viewCod, string search, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int viewCod, int position, string text32, string styleText32, string text512, string styleText512, string text5120, string styleText5120);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
