using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentActivityOptionRepository : RepositoryBaseT2<ComponentActivityOption>, IComponentActivityOptionRepository
    {        
        public IEnumerable<ComponentActivityOption> GetAllByUserId(string userId)
        {
            return db.ComponentActivityOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentActivityOption GetById(Guid id, string userId)
        {
            return db.ComponentActivityOption.FirstOrDefault(x => x.Id == id && x.IdUser == userId);
        }
        
        public ComponentActivityOption GetDefault(string userId)
        {
            return db.ComponentActivityOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        public void UpdateAll(IEnumerable<ComponentActivityOption> componentActivityOption)
        {
            foreach (var item in componentActivityOption)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            db.SaveChanges();
            db.Dispose();
        }


        // Async Methods
        public async Task<IEnumerable<ComponentActivityOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentActivityOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentActivityOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentActivityOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentActivityOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentActivityOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentActivityOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentActivityOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }
      
    }
}
