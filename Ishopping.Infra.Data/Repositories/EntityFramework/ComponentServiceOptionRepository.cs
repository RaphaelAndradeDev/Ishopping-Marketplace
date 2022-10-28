using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentServiceOptionRepository : RepositoryBaseT2<ComponentServiceOption>, IComponentServiceOptionRepository
    {
        public IEnumerable<ComponentServiceOption> GetAllByUserId(string userId)
        {
            return db.ComponentServiceOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentServiceOption GetById(Guid id, string userId)
        {
            return db.ComponentServiceOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentServiceOption GetDefault(string userId)
        {
            return db.ComponentServiceOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentServiceOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentServiceOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentServiceOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentServiceOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentServiceOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentServiceOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentServiceOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentServiceOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
