using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IConfigUserMaintenanceService : IServiceBaseT2<ConfigUserMaintenance>
    {
        ConfigUserMaintenance GetByUserId(string userId);
        ConfigUserMaintenance GetBySiteNumber(int siteNumber);
        bool GetIsMaintenance(string userId);
        void RemoveMaintenance();
        void RemoveAll(string userId);
    }
}
