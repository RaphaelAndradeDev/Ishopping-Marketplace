using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentBrandRepository : RepositoryBaseT2<ComponentBrand>, IComponentBrandRepository
    {
        // Sync Methods
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentBrand.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentBrand GetByImageId(Guid imageId)
        {
            return db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").FirstOrDefault(x => x.UserImageGalleryId == imageId);
        }

        public ComponentBrand GetBySiteNumber(int siteNumber)
        {
            return db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentBrand> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentBrand> GetAllByUserId(string userId)
        {
            return db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentBrand GetById(Guid id, string userId)
        {
            return db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentBrand GetByTerm(string search, string userId)
        {
            return db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").FirstOrDefault(x => x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentBrand.RemoveRange(obj);
            db.SaveChanges();
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentBrand.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId)
                .Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentBrand> GetByImageIdAsync(Guid imageId)
        {
            return await db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGalleryId == imageId);
        }

        public async Task<ComponentBrand> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentBrand>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentBrand>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentBrand> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentBrand> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentBrand.Include("ComponentBrandOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }

    }
}
