using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentSummaryRepository : RepositoryBaseT2<ComponentSummary>, IComponentSummaryRepository
    {
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return db.ComponentSummary.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentSummary GetBySiteNumber(int siteNumber)
        {
            return db.ComponentSummary.Include("ComponentSummaryOption").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentSummary> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentSummary.Include("ComponentSummaryOption").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentSummary> GetAllByUserId(string userId)
        {
            return db.ComponentSummary.Include("ComponentSummaryOption").Where(x => x.IdUser == userId);
        }

        public ComponentSummary GetById(Guid id, string userId)
        {
            return db.ComponentSummary.Include("ComponentSummaryOption").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentSummary GetBy(string search, int position, string userId)
        {
            return db.ComponentSummary.Include("ComponentSummaryOption").FirstOrDefault(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentSummary.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await db.ComponentSummary.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentSummary> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentSummary.Include("ComponentSummaryOption").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentSummary>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentSummary.Include("ComponentSummaryOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentSummary>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentSummary.Include("ComponentSummaryOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentSummary> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentSummary.Include("ComponentSummaryOption").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentSummary> GetByAsync(string search, int position, string userId)
        {
            return await db.ComponentSummary.Include("ComponentSummaryOption").FirstOrDefaultAsync(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

    }
}
