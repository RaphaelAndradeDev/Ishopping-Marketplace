using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ContentVideoRepository : RepositoryBaseT2<ContentVideo>, IContentVideoRepository
    {       
        public IEnumerable<ContentVideo> GetAllBySiteNumber(int siteNumber)
        {
            return db.ContentVideo.Where(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ContentVideo> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return db.ContentVideo.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition);
        }

        public IEnumerable<ContentVideo> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return db.ContentVideo.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public IEnumerable<ContentVideo> GetAllByUserId(string userId)
        {
            return db.ContentVideo.Where(x => x.IdUser == userId);
        }

        public IEnumerable<ContentVideo> GetAllByUserId(string userId, int maxPosition)
        {
            return db.ContentVideo.Where(x => x.IdUser == userId && x.Position <= maxPosition);
        }

        public IEnumerable<ContentVideo> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return db.ContentVideo.Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public ContentVideo GetById(Guid id, string userId)
        {
            return db.ContentVideo.FirstOrDefault(x => x.IdUser == userId && x.Id == id);
        }

        public ContentVideo GetBy(int viewCod, int position, string userId)
        {
            return db.ContentVideo.FirstOrDefault(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }        

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ContentVideo.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<ContentVideo>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ContentVideo.Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ContentVideo>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await db.ContentVideo.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentVideo>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await db.ContentVideo.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<IEnumerable<ContentVideo>> GetAllByUserIdAsync(string userId)
        {
            return await db.ContentVideo.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<IEnumerable<ContentVideo>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await db.ContentVideo.Where(x => x.IdUser == userId && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentVideo>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await db.ContentVideo.Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<ContentVideo> GetByIdAsync(Guid id, string userId)
        {
            return await db.ContentVideo.FirstOrDefaultAsync(x => x.IdUser == userId && x.Id == id);
        }

        public async Task<ContentVideo> GetByAsync(int viewCod, int position, string userId)
        {
            return await db.ContentVideo.FirstOrDefaultAsync(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }
    }
}
