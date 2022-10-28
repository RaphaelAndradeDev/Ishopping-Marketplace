using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentFeaturesOptionAppService : IAppServiceBaseT2<ComponentFeaturesOption>, IOptionAppServiceBaseT1<ComponentFeaturesOption>, IOptionAppServiceBaseT1Async<ComponentFeaturesOption>
    {
        Task<JsonResponse> AppUpdateAsync(string title, string count, string description, string userId);
    }
}
