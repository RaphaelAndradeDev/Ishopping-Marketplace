using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentBrandOptionAppService : IAppServiceBaseT2<ComponentBrandOption>, IOptionAppServiceBaseT1<ComponentBrandOption>, IOptionAppServiceBaseT1Async<ComponentBrandOption>
    {
        Task<JsonResponse> AppUpdateAsync(string marca, string comment, string userId);
    }
}
