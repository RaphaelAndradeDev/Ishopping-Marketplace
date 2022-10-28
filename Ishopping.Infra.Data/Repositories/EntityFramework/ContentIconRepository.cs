using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ContentIconRepository : RepositoryBaseT2<ContentIcon>, IContentIconRepository
    {
        public IEnumerable<string> Search(string startsWith, int viewCod, string userId)
        {
            return db.ContentIcon.Where(x => x.Icon.StartsWith(startsWith) && x.ViewCod == viewCod && x.IdUser == userId).Select(x => x.Icon).Take(5).Distinct();
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber)
        {
            return db.ContentIcon.Where(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return db.ContentIcon.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition);
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return db.ContentIcon.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public IEnumerable<ContentIcon> GetAllByUserId(string userId)
        {
            return db.ContentIcon.Where(x => x.IdUser == userId);
        }

        public IEnumerable<ContentIcon> GetAllByUserId(string userId, int maxPosition)
        {
            return db.ContentIcon.Where(x => x.IdUser == userId && x.Position <= maxPosition);
        }

        public IEnumerable<ContentIcon> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return db.ContentIcon.Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public ContentIcon GetById(Guid id, string userId)
        {
            return db.ContentIcon.FirstOrDefault(x => x.IdUser == userId && x.Id == id);
        }

        public ContentIcon GetBy(int viewCod, int position, string userId)
        {
            return db.ContentIcon.FirstOrDefault(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }

        public ContentIcon GetBy(int viewCod, string term, string userId)
        {
            return db.ContentIcon.FirstOrDefault(x => x.ViewCod == viewCod && x.Icon == term && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ContentIcon.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId)
        {
            return await db.ContentIcon.Where(x => x.Icon.StartsWith(startsWith) && x.ViewCod == viewCod && x.IdUser == userId).Select(x => x.Icon).Take(5).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ContentIcon.Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await db.ContentIcon.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await db.ContentIcon.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<IEnumerable<ContentIcon>> GetAllByUserIdAsync(string userId)
        {
            return await db.ContentIcon.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<IEnumerable<ContentIcon>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await db.ContentIcon.Where(x => x.IdUser == userId && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentIcon>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await db.ContentIcon.Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<ContentIcon> GetByIdAsync(Guid id, string userId)
        {
            return await db.ContentIcon.FirstOrDefaultAsync(x => x.IdUser == userId && x.Id == id);
        }

        public async Task<ContentIcon> GetByAsync(int viewCod, int position, string userId)
        {
            return await db.ContentIcon.FirstOrDefaultAsync(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }

        public async Task<ContentIcon> GetByAsync(int viewCod, string term, string userId)
        {
            return await db.ContentIcon.FirstOrDefaultAsync(x => x.ViewCod == viewCod && x.Icon == term && x.IdUser == userId);
        }
    }
}
