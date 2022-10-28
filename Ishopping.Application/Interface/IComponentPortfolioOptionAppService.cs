using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentPortfolioOptionAppService : IAppServiceBaseT2<ComponentPortofolioOption>, IOptionAppServiceBaseT1<ComponentPortofolioOption>, IOptionAppServiceBaseT1Async<ComponentPortofolioOption>
    {
        Task<JsonResponse> AppUpdateAsync(string category, string title, string description, string list, string userId);
    }
}
