using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentProjectOptionRepository : RepositoryBaseT2<ComponentProjectOption>, IComponentProjectOptionRepository
    {
        public IEnumerable<ComponentProjectOption> GetAllByUserId(string userId)
        {
            return db.ComponentProjectOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentProjectOption GetById(Guid id, string userId)
        {
            return db.ComponentProjectOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentProjectOption GetDefault(string userId)
        {
            return db.ComponentProjectOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentProjectOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentProjectOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentProjectOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentProjectOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentProjectOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentProjectOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentProjectOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentProjectOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
