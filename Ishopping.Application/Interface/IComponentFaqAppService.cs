using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentFaqAppService : IAppServiceBaseT2<ComponentFaq>, IComponentAppServiceBaseT1<ComponentFaq>, IComponentAppServiceBaseT1Async<ComponentFaq>
    {
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(string search, int position, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string pergunta, string stylePergunta, string resposta, string styleResposta, string categoria);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
