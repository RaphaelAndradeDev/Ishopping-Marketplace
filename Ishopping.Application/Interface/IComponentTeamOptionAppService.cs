using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentTeamOptionAppService : IAppServiceBaseT2<ComponentTeamOption>, IOptionAppServiceBaseT1<ComponentTeamOption>, IOptionAppServiceBaseT1Async<ComponentTeamOption>
    {
        Task<JsonResponse> AppUpdateAsync(string name, string functio, string description, string userId);
    }
}
