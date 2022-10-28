using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentExtraLinkRepository : RepositoryBaseT2<ComponentExtraLink>, IComponentExtraLinkRepository
    {
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentExtraLink.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentExtraLink GetBySiteNumber(int siteNumber)
        {
            return db.ComponentExtraLink.Include("ComponentExtraLinkOption").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentExtraLink> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentExtraLink.Include("ComponentExtraLinkOption").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentExtraLink> GetAllByUserId(string userId)
        {
            return db.ComponentExtraLink.Include("ComponentExtraLinkOption").Where(x => x.IdUser == userId);
        }

        public ComponentExtraLink GetById(Guid id, string userId)
        {
            return db.ComponentExtraLink.Include("ComponentExtraLinkOption").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentExtraLink GetByTerm(string search, string userId)
        {
            return db.ComponentExtraLink.Include("ComponentExtraLinkOption").FirstOrDefault(x => x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentExtraLink.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentExtraLink.Where(x => x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentExtraLink> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentExtraLink.Include("ComponentExtraLinkOption").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentExtraLink>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentExtraLink.Include("ComponentExtraLinkOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentExtraLink>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentExtraLink.Include("ComponentExtraLinkOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentExtraLink> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentExtraLink.Include("ComponentExtraLinkOption").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentExtraLink> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentExtraLink.Include("ComponentExtraLinkOption").FirstOrDefaultAsync(x => x.Search == term && x.IdUser == userId);
        }

    }
}
