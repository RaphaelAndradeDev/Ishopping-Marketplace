using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentPresentationOptionAppService : IAppServiceBaseT2<ComponentPresentationOption>, IOptionAppServiceBaseT1<ComponentPresentationOption>, IOptionAppServiceBaseT1Async<ComponentPresentationOption>
    {
        Task<JsonResponse> AppUpdateAsync(string title, string category, string description, string userId);
    }
}
