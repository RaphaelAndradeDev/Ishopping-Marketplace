using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IContentButtonOptionAppService : IAppServiceBaseT2<ContentButtonOption>, IOptionAppServiceBaseT1<ContentButtonOption>, IOptionAppServiceBaseT1Async<ContentButtonOption>
    {
        Task<JsonResponse> AppUpdateAsync(string textButton, string userId);
    }
}
