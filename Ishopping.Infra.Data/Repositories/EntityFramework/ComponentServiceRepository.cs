using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentServiceRepository : RepositoryBaseT2<ComponentService>, IComponentServiceRepository
    {
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return db.ComponentService.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentService GetByImageId(Guid imageId)
        {
            return db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").FirstOrDefault(x => x.UserImageGalleryId == imageId);
        }

        public ComponentService GetBySiteNumber(int siteNumber)
        {
            return db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentService> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentService> GetAllByUserId(string userId)
        {
            return db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentService GetById(Guid id, string userId)
        {
            return db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentService GetBy(string search, int position, string userId)
        {
            return db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").FirstOrDefault(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentService.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await db.ComponentService.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentService> GetByImageIdAsync(Guid imageId)
        {
            return await db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGalleryId == imageId);
        }

        public async Task<ComponentService> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentService>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentService>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentService> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentService> GetByAsync(string search, int position, string userId)
        {
            return await db.ComponentService.Include("ComponentServiceOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

    }
}
