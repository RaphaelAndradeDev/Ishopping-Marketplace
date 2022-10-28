using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentActivityRepository : RepositoryBaseT2<ComponentActivity>, IComponentActivityRepository
    {   
        // Sync Methods
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return db.ComponentActivity.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId)
                .Select(x => x.Search).Take(5).Distinct().ToList();
        }             

        public ComponentActivity GetBySiteNumber(int siteNumber)
        {
            return db.ComponentActivity.Include("ComponentActivityOption").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }
    
        public IEnumerable<ComponentActivity> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentActivity.Include("ComponentActivityOption").Where(x => x.SiteNumber == siteNumber).ToList();
        }           

        public IEnumerable<ComponentActivity> GetAllByUserId(string userId)
        {
            return db.ComponentActivity.Include("ComponentActivityOption").Where(x => x.IdUser == userId);
        }          

        public ComponentActivity GetById(Guid id, string userId)
        {
            return db.ComponentActivity.Include("ComponentActivityOption").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }
        
        public ComponentActivity GetBy(string search, int position, string userId)
        {
            return db.ComponentActivity.Include("ComponentActivityOption").FirstOrDefault(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }         

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentActivity.RemoveRange(obj);
            db.SaveChanges();
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await db.ComponentActivity.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId)
                .Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentActivity> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentActivity.Include("ComponentActivityOption").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentActivity>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentActivity.Include("ComponentActivityOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentActivity>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentActivity.Include("ComponentActivityOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentActivity> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentActivity.Include("ComponentActivityOption").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentActivity> GetByAsync(string search, int position, string userId)
        {
            return await db.ComponentActivity.Include("ComponentActivityOption").FirstOrDefaultAsync(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }
    }
}
