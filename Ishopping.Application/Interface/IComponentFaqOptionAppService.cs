using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentFaqOptionAppService : IAppServiceBaseT2<ComponentFaqOption>, IOptionAppServiceBaseT1<ComponentFaqOption>, IOptionAppServiceBaseT1Async<ComponentFaqOption>
    {
        Task<JsonResponse> AppUpdateAsync(string pergunta, string resposta, string userId);
    }
}
