using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentClientRepository : RepositoryBaseT2<ComponentClient>, IComponentClientRepository
    {
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentClient.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentClient GetByImageId(Guid imageId)
        {
            return db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").FirstOrDefault(x => x.UserImageGalleryId == imageId);
        }

        public ComponentClient GetBySiteNumber(int siteNumber)
        {
            return db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentClient> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentClient> GetAllByUserId(string userId)
        {
            return db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentClient GetById(Guid id, string userId)
        {
            return db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentClient GetByTerm(string search, string userId)
        {
            return db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").FirstOrDefault(x => x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentClient.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentClient.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentClient> GetByImageIdAsync(Guid imageId)
        {
            return await db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGalleryId == imageId);
        }

        public async Task<ComponentClient> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentClient>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentClient>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentClient> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentClient> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentClient.Include("ComponentClientOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }

    }
}
