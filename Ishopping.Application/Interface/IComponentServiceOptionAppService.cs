using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentServiceOptionAppService : IAppServiceBaseT2<ComponentServiceOption>, IOptionAppServiceBaseT1<ComponentServiceOption>, IOptionAppServiceBaseT1Async<ComponentServiceOption>
    {
        Task<JsonResponse> AppUpdateAsync(string title, string description, string userId);
    }
}
