using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentPanelRepository : RepositoryBaseT2<ComponentPanel>, IComponentPanelRepository
    {
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return db.ComponentPanel.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public ComponentPanel GetBySiteNumber(int siteNumber)
        {
            return db.ComponentPanel.Include("ComponentPanelOption").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentPanel> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentPanel.Include("ComponentPanelOption").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentPanel> GetAllByUserId(string userId)
        {
            return db.ComponentPanel.Include("ComponentPanelOption").Where(x => x.IdUser == userId);
        }

        public ComponentPanel GetById(Guid id, string userId)
        {
            return db.ComponentPanel.Include("ComponentPanelOption").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentPanel GetBy(string search, int position, string userId)
        {
            return db.ComponentPanel.Include("ComponentPanelOption").FirstOrDefault(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentPanel.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await db.ComponentPanel.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentPanel> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentPanel.Include("ComponentPanelOption").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentPanel>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentPanel.Include("ComponentPanelOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentPanel>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentPanel.Include("ComponentPanelOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentPanel> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentPanel.Include("ComponentPanelOption").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentPanel> GetByAsync(string search, int position, string userId)
        {
            return await db.ComponentPanel.Include("ComponentPanelOption").FirstOrDefaultAsync(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

    }
}
