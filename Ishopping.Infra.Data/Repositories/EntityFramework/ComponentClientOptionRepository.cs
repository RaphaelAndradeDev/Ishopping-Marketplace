using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentClientOptionRepository : RepositoryBaseT2<ComponentClientOption>, IComponentClientOptionRepository
    {
        public IEnumerable<ComponentClientOption> GetAllByUserId(string userId)
        {
            return db.ComponentClientOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentClientOption GetById(Guid id, string userId)
        {
            return db.ComponentClientOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentClientOption GetDefault(string userId)
        {
            return db.ComponentClientOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentClientOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentClientOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentClientOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentClientOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentClientOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentClientOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentClientOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentClientOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
