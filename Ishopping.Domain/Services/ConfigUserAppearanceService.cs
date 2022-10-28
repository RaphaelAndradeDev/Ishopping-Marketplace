using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ConfigUserAppearanceService : ServiceBaseT2<ConfigUserAppearance>, IConfigUserAppearanceService
    {
        private readonly IConfigUserAppearanceRepository _configUserAppearanceRepository;

        public ConfigUserAppearanceService(IConfigUserAppearanceRepository configUserAppearanceRepository)
            : base(configUserAppearanceRepository)
        {
            _configUserAppearanceRepository = configUserAppearanceRepository;
        }

        public ConfigUserAppearance GetByUserId(string userId)
        {
            return _configUserAppearanceRepository.GetByUserId(userId);
        }
        
        public ConfigUserAppearance GetBySiteNumber(int siteNumber)
        {
            return _configUserAppearanceRepository.GetBySiteNumber(siteNumber);
        }


        // Async Methods
        public async Task<ConfigUserAppearance> GetByUserIdAsync(string userId)
        {
            return await _configUserAppearanceRepository.GetByUserIdAsync(userId);
        }

        public async Task<ConfigUserAppearance> GetBySiteNumberAsync(int siteNumber)
        {
            return await _configUserAppearanceRepository.GetBySiteNumberAsync(siteNumber);
        }
    }
}
