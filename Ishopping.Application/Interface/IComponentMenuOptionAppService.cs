using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentMenuOptionAppService : IAppServiceBaseT2<ComponentMenuOption>, IOptionAppServiceBaseT1<ComponentMenuOption>, IOptionAppServiceBaseT1Async<ComponentMenuOption>
    {
        Task<JsonResponse> AppUpdateAsync(string title, string description, string price, string userId);
    }
}
