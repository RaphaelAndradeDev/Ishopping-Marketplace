using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ContentButtonRepository : RepositoryBaseT2<ContentButton>, IContentButtonRepository
    {
        public IEnumerable<string> Search(string startsWith, int viewCod, string userId)
        {
            return db.ContentButton.Where(x => x.ViewCod == viewCod && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct();
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber)
        {
            return db.ContentButton.Include("ContentButtonOption").Where(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return db.ContentButton.Include("ContentButtonOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition);
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return db.ContentButton.Include("ContentButtonOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public IEnumerable<ContentButton> GetAllByUserId(string userId)
        {
            return db.ContentButton.Include("ContentButtonOption").Where(x => x.IdUser == userId);
        }

        public IEnumerable<ContentButton> GetAllByUserId(string userId, int maxPosition)
        {
            return db.ContentButton.Include("ContentButtonOption").Where(x => x.IdUser == userId && x.Position <= maxPosition);
        }

        public IEnumerable<ContentButton> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return db.ContentButton.Include("ContentButtonOption").Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public ContentButton GetById(Guid id, string userId)
        {
            return db.ContentButton.Include("ContentButtonOption").FirstOrDefault(x => x.IdUser == userId && x.Id == id);
        }

        public ContentButton GetBy(int viewCod, int position, string userId)
        {
            return db.ContentButton.Include("ContentButtonOption").FirstOrDefault(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }

        public ContentButton GetBy(int viewCod, string search, string userId)
        {
            return db.ContentButton.Include("ContentButtonOption").FirstOrDefault(x => x.ViewCod == viewCod && x.Search == search && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ContentButton.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId)
        {
            return await db.ContentButton.Where(x => x.ViewCod == viewCod && x.Search.StartsWith(startsWith) && x.IdUser == userId).Select(x => x.Search).Take(5).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ContentButton.Include("ContentButtonOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await db.ContentButton.Include("ContentButtonOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await db.ContentButton.Include("ContentButtonOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<IEnumerable<ContentButton>> GetAllByUserIdAsync(string userId)
        {
            return await db.ContentButton.Include("ContentButtonOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<IEnumerable<ContentButton>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await db.ContentButton.Include("ContentButtonOption").Where(x => x.IdUser == userId && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentButton>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await db.ContentButton.Include("ContentButtonOption").Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<ContentButton> GetByIdAsync(Guid id, string userId)
        {
            return await db.ContentButton.Include("ContentButtonOption").FirstOrDefaultAsync(x => x.IdUser == userId && x.Id == id);
        }

        public async Task<ContentButton> GetByAsync(int viewCod, int position, string userId)
        {
            return await db.ContentButton.Include("ContentButtonOption").FirstOrDefaultAsync(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }

        public async Task<ContentButton> GetByAsync(int viewCod, string search, string userId)
        {
            return await db.ContentButton.Include("ContentButtonOption").FirstOrDefaultAsync(x => x.ViewCod == viewCod && x.Search == search && x.IdUser == userId);
        }
    }
}
