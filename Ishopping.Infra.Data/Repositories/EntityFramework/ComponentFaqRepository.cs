using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentFaqRepository : RepositoryBaseT2<ComponentFaq>, IComponentFaqRepository
    {
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return db.ComponentFaq.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentFaq GetBySiteNumber(int siteNumber)
        {
            return db.ComponentFaq.Include("ComponentFaqOption").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentFaq> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentFaq.Include("ComponentFaqOption").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentFaq> GetAllByUserId(string userId)
        {
            return db.ComponentFaq.Include("ComponentFaqOption").Where(x => x.IdUser == userId);
        }

        public ComponentFaq GetById(Guid id, string userId)
        {
            return db.ComponentFaq.Include("ComponentFaqOption").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentFaq GetBy(string search, int position, string userId)
        {
            return db.ComponentFaq.Include("ComponentFaqOption").FirstOrDefault(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentFaq.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await db.ComponentFaq.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentFaq> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentFaq.Include("ComponentFaqOption").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentFaq>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentFaq.Include("ComponentFaqOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentFaq>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentFaq.Include("ComponentFaqOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentFaq> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentFaq.Include("ComponentFaqOption").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentFaq> GetByAsync(string search, int position, string userId)
        {
            return await db.ComponentFaq.Include("ComponentFaqOption").FirstOrDefaultAsync(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

    }
}
