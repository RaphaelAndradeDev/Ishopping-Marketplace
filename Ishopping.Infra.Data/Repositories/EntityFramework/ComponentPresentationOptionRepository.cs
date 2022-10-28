using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentPresentationOptionRepository : RepositoryBaseT2<ComponentPresentationOption>, IComponentPresentationOptionRepository
    {
        public IEnumerable<ComponentPresentationOption> GetAllByUserId(string userId)
        {
            return db.ComponentPresentationOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentPresentationOption GetById(Guid id, string userId)
        {
            return db.ComponentPresentationOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentPresentationOption GetDefault(string userId)
        {
            return db.ComponentPresentationOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentPresentationOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentPresentationOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentPresentationOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentPresentationOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentPresentationOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentPresentationOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentPresentationOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentPresentationOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
