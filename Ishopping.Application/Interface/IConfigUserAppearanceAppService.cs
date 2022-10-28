using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IConfigUserAppearanceAppService : IAppServiceBaseT2<ConfigUserAppearance>
    {
        ConfigUserAppearance GetByUserId(string userId);
        ConfigUserAppearance GetBySiteNumber(int siteNumber);
        JsonResponse AppUpdate(ConfigUserAppearance configUserAppearance);

        // Async Methods
        Task<ConfigUserAppearance> GetByUserIdAsync(string userId);
        Task<ConfigUserAppearance> GetBySiteNumberAsync(int siteNumber);
        
    }
}
