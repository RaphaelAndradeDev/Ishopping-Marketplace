using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentSocialNetworkRepository : RepositoryBaseT2<ComponentSocialNetwork>, IComponentSocialNetworkRepository
    {
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return db.ComponentSocialNetwork.Where(x => x.Rede.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Rede).Take(5).Distinct();
        }

        public ComponentSocialNetwork GetBySiteNumber(int siteNumber)
        {
            return db.ComponentSocialNetwork.FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ComponentSocialNetwork> GetAllBySiteNumber(int siteNumber)
        {
            return db.ComponentSocialNetwork.Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public IEnumerable<ComponentSocialNetwork> GetAllByUserId(string userId)
        {
            return db.ComponentSocialNetwork.Where(x => x.IdUser == userId);
        }

        public ComponentSocialNetwork GetById(Guid id, string userId)
        {
            return db.ComponentSocialNetwork.FirstOrDefault(b => b.IdUser == userId && b.Id == id);
        }

        public ComponentSocialNetwork GetByTerm(string term, string userId)
        {
            return db.ComponentSocialNetwork.FirstOrDefault(x => x.Rede == term && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ComponentSocialNetwork.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await db.ComponentSocialNetwork.Where(x => x.Rede.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Rede).Take(5).Distinct().ToListAsync();
        }
        
        public async Task<ComponentSocialNetwork> GetBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentSocialNetwork.FirstOrDefaultAsync(x => x.SiteNumber == siteNumber);
        }

        public async Task<IEnumerable<ComponentSocialNetwork>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ComponentSocialNetwork.Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ComponentSocialNetwork>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentSocialNetwork.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentSocialNetwork> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentSocialNetwork.FirstOrDefaultAsync(b => b.IdUser == userId && b.Id == id);
        }

        public async Task<ComponentSocialNetwork> GetByTermAsync(string term, string userId)
        {
            return await db.ComponentSocialNetwork.FirstOrDefaultAsync(x => x.Rede == term && x.IdUser == userId);
        }

    }
}
