using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IContentButtonAppService : IAppServiceBaseT2<ContentButton>, IContentAppServiceBaseT1<ContentButton>, IContentAppServiceBaseT1Async<ContentButton>
    {
        // Sync Methods
        IEnumerable<string> Search(string startsWith, int viewCod, string userId);
        ContentButton GetBy(int viewCod, string term, string userId);

        // Async Methods
        Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId);
        Task<ContentButton> GetByAsync(int viewCod, string term, string userId);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(int viewCod, int position, string userId);
        Task<object> GetObjetoAsync(int viewCod, string search, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int viewCod, int position, string textButton, string styleTextButton, string textURL);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
