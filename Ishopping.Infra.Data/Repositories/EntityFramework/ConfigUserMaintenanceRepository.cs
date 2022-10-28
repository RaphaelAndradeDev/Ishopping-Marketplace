using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class ConfigUserMaintenanceRepository : RepositoryBaseT2<ConfigUserMaintenance>, IConfigUserMaintenanceRepository
    {
        public ConfigUserMaintenance GetByUserId(string userId)
        {
            return db.ConfigUserMaintenance.FirstOrDefault(b => b.IdUser == userId);    
        }
        
        public ConfigUserMaintenance GetBySiteNumber(int siteNumber)
        {
            return db.ConfigUserMaintenance.FirstOrDefault(x => x.SiteNumber == siteNumber);
        }   
        
        public bool GetIsMaintenance(string userId)
        {
            return db.ConfigUserMaintenance.Any(b => b.IdUser == userId && b.IsMaintenance == true);
        }

        public void RemoveMaintenance()
        {
            db.ConfigUserMaintenance.Where(x => x.DateReturn > DateTime.Now).Select(y => y.IdUser);
        }
    }
}
