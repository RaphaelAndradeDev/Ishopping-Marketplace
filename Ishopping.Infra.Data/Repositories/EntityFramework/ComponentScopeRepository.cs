using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentScopeRepository : RepositoryBaseT2<ComponentScope>, IComponentScopeRepository
    {
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return db.ComponentScope.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentScope GetBySiteNumber(int siteNumber)
        {
            return db.ComponentScope.Include("ComponentScopeOption").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentScope> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentScope.Include("ComponentScopeOption").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentScope> GetAllByUserId(string userId)
        {
            return db.ComponentScope.Include("ComponentScopeOption").Where(x => x.IdUser == userId);
        }

        public ComponentScope GetById(Guid id, string userId)
        {
            return db.ComponentScope.Include("ComponentScopeOption").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentScope GetBy(string search, int position, string userId)
        {
            return db.ComponentScope.Include("ComponentScopeOption").FirstOrDefault(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentScope.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await db.ComponentScope.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentScope> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentScope.Include("ComponentScopeOption").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentScope>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentScope.Include("ComponentScopeOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentScope>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentScope.Include("ComponentScopeOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentScope> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentScope.Include("ComponentScopeOption").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentScope> GetByAsync(string search, int position, string userId)
        {
            return await db.ComponentScope.Include("ComponentScopeOption").FirstOrDefaultAsync(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

    }
}
