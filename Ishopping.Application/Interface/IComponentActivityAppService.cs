using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentActivityAppService : IAppServiceBaseT2<ComponentActivity>, IComponentAppServiceBaseT1<ComponentActivity>, IComponentAppServiceBaseT1Async<ComponentActivity>
    {
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(string search, int position, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string description, string styleDescription, string icon);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
