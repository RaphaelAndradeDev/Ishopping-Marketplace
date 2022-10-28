using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IConfigUserMaintenanceRepository : IRepositoryBaseT2<ConfigUserMaintenance>
    {
        ConfigUserMaintenance GetByUserId(string userId);
        ConfigUserMaintenance GetBySiteNumber(int siteNumber);
        bool GetIsMaintenance(string userId);
    }
}
