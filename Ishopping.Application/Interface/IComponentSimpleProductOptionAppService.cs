using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentSimpleProductOptionAppService : IAppServiceBaseT2<ComponentSimpleProductOption>, IOptionAppServiceBaseT1<ComponentSimpleProductOption>, IOptionAppServiceBaseT1Async<ComponentSimpleProductOption>
    {
        Task<JsonResponse> AppUpdateAsync(string name, string category, string brand, string model, string description, string price, string userId);
    }
}
