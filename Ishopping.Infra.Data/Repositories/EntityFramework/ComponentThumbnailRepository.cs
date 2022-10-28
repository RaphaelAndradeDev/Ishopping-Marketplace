using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentThumbnailRepository : RepositoryBaseT2<ComponentThumbnail>, IComponentThumbnailRepository
    {
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentThumbnail.Where(x => x.UserImageGallery.FileName.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.UserImageGallery.FileName).Take(5).Distinct();
        }

        public ComponentThumbnail GetByImageId(Guid imageId)
        {
            return db.ComponentThumbnail.Include("UserImageGallery").FirstOrDefault(x => x.UserImageGalleryId == imageId);
        }

        public ComponentThumbnail GetBySiteNumber(int siteNumber)
        {
            return db.ComponentThumbnail.Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentThumbnail> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentThumbnail.Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentThumbnail> GetAllByUserId(string userId)
        {
            return db.ComponentThumbnail.Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentThumbnail GetById(Guid id, string userId)
        {
            return db.ComponentThumbnail.Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentThumbnail GetByTerm(string title, string userId)
        {
            return db.ComponentThumbnail.Include("UserImageGallery").FirstOrDefault(x => x.UserImageGallery.FileName == title && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentThumbnail.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentThumbnail.Where(x => x.UserImageGallery.FileName.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.UserImageGallery.FileName).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentThumbnail> GetByImageIdAsync(Guid imageId)
        {
            return await db.ComponentThumbnail.Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGalleryId == imageId);
        }

        public async Task<ComponentThumbnail> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentThumbnail.Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentThumbnail>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentThumbnail.Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentThumbnail>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentThumbnail.Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentThumbnail> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentThumbnail.Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentThumbnail> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentThumbnail.Include("UserImageGallery").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }

    }
}
