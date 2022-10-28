using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ContentButtonOptionRepository : RepositoryBaseT2<ContentButtonOption>, IContentButtonOptionRepository
    {
        public IEnumerable<ContentButtonOption> GetAllByUserId(string userId)
        {
            return db.ContentButtonOption.Where(x => x.IdUser == userId).ToList();
        }

        public ContentButtonOption GetById(Guid id, string userId)
        {
            return db.ContentButtonOption.FirstOrDefault(x => x.Id == id && x.IdUser == userId);
        }

        public ContentButtonOption GetDefault(string userId)
        {
            return db.ContentButtonOption.FirstOrDefault(x => x.Default == true && x.IdUser == userId);
        }


        // Async Methods
        public async Task<IEnumerable<ContentButtonOption>> GetAllByUserIdAsync(string userId)
        {
            return await db.ContentButtonOption.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ContentButtonOption> GetByIdAsync(Guid id)
        {
            return await db.ContentButtonOption.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContentButtonOption> GetByIdAsync(Guid id, string userId)
        {
            return await db.ContentButtonOption.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async  Task<ContentButtonOption> GetDefaultAsync(string userId)
        {
            return await db.ContentButtonOption.FirstOrDefaultAsync(x => x.Default == true && x.IdUser == userId);
        }
    }
}
