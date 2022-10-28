using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentScopeOptionAppService : IAppServiceBaseT2<ComponentScopeOption>, IOptionAppServiceBaseT1<ComponentScopeOption>, IOptionAppServiceBaseT1Async<ComponentScopeOption>
    {
        Task<JsonResponse> AppUpdateAsync(string title, string category, string description, string userId);
    }
}
