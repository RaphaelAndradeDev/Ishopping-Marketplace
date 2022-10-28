using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentPostOptionRepository : RepositoryBaseT2<ComponentPostOption>, IComponentPostOptionRepository
    {
        public IEnumerable<ComponentPostOption> GetAllByUserId(string userId)
        {
            return db.ComponentPostOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentPostOption GetById(Guid id, string userId)
        {
            return db.ComponentPostOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentPostOption GetDefault(string userId)
        {
            return db.ComponentPostOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentPostOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentPostOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentPostOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentPostOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentPostOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentPostOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentPostOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentPostOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
