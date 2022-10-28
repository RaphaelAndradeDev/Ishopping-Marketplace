using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentFeaturesRepository : RepositoryBaseT2<ComponentFeatures>, IComponentFeaturesRepository
    {
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentFeatures.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentFeatures GetBySiteNumber(int siteNumber)
        {
            return db.ComponentFeatures.Include("ComponentFeaturesOption").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentFeatures> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentFeatures.Include("ComponentFeaturesOption").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentFeatures> GetAllByUserId(string userId)
        {
            return db.ComponentFeatures.Include("ComponentFeaturesOption").Where(x => x.IdUser == userId);
        }

        public ComponentFeatures GetById(Guid id, string userId)
        {
            return db.ComponentFeatures.Include("ComponentFeaturesOption").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentFeatures GetByTerm(string search, string userId)
        {
            return db.ComponentFeatures.Include("ComponentFeaturesOption").FirstOrDefault(x => x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentFeatures.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentFeatures.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentFeatures> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentFeatures.Include("ComponentFeaturesOption").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentFeatures>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentFeatures.Include("ComponentFeaturesOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentFeatures>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentFeatures.Include("ComponentFeaturesOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentFeatures> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentFeatures.Include("ComponentFeaturesOption").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentFeatures> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentFeatures.Include("ComponentFeaturesOption").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }

    }
}
