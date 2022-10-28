using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentExtraLinkOptionAppService : IAppServiceBaseT2<ComponentExtraLinkOption>, IOptionAppServiceBaseT1<ComponentExtraLinkOption>, IOptionAppServiceBaseT1Async<ComponentExtraLinkOption>
    {
        Task<JsonResponse> AppUpdateAsync(string textLink, string description, string userId);
    }
}
