using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ComponentPortfolioOptionRepository : RepositoryBaseT2<ComponentPortofolioOption>, IComponentPortfolioOptionRepository
    {
        public IEnumerable<ComponentPortofolioOption> GetAllByUserId(string userId)
        {
            return db.ComponentPortofolioOption.Where(x => x.IdUser == userId).ToList();
        }

        public ComponentPortofolioOption GetById(Guid id, string userId)
        {
            return db.ComponentPortofolioOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ComponentPortofolioOption GetDefault(string userId)
        {
            return db.ComponentPortofolioOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }

        // Async Methods
        public async Task<IEnumerable<ComponentPortofolioOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ComponentPortofolioOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ComponentPortofolioOption> GetByIdAsync(Guid id)
        {
            return await db.ComponentPortofolioOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComponentPortofolioOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ComponentPortofolioOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ComponentPortofolioOption> GetDefaultAsync(string userId)
        {
            return await db.ComponentPortofolioOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }

    }
}
