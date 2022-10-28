using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentPanelOptionAppService : IAppServiceBaseT2<ComponentPanelOption>, IOptionAppServiceBaseT1<ComponentPanelOption>, IOptionAppServiceBaseT1Async<ComponentPanelOption>
    {
        Task<JsonResponse> AppUpdateAsync(string title, string text, string userId);
    }
}
