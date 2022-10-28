using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentSummaryOptionAppService : IAppServiceBaseT2<ComponentSummaryOption>, IOptionAppServiceBaseT1<ComponentSummaryOption>, IOptionAppServiceBaseT1Async<ComponentSummaryOption>
    {
        Task<JsonResponse> AppUpdateAsync(string title, string catetory, string description, string userId);
    }
}
