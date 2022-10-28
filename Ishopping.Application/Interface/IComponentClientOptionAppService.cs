using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentClientOptionAppService : IAppServiceBaseT2<ComponentClientOption>, IOptionAppServiceBaseT1<ComponentClientOption>, IOptionAppServiceBaseT1Async<ComponentClientOption>
    {
        Task<JsonResponse> AppUpdateAsync(string name, string functio, string comment, string projects, string userId);
    }
}
