using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentFaqOptionRepository : RepositoryBaseT2<ComponentFaqOption>, IComponentFaqOptionRepository
    {
        public IEnumerable<ComponentFaqOption> GetAllByUserId(string userId)
        {
            return db.ComponentFaqOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentFaqOption GetById(Guid id, string userId)
        {
            return db.ComponentFaqOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentFaqOption GetDefault(string userId)
        {
            return db.ComponentFaqOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentFaqOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentFaqOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentFaqOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentFaqOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentFaqOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentFaqOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentFaqOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentFaqOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
