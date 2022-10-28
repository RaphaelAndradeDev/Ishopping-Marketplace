using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IContentTextOptionAppService : IAppServiceBaseT2<ContentTextOption>, IOptionAppServiceBaseT1<ContentTextOption>, IOptionAppServiceBaseT1Async<ContentTextOption>
    {
        Task<JsonResponse> AppUpdateAsync(string text32, string text512, string text5120, string userId);
    }
}
