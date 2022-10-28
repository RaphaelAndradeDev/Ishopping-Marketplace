using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ContentListRepository : RepositoryBaseT2<ContentList>, IContentListRepository
    {        
        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber)
        {
            return db.ContentList.Include("ContentListOption").Where(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return db.ContentList.Include("ContentListOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition);
        }

        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return db.ContentList.Include("ContentListOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public IEnumerable<ContentList> GetAllByUserId(string userId)
        {
            return db.ContentList.Include("ContentListOption").Where(x => x.IdUser == userId);
        }

        public IEnumerable<ContentList> GetAllByUserId(string userId, int maxPosition)
        {
            return db.ContentList.Include("ContentListOption").Where(x => x.IdUser == userId && x.Position <= maxPosition);
        }

        public IEnumerable<ContentList> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return db.ContentList.Include("ContentListOption").Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public ContentList GetById(Guid id, string userId)
        {
            return db.ContentList.Include("ContentListOption").FirstOrDefault(x => x.IdUser == userId && x.Id == id);
        }

        public ContentList GetBy(int viewCod, int position, string userId)
        {
            return db.ContentList.Include("ContentListOption").FirstOrDefault(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }               

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ContentList.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ContentList.Include("ContentListOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await db.ContentList.Include("ContentListOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await db.ContentList.Include("ContentListOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<IEnumerable<ContentList>> GetAllByUserIdAsync(string userId)
        {
            return await db.ContentList.Include("ContentListOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<IEnumerable<ContentList>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await db.ContentList.Include("ContentListOption").Where(x => x.IdUser == userId && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentList>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await db.ContentList.Include("ContentListOption").Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<ContentList> GetByIdAsync(Guid id, string userId)
        {
            return await db.ContentList.Include("ContentListOption").FirstOrDefaultAsync(x => x.IdUser == userId && x.Id == id);
        }

        public async Task<ContentList> GetByAsync(int viewCod, int position, string userId)
        {
            return await db.ContentList.Include("ContentListOption").FirstOrDefaultAsync(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }
    }
}
