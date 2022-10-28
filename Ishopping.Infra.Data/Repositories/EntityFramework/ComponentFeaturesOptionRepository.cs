using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentFeaturesOptionRepository : RepositoryBaseT2<ComponentFeaturesOption>, IComponentFeaturesOptionRepository
    {
        public IEnumerable<ComponentFeaturesOption> GetAllByUserId(string userId)
        {
            return db.ComponentFeaturesOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentFeaturesOption GetById(Guid id, string userId)
        {
            return db.ComponentFeaturesOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentFeaturesOption GetDefault(string userId)
        {
            return db.ComponentFeaturesOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentFeaturesOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentFeaturesOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentFeaturesOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentFeaturesOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentFeaturesOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentFeaturesOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentFeaturesOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentFeaturesOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
