using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentProjectRepository : RepositoryBaseT2<ComponentProject>, IComponentProjectRepository
    {
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentProject.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentProject GetByImageId(Guid imageId)
        {
            var userImageGallery = db.UserImageGallery.Find(imageId);
            return db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").FirstOrDefault(x => x.UserImageGallery.Any(y => y.Id == userImageGallery.Id));
        }

        public ComponentProject GetBySiteNumber(int siteNumber)
        {
            return db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentProject> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentProject> GetAllByUserId(string userId)
        {
            return db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentProject GetById(Guid id, string userId)
        {
            return db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentProject GetByTerm(string search, string userId)
        {
            return db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").FirstOrDefault(x => x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentProject.RemoveRange(obj);
            db.SaveChanges();
        }

        public void AddBy(ComponentProject componentProject)
        {
            var ids = componentProject.UserImageGallery.Select(x => x.Id);
            var listUserImageGallery = db.UserImageGallery.Where(x => ids.Contains(x.Id)).ToList();
            componentProject.AddListUserImageGallery(listUserImageGallery);
            db.ComponentProject.Add(componentProject);
            db.SaveChanges();
        }

        public void UpdateBy(ComponentProject componentProject)
        {
            var ids = componentProject.UserImageGallery.Select(x => x.Id);
            var listUserImageGallery = db.UserImageGallery.Where(x => ids.Contains(x.Id)).ToList();
            componentProject.AddListUserImageGallery(listUserImageGallery);
            db.Entry(componentProject).State = EntityState.Modified;
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentProject.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentProject> GetByImageIdAsync(Guid imageId)
        {
            var userImageGallery = db.UserImageGallery.Find(imageId);
            return await db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGallery.Any(y => y.Id == userImageGallery.Id));
        }

        public async Task<ComponentProject> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentProject>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentProject>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentProject> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentProject> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentProject.Include("ComponentProjectOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }

    }
}
