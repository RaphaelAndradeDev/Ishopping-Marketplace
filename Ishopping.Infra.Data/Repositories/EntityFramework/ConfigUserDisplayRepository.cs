using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ishopping.Infra.Data.Repositories
{
    public class ConfigUserDisplayRepository : RepositoryBaseT2<ConfigUserDisplay>, IConfigUserDisplayRepository
    {
        public ConfigUserDisplay GetByUserId(string userId)
        {
            return db.ConfigUserDisplay.Include("UserImageGallery").FirstOrDefault(x => x.IdUser == userId);
        }
        
        public ConfigUserDisplay GetByImageId(Guid imageId)
        {
            return db.ConfigUserDisplay.Include("UserImageGallery").FirstOrDefault(x => x.UserImageGalleryId == imageId);
        }

        public ConfigUserDisplay GetBySiteNumber(int siteNumber)
        {
            return db.ConfigUserDisplay.Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public void SetIsMaintenance(string userId, bool isMaintenance)
        {
            var userMaintenance = db.ConfigUserDisplay.FirstOrDefault(x => x.IdUser == userId);
            if(userMaintenance != null)
            { 
                userMaintenance.SetMaintenance(isMaintenance);
                Update(userMaintenance);
            }
        }


        // Async Methods
        public async Task<ConfigUserDisplay> GetByUserIdAsync(string userId)
        {
            return await db.ConfigUserDisplay.Include("UserImageGallery").FirstOrDefaultAsync(x => x.IdUser == userId);
        }

        public async Task<ConfigUserDisplay> GetByImageIdAsync(Guid imageId)
        {
            return await db.ConfigUserDisplay.Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGalleryId == imageId);
        }

        public async Task<ConfigUserDisplay> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ConfigUserDisplay.Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }
    }
}
