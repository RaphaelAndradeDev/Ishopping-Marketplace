using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class UserSerializeViewDataAppService : AppServiceBaseT2<UserSerializeViewData>, IUserSerializeViewDataAppService
    {
        private readonly IConfigUserMaintenanceService _configUserMaintenanceService;
        private readonly IUserRegisterProfileService _userRegisterProfileService;
        private readonly IUserSerializeViewDataService _userSerializeViewDataService;

        public UserSerializeViewDataAppService(
            IConfigUserMaintenanceService configUserMaintenanceService,
            IUserRegisterProfileService userRegisterProfileService,
            IUserSerializeViewDataService userSerializeViewDataService)
            : base(userSerializeViewDataService)
        {
            _configUserMaintenanceService = configUserMaintenanceService;
            _userRegisterProfileService = userRegisterProfileService;
            _userSerializeViewDataService = userSerializeViewDataService;
        }

        public UserSerializeViewData GetBySiteNumber(int siteNumber, int viewCod)
        {
            return _userSerializeViewDataService.GetBySiteNumber(siteNumber, viewCod);
        }


        // Async Methods
        public async Task<UserSerializeViewData> GetBySiteNumberAsync(int siteNumber, int viewCod)
        {
            return await _userSerializeViewDataService.GetBySiteNumberAsync(siteNumber, viewCod);
        }

        // Others Methods
        public void Persist(string userId, int siteNumber, int viewCod, string serialize)
        {
            var userSerialize = _userSerializeViewDataService.GetByUserId(userId, viewCod);
            if(userSerialize != null)
            {
                userSerialize.Change(serialize);
                _userSerializeViewDataService.Persist(userSerialize);
            }
            else
            {
                var profile = _userRegisterProfileService.GetByUserId(userId);
                userSerialize = new UserSerializeViewData(userId, siteNumber, viewCod, profile.IsBlock(), serialize);
                _userSerializeViewDataService.Persist(userSerialize);
            }            
        }

        public bool IsMaintenance(int siteNumber)
        {
            var userMaintenance = _configUserMaintenanceService.GetBySiteNumber(siteNumber);
            if (DateTime.Now > userMaintenance.DateReturn)
            {
                userMaintenance.SetIsMaintenance(false);
                _configUserMaintenanceService.Update(userMaintenance);
                return false;
            }
            return true;
        }
    }
}
