using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentBrandOptionRepository : RepositoryBaseT2<ComponentBrandOption>, IComponentBrandOptionRepository
    {
        public IEnumerable<ComponentBrandOption> GetAllByUserId(string userId)
        {
            return db.ComponentBrandOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentBrandOption GetById(Guid id, string userId)
        {
            return db.ComponentBrandOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentBrandOption GetDefault(string userId)
        {
            return db.ComponentBrandOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentBrandOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentBrandOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentBrandOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentBrandOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentBrandOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentBrandOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentBrandOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentBrandOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }
    }
}
