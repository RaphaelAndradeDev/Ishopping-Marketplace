using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentSkillOptionRepository : RepositoryBaseT2<ComponentSkillOption>, IComponentSkillOptionRepository
    {
        public IEnumerable<ComponentSkillOption> GetAllByUserId(string userId)
        {
            return db.ComponentSkillOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentSkillOption GetById(Guid id, string userId)
        {
            return db.ComponentSkillOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentSkillOption GetDefault(string userId)
        {
            return db.ComponentSkillOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentSkillOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentSkillOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentSkillOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentSkillOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentSkillOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentSkillOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentSkillOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentSkillOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
