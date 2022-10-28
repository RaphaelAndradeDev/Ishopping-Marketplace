using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentSkillAppService : IAppServiceBaseT2<ComponentSkill>, IComponentAppServiceBaseT1<ComponentSkill>, IComponentAppServiceBaseT1Async<ComponentSkill>
    {
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(string search, int position, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string category, string styleCategory, int level, string styleLevel, string description, string styleDescription);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
