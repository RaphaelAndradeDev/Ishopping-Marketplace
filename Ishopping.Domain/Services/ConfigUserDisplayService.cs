using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.ApplicationClass;

namespace Ishopping.Domain.Services
{
    public class ConfigUserDisplayService : ServiceBaseT2<ConfigUserDisplay>, IConfigUserDisplayService
    {
        private readonly IConfigUserDisplayRepository _configUserDisplayRepository;
        private readonly IConfigUserDisplayDapperRepository _configUserDisplayDapperRepository;

        public ConfigUserDisplayService(
            IConfigUserDisplayRepository configUserDisplayRepository,
            IConfigUserDisplayDapperRepository configUserDisplayDapperRepository)
            : base(configUserDisplayRepository)
        {
            _configUserDisplayRepository = configUserDisplayRepository;
            _configUserDisplayDapperRepository = configUserDisplayDapperRepository;
        }
        
        public ConfigUserDisplay GetByUserId(string userId)
        {
            return _configUserDisplayRepository.GetByUserId(userId);
        }

        public ConfigUserDisplay GetByImageId(Guid imageId)
        {
            return _configUserDisplayRepository.GetByImageId(imageId);
        }

        public ConfigUserDisplay GetBySiteNumber(int siteNumber)
        {
            return _configUserDisplayRepository.GetBySiteNumber(siteNumber);
        }

        public void SetIsMaintenance(string userId, bool isMaintenance)
        {
            _configUserDisplayRepository.SetIsMaintenance(userId, isMaintenance);
        }

        public void ConfigUserDisplayProfileUpdate(UserRegisterProfile userRegisterProfile)
        {
            var display = _configUserDisplayRepository.GetByUserId(userRegisterProfile.IdUser);
            if (display != null)
            {
                display.Change(userRegisterProfile);
                _configUserDisplayRepository.Update(display);
            }
        }

        public void ConfigUserDisplayPlanUpdate(string userId, string action, string controller, bool blocked, int displayValue, bool maintenance)
        {
            var display = _configUserDisplayRepository.GetByUserId(userId);
            if (display != null)
            {
                display.Change(action, controller, blocked, displayValue, maintenance);
                _configUserDisplayRepository.Update(display);
            }
        }


        // Async Methods
        public async Task<ConfigUserDisplay> GetByUserIdAsync(string userId)
        {
            return await _configUserDisplayRepository.GetByUserIdAsync(userId);
        }

        public async Task<ConfigUserDisplay> GetByImageIdAsync(Guid imageId)
        {
            return await _configUserDisplayRepository.GetByImageIdAsync(imageId);
        }

        public async Task<ConfigUserDisplay> GetBySiteNumberAsync(int siteNumber)
        {
            return await _configUserDisplayRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ConfigUserDisplay>> GetAllByGeolocationAsync(double latitude, double longitude)
        {
            return await _configUserDisplayDapperRepository.GetAllByGeolocationAsync(latitude, longitude);
        }

        public async Task<IEnumerable<BasicDisplay>> GetAllBasicByGeolocationAsync(double latitude, double longitude)
        {
            return await _configUserDisplayDapperRepository.GetAllBasicByGeolocationAsync(latitude, longitude);
        }

        public async Task<IEnumerable<ConfigUserDisplay>> GetBySearchAsync(string semantic, string address)
        {
            return await _configUserDisplayDapperRepository.GetBySearchAsync(semantic, address);
        }

        public async Task<IEnumerable<ConfigUserDisplay>> GetSpecificAsync(string specific)
        {
            return await _configUserDisplayDapperRepository.GetSpecificAsync(specific);
        }

        public async Task<IEnumerable<string>> SearchBySemanticAsync(string term)
        {
            return await _configUserDisplayDapperRepository.SearchBySemanticAsync(term);
        }

        public async Task<IEnumerable<string>> SearchByAddressAsync(string term)
        {
            return await _configUserDisplayDapperRepository.SearchByAddressAsync(term);
        }

        public async Task<IEnumerable<string>> SearchSpecificAsync(string term)
        {
            return await _configUserDisplayDapperRepository.SearchSpecificAsync(term);
        }

        public async Task<IEnumerable<string>> SearchSpecificAdressAsync(string term)
        {
            return await _configUserDisplayDapperRepository.SearchSpecificAdressAsync(term);
        }        
    
    }
}
