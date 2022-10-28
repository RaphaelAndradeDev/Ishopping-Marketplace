using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentScopeOptionRepository : RepositoryBaseT2<ComponentScopeOption>, IComponentScopeOptionRepository
    {
        public IEnumerable<ComponentScopeOption> GetAllByUserId(string userId)
        {
            return db.ComponentScopeOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentScopeOption GetById(Guid id, string userId)
        {
            return db.ComponentScopeOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentScopeOption GetDefault(string userId)
        {
            return db.ComponentScopeOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentScopeOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentScopeOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentScopeOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentScopeOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentScopeOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentScopeOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentScopeOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentScopeOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
