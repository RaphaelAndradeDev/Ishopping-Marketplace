using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentSkillRepository : RepositoryBaseT2<ComponentSkill>, IComponentSkillRepository
    {
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return db.ComponentSkill.Where(x => x.Position == position && x.Category.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Category).Take(5).Distinct();
        }

        public ComponentSkill GetBySiteNumber(int siteNumber)
        {
            return db.ComponentSkill.Include("ComponentSkillOption").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentSkill> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentSkill.Include("ComponentSkillOption").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentSkill> GetAllByUserId(string userId)
        {
            return db.ComponentSkill.Include("ComponentSkillOption").Where(x => x.IdUser == userId);
        }

        public ComponentSkill GetById(Guid id, string userId)
        {
            return db.ComponentSkill.Include("ComponentSkillOption").FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentSkill GetBy(string title, int position, string userId)
        {
            return db.ComponentSkill.Include("ComponentSkillOption").FirstOrDefault(x => x.Position == position && x.Category == title && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentSkill.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await db.ComponentSkill.Where(x => x.Position == position && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<ComponentSkill> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentSkill.Include("ComponentSkillOption").FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentSkill>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentSkill.Include("ComponentSkillOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentSkill>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentSkill.Include("ComponentSkillOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentSkill> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentSkill.Include("ComponentSkillOption").FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentSkill> GetByAsync(string search, int position, string userId)
        {
            return await db.ComponentSkill.Include("ComponentSkillOption").FirstOrDefaultAsync(x => x.Position == position && x.Search == search && x.IdUser == userId);
        }

    }
}
