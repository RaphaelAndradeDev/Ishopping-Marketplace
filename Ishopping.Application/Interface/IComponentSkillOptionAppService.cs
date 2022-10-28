using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentSkillOptionAppService : IAppServiceBaseT2<ComponentSkillOption>, IOptionAppServiceBaseT1<ComponentSkillOption>, IOptionAppServiceBaseT1Async<ComponentSkillOption>
    {
        Task<JsonResponse> AppUpdateAsync(string category, string description, string level, string userId);
    }
}
