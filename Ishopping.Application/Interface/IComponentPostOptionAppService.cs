using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentPostOptionAppService : IAppServiceBaseT2<ComponentPostOption>, IOptionAppServiceBaseT1<ComponentPostOption>, IOptionAppServiceBaseT1Async<ComponentPostOption>
    {
        Task<JsonResponse> AppUpdateAsync(string autor, string categoria, string titulo, string subTitulo, string paragrafo, string userId);
    }
}
