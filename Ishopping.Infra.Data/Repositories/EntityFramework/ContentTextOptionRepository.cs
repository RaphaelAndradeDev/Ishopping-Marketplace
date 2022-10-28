using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ContentTextOptionRepository : RepositoryBaseT2<ContentTextOption>, IContentTextOptionRepository
    {
        public IEnumerable<ContentTextOption> GetAllByUserId(string userId)
        {
            return db.ContentTextOption.Where(x => x.IdUser == userId).ToList();
        }

        public ContentTextOption GetById(Guid id, string userId)
        {
            return db.ContentTextOption.FirstOrDefault(x => x.IdUser == userId);
        }

        public ContentTextOption GetDefault(string userId)
        {
            return db.ContentTextOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }


        // Async Methods
        public async Task<IEnumerable<ContentTextOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ContentTextOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ContentTextOption> GetByIdAsync(Guid id)
        {
            return await db.ContentTextOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContentTextOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ContentTextOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<ContentTextOption> GetDefaultAsync(string userId)
        {
            return await db.ContentTextOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }
    }
}
