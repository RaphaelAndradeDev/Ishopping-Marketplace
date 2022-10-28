using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentProjectOptionAppService : IAppServiceBaseT2<ComponentProjectOption>, IOptionAppServiceBaseT1<ComponentProjectOption>, IOptionAppServiceBaseT1Async<ComponentProjectOption>
    {
        Task<JsonResponse> AppUpdateAsync(string name, string title, string client, string description, string category, string team, string userId);
    }
}
