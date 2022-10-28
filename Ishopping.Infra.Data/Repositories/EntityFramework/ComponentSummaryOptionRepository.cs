using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentSummaryOptionRepository : RepositoryBaseT2<ComponentSummaryOption>, IComponentSummaryOptionRepository
    {
        public IEnumerable<ComponentSummaryOption> GetAllByUserId(string userId)
        {
            return db.ComponentSummaryOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentSummaryOption GetById(Guid id, string userId)
        {
            return db.ComponentSummaryOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentSummaryOption GetDefault(string userId)
        {
            return db.ComponentSummaryOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentSummaryOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentSummaryOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentSummaryOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentSummaryOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentSummaryOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentSummaryOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentSummaryOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentSummaryOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
