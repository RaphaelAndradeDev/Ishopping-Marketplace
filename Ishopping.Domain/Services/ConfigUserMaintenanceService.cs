using System.Collections.Generic;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;

namespace Ishopping.Domain.Services
{
    public class ConfigUserMaintenanceService : ServiceBaseT2<ConfigUserMaintenance>, IConfigUserMaintenanceService
    {
        private readonly IConfigUserMaintenanceRepository _configUserMaintenanceRepository;
        private readonly IConfigUserMaintenanceDapperRepository _configUserMaintenanceDapperRepository;

        public ConfigUserMaintenanceService(
            IConfigUserMaintenanceRepository configUserMaintenanceRepository,
            IConfigUserMaintenanceDapperRepository configUserMaintenanceDapperRepository)
            : base(configUserMaintenanceRepository)
        {
            _configUserMaintenanceRepository = configUserMaintenanceRepository;
            _configUserMaintenanceDapperRepository = configUserMaintenanceDapperRepository;
        }

        public ConfigUserMaintenance GetByUserId(string userId)
        {
            return _configUserMaintenanceRepository.GetByUserId(userId);
        }

        public ConfigUserMaintenance GetBySiteNumber(int siteNumber)
        {
            return _configUserMaintenanceRepository.GetBySiteNumber(siteNumber);
        }

        public bool GetIsMaintenance(string userId)
        {
            return _configUserMaintenanceRepository.GetIsMaintenance(userId);
        }

        public void RemoveMaintenance()
        {
            _configUserMaintenanceDapperRepository.RemoveMaintenance();
        }

        public void RemoveAll(string userId)
        {
            var userMaintenance = GetByUserId(userId);
            Remove(userMaintenance);
        }              
    }
}
