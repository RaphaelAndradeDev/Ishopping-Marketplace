using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentExtraLinkOptionRepository : RepositoryBaseT2<ComponentExtraLinkOption>, IComponentExtraLinkOptionRepository
    {
        public IEnumerable<ComponentExtraLinkOption> GetAllByUserId(string userId)
        {
            return db.ComponentExtraLinkOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentExtraLinkOption GetById(Guid id, string userId)
        {
            return db.ComponentExtraLinkOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentExtraLinkOption GetDefault(string userId)
        {
            return db.ComponentExtraLinkOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentExtraLinkOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentExtraLinkOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentExtraLinkOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentExtraLinkOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentExtraLinkOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentExtraLinkOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentExtraLinkOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentExtraLinkOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
