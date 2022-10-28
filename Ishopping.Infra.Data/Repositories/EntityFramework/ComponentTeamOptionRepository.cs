using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentTeamOptionRepository : RepositoryBaseT2<ComponentTeamOption>, IComponentTeamOptionRepository
    {
        public IEnumerable<ComponentTeamOption> GetAllByUserId(string userId)
        {
            return db.ComponentTeamOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentTeamOption GetById(Guid id, string userId)
        {
            return db.ComponentTeamOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentTeamOption GetDefault(string userId)
        {
            return db.ComponentTeamOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentTeamOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentTeamOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentTeamOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentTeamOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentTeamOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentTeamOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentTeamOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentTeamOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
