using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentPricingRepository : RepositoryBaseT2<ComponentPricing>, IComponentPricingRepository
    {
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentPricing.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentPricing GetBySiteNumber(int siteNumber)
        {
            return db.ComponentPricing.Include("ComponentPricingOption").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentPricing> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentPricing.Include("ComponentPricingOption").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentPricing> GetAllByUserId(string userId)
        {
            return db.ComponentPricing.Include("ComponentPricingOption").Where(x => x.IdUser == userId);
        }

        public ComponentPricing GetById(Guid id, string userId)
        {
            return db.ComponentPricing.Include("ComponentPricingOption").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentPricing GetByTerm(string search, string userId)
        {
            return db.ComponentPricing.Include("ComponentPricingOption").FirstOrDefault(x => x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentPricing.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentPricing.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentPricing> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentPricing.Include("ComponentPricingOption").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentPricing>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentPricing.Include("ComponentPricingOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentPricing>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentPricing.Include("ComponentPricingOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentPricing> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentPricing.Include("ComponentPricingOption").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentPricing> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentPricing.Include("ComponentPricingOption").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }

    }
}
