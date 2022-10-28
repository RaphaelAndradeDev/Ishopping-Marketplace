using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IContentListOptionAppService : IAppServiceBaseT2<ContentListOption>, IOptionAppServiceBaseT1<ContentListOption>, IOptionAppServiceBaseT1Async<ContentListOption>
    {
        Task<JsonResponse> AppUpdateAsync(string lista, string userId);
    }
}
