using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentMenuRepository : RepositoryBaseT2<ComponentMenu>, IComponentMenuRepository
    {
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentMenu.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentMenu GetByImageId(Guid imageId)
        {
            return db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").FirstOrDefault(x => x.UserImageGalleryId == imageId);
        }

        public ComponentMenu GetBySiteNumber(int siteNumber)
        {
            return db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentMenu> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentMenu> GetAllByUserId(string userId)
        {
            return db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentMenu GetById(Guid id, string userId)
        {
            return db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentMenu GetByTerm(string search, string userId)
        {
            return db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").FirstOrDefault(x => x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentMenu.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentMenu.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentMenu> GetByImageIdAsync(Guid imageId)
        {
            return await db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGalleryId == imageId);
        }

        public async Task<ComponentMenu> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentMenu>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentMenu>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentMenu> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentMenu> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentMenu.Include("ComponentMenuOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }
    }
}
