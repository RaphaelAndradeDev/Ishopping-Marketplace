using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentPresentationRepository : RepositoryBaseT2<ComponentPresentation>, IComponentPresentationRepository
    {
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return db.ComponentPresentation.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentPresentation GetByImageId(Guid imageId)
        {
            return db.ComponentPresentation.FirstOrDefault(x => x.UserImageGalleryId == imageId);
        }

        public ComponentPresentation GetBySiteNumber(int siteNumber)
        {
            return db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentPresentation> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentPresentation> GetAllByUserId(string userId)
        {
            return db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentPresentation GetById(Guid id, string userId)
        {
            return db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentPresentation GetBy(string search, int position, string userId)
        {
            return db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").FirstOrDefault(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentPresentation.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await db.ComponentPresentation.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentPresentation> GetByImageIdAsync(Guid imageId)
        {
            return await db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGalleryId == imageId);
        }

        public async Task<ComponentPresentation> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentPresentation>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentPresentation>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentPresentation> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentPresentation> GetByAsync(string search, int position, string userId)
        {
            return await db.ComponentPresentation.Include("ComponentPresentationOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }
           
    }
}
