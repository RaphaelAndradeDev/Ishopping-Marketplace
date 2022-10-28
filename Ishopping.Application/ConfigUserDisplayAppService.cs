using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;
using Ishopping.Application.Common;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ConfigUserDisplayAppService : AppServiceBaseT2<ConfigUserDisplay>, IConfigUserDisplayAppService
    {
        private readonly IAdminViewDataService _adminViewData;
        private readonly IConfigUserDisplayService _configUserDisplayService;
        private readonly IConfigUserMaintenanceService _configUserMaintenance;
        private readonly IUserImageGalleryService _userImageGalleryService;
        private readonly IUserFinancialService _userFinancial;
        private readonly IUserRegisterProfileService _userRegisterProfile;      
        
        public ConfigUserDisplayAppService(
            IAdminViewDataService adminViewData,
            IConfigUserDisplayService configUserDisplayService,
            IConfigUserMaintenanceService configUserMaintenance,
            IUserImageGalleryService userImageGalleryService,
            IUserFinancialService userFinancial,
            IUserRegisterProfileService userRegisterProfile
            )
            :base(configUserDisplayService)
        {
            _configUserDisplayService = configUserDisplayService;
            _configUserMaintenance = configUserMaintenance;
            _userImageGalleryService = userImageGalleryService;
            _userFinancial = userFinancial;
            _userRegisterProfile = userRegisterProfile;
            _adminViewData = adminViewData;
        }

        public ConfigUserDisplay GetByUserId(string userId)
        {
            return _configUserDisplayService.GetByUserId(userId);
        }

        public ConfigUserDisplay GetByImageId(Guid imageId)
        {
            return _configUserDisplayService.GetByImageId(imageId);
        }

        public ConfigUserDisplay GetBySiteNumber(int siteNumber)
        {
            return _configUserDisplayService.GetBySiteNumber(siteNumber);
        }


        // Async Methods
        public async Task<ConfigUserDisplay> GetByUserIdAsync(string userId)
        {
            return await _configUserDisplayService.GetByUserIdAsync(userId);
        }

        public async Task<ConfigUserDisplay> GetByImageIdAsync(Guid imageId)
        {
            return await _configUserDisplayService.GetByImageIdAsync(imageId);
        }

        public async Task<ConfigUserDisplay> GetBySiteNumberAsync(int siteNumber)
        {
            return await _configUserDisplayService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ConfigUserDisplay>> GetAllByGeolocationAsync(double latitude, double longitude)
        {
            return await _configUserDisplayService.GetAllByGeolocationAsync(latitude, longitude);
        }

        public async Task<IEnumerable<ConfigUserDisplay>> GetBySearchAsync(string semantic, string address)
        {
            return await _configUserDisplayService.GetBySearchAsync(semantic, address);
        }

        public async Task<IEnumerable<ConfigUserDisplay>> GetSpecificAsync(string specific)
        {
            return await _configUserDisplayService.GetSpecificAsync(specific);
        }

        public async Task<IEnumerable<string>> SearchBySemanticAsync(string term)
        {
            return await _configUserDisplayService.SearchBySemanticAsync(term);
        }

        public async Task<IEnumerable<string>> SearchByAddressAsync(string term)
        {
            return await _configUserDisplayService.SearchByAddressAsync(term);
        }

        public async Task<IEnumerable<string>> SearchSpecificAsync(string term)
        {
            return await _configUserDisplayService.SearchSpecificAsync(term);
        }

        public async Task<IEnumerable<string>> SearchSpecificAdressAsync(string term)
        {
            return await _configUserDisplayService.SearchSpecificAdressAsync(term);
        }


        // Other Methods
        public JsonResponse AppUpdate(string userId, string title, string message, string imageFileName)
        {          

            JsonResponse json = new JsonResponse();
           
            var imageGallery = _userImageGalleryService.GetBy(12, imageFileName, userId);
            if (imageGallery == null)
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            var display = _configUserDisplayService.GetByUserId(userId);
            if(display != null)
            {
                display.Change(imageGallery.Id, false, title, message);
                _configUserDisplayService.Update(display);
                json.Redirect = display.UserImageGallery.FileName != imageFileName;
            }
            else
            {
                var profile = _userRegisterProfile.GetByUserId(userId);
                bool isMaintenance = _configUserMaintenance.GetBySiteNumber(profile.SiteNumber).IsMaintenance;                          

                var configUserDisplay = new ConfigUserDisplay(imageGallery.Id, "Index", profile.Controller, profile.IsBlock(), profile.Plan, isMaintenance, title, message, profile);
                _configUserDisplayService.Add(configUserDisplay);
                json.Redirect = true;
            }

            json.Serialize = false;            
            return json;
        }

        public void ConfigUserDisplayProfileUpdate(UserRegisterProfile userRegisterProfile)
        {
            _configUserDisplayService.ConfigUserDisplayProfileUpdate(userRegisterProfile);
        }

        public void ConfigUserDisplayPlanUpdate(string userId, string action, string controller, bool blocked, int displayValue, bool maintenance)
        {
            _configUserDisplayService.ConfigUserDisplayPlanUpdate(userId, action, controller, blocked, displayValue, maintenance);
        }
    }
}
