using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Data.Entity;

namespace Ishopping.Infra.Data.Repositories
{
    public class ContentTextRepository : RepositoryBaseT2<ContentText>, IContentTextRepository
    {
        public IEnumerable<ContentText> Search(string startsWith, int viewCod, string userId)
        {
            return db.ContentText.Where(x => x.ViewCod == viewCod && (x.Search32.StartsWith(startsWith) || x.Search512.StartsWith(startsWith) || x.Search5120.StartsWith(startsWith)) && x.IdUser == userId).Take(5).Distinct();
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber)
        {
            return db.ContentText.Include("ContentTextOption").Where(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return db.ContentText.Include("ContentTextOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition);
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return db.ContentText.Include("ContentTextOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public IEnumerable<ContentText> GetAllByUserId(string userId)
        {
            return db.ContentText.Include("ContentTextOption").Where(x => x.IdUser == userId);
        }

        public IEnumerable<ContentText> GetAllByUserId(string userId, int maxPosition)
        {
            return db.ContentText.Include("ContentTextOption").Where(x => x.IdUser == userId && x.Position <= maxPosition);
        }

        public IEnumerable<ContentText> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return db.ContentText.Include("ContentTextOption").Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public ContentText GetById(Guid id, string userId)
        {
            return db.ContentText.Include("ContentTextOption").FirstOrDefault(x => x.IdUser == userId && x.Id == id);
        }

        public ContentText GetBy(int viewCod, int position, string userId)
        {
            return db.ContentText.Include("ContentTextOption").FirstOrDefault(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }

        public ContentText GetBy(int viewCod, string search, string userId)
        {
            return db.ContentText.Include("ContentTextOption").FirstOrDefault(x => x.ViewCod == viewCod && (x.Search32 == search || x.Search512 == search || x.Search5120 == search) && x.IdUser == userId);
        }

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ContentText.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<ContentText>> SearchAsync(string startsWith, int viewCod, string userId)
        {
            return await db.ContentText.Where(x => x.ViewCod == viewCod && (x.Search32.StartsWith(startsWith) || x.Search512.StartsWith(startsWith) || x.Search5120.StartsWith(startsWith)) && x.IdUser == userId).Take(5).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ContentText.Include("ContentTextOption").Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await db.ContentText.Include("ContentTextOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await db.ContentText.Include("ContentTextOption").Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<IEnumerable<ContentText>> GetAllByUserIdAsync(string userId)
        {
            return await db.ContentText.Include("ContentTextOption").Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<IEnumerable<ContentText>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await db.ContentText.Include("ContentTextOption").Where(x => x.IdUser == userId && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentText>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await db.ContentText.Include("ContentTextOption").Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<ContentText> GetByIdAsync(Guid id, string userId)
        {
            return await db.ContentText.Include("ContentTextOption").FirstOrDefaultAsync(x => x.IdUser == userId && x.Id == id);
        }

        public async Task<ContentText> GetByAsync(int viewCod, int position, string userId)
        {
            return await db.ContentText.Include("ContentTextOption").FirstOrDefaultAsync(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }

        public async Task<ContentText> GetByAsync(int viewCod, string search, string userId)
        {
            return await db.ContentText.Include("ContentTextOption").FirstOrDefaultAsync(x => x.ViewCod == viewCod && (x.Search32 == search || x.Search512 == search || x.Search5120 == search) && x.IdUser == userId);
        }
    }
}
