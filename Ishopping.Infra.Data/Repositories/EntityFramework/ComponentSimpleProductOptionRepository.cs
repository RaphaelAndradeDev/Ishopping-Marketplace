using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentSimpleProductOptionRepository : RepositoryBaseT2<ComponentSimpleProductOption>, IComponentSimpleProductOptionRepository
    {
        public IEnumerable<ComponentSimpleProductOption> GetAllByUserId(string userId)
        {
            return db.ComponentSimpleProductOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentSimpleProductOption GetById(Guid id, string userId)
        {
            return db.ComponentSimpleProductOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentSimpleProductOption GetDefault(string userId)
        {
            return db.ComponentSimpleProductOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentSimpleProductOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentSimpleProductOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentSimpleProductOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentSimpleProductOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentSimpleProductOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentSimpleProductOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentSimpleProductOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentSimpleProductOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
