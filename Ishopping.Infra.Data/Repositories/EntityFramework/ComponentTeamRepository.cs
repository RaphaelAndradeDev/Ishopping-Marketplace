using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentTeamRepository : RepositoryBaseT2<ComponentTeam>, IComponentTeamRepository
    {

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentTeam.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToList();
        }

        public ComponentTeam GetByImageId(Guid imageId)
        {
            return db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").FirstOrDefault(x => x.UserImageGalleryId == imageId);
        }

        public ComponentTeam GetBySiteNumber(int siteNumber)
        {
            return db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentTeam> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentTeam> GetAllByUserId(string userId)
        {
            return db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").Where(x => x.IdUser == userId);
        }

        public ComponentTeam GetById(Guid id, string userId)
        {
            return db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentTeam GetByTerm(string search, string userId)
        {
            return db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").FirstOrDefault(x => x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentTeam.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentTeam.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentTeam> GetByImageIdAsync(Guid imageId)
        {
            return await db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.UserImageGalleryId == imageId);
        }

        public async Task<ComponentTeam> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentTeam>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentTeam>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentTeam> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentTeam> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentTeam.Include("ComponentTeamOption").Include("UserImageGallery").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }

    }
}
