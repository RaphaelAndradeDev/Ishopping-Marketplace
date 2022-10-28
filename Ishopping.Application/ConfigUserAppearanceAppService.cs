using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ConfigUserAppearanceAppService : AppServiceBaseT2<ConfigUserAppearance>, IConfigUserAppearanceAppService
    {
        private readonly IConfigUserAppearanceService _configUserAppearanceService;

        public ConfigUserAppearanceAppService(IConfigUserAppearanceService configUserAppearanceService)
            :base(configUserAppearanceService)
        {
            _configUserAppearanceService = configUserAppearanceService;
        }

        public ConfigUserAppearance GetByUserId(string userId)
        {
            return _configUserAppearanceService.GetByUserId(userId);
        }
        
        public ConfigUserAppearance GetBySiteNumber(int siteNumber)
        {
            return _configUserAppearanceService.GetBySiteNumber(siteNumber);
        }

        // Async Methods
        public async Task<ConfigUserAppearance> GetByUserIdAsync(string userId)
        {
            return await _configUserAppearanceService.GetByUserIdAsync(userId);
        }

        public async Task<ConfigUserAppearance> GetBySiteNumberAsync(int siteNumber)
        {
            return await _configUserAppearanceService.GetBySiteNumberAsync(siteNumber);
        }

        public JsonResponse AppUpdate(ConfigUserAppearance configUserAppearance)
        {
            JsonResponse json = new JsonResponse();
            json.Redirect = false;
            json.Serialize = false;

            _configUserAppearanceService.Update(configUserAppearance);
            return json;
        }
  
    }
}
