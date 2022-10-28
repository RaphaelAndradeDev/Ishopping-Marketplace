using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ConfigUserAppearanceRepository : RepositoryBaseT2<ConfigUserAppearance>, IConfigUserAppearanceRepository
    {
        public ConfigUserAppearance GetByUserId(string userId)
        {
            return db.ConfigUserAppearance.Include("ConfigUserStyleColor").FirstOrDefault(x => x.IdUser == userId);
        }
        
        public ConfigUserAppearance GetBySiteNumber(int siteNumber)
        {
            return db.ConfigUserAppearance.Include("ConfigUserStyleColor").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }


        // Async Methods
        public async Task<ConfigUserAppearance> GetByUserIdAsync(string userId)
        {
            return await db.ConfigUserAppearance.Include("ConfigUserStyleColor").FirstOrDefaultAsync(x => x.IdUser == userId);
        }

        public async Task<ConfigUserAppearance> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ConfigUserAppearance.Include("ConfigUserStyleColor").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }
    }
}
