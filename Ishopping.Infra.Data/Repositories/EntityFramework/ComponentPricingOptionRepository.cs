using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentPricingOptionRepository : RepositoryBaseT2<ComponentPricingOption>, IComponentPricingOptionRepository
    {
        public IEnumerable<ComponentPricingOption> GetAllByUserId(string userId)
        {
            return db.ComponentPricingOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentPricingOption GetById(Guid id, string userId)
        {
            return db.ComponentPricingOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentPricingOption GetDefault(string userId)
        {
            return db.ComponentPricingOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentPricingOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentPricingOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentPricingOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentPricingOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentPricingOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentPricingOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentPricingOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentPricingOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
