using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentMenuOptionRepository : RepositoryBaseT2<ComponentMenuOption>, IComponentMenuOptionRepository
    {
        public IEnumerable<ComponentMenuOption> GetAllByUserId(string userId)
        {
            return db.ComponentMenuOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentMenuOption GetById(Guid id, string userId)
        {
            return db.ComponentMenuOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentMenuOption GetDefault(string userId)
        {
            return db.ComponentMenuOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentMenuOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentMenuOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentMenuOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentMenuOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentMenuOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentMenuOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentMenuOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentMenuOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
