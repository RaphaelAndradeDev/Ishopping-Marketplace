using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentPanelOptionRepository : RepositoryBaseT2<ComponentPanelOption>, IComponentPanelOptionRepository
    {
        public IEnumerable<ComponentPanelOption> GetAllByUserId(string userId)
        {
            return db.ComponentPanelOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentPanelOption GetById(Guid id, string userId)
        {
            return db.ComponentPanelOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentPanelOption GetDefault(string userId)
        {
            return db.ComponentPanelOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentPanelOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentPanelOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentPanelOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentPanelOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentPanelOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentPanelOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentPanelOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentPanelOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
