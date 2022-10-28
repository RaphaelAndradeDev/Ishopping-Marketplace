using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentSummaryAppService : IAppServiceBaseT2<ComponentSummary>, IComponentAppServiceBaseT1<ComponentSummary>, IComponentAppServiceBaseT1Async<ComponentSummary>
    {
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(string search, int position, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string category, string styleCategory, string description, string styleDescription);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
