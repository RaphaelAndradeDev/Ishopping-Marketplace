using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class ContentSliderRepository : RepositoryBaseT2<ContentSlider>, IContentSliderRepository
    {
        public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber)
        {
            return db.ContentSlider.Where(x => x.SiteNumber == siteNumber);
        }

        public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return db.ContentSlider.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition);
        }

        public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return db.ContentSlider.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public IEnumerable<ContentSlider> GetAllByUserId(string userId)
        {
            return db.ContentSlider.Where(x => x.IdUser == userId);
        }

        public IEnumerable<ContentSlider> GetAllByUserId(string userId, int maxPosition)
        {
            return db.ContentSlider.Where(x => x.IdUser == userId && x.Position <= maxPosition);
        }

        public IEnumerable<ContentSlider> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return db.ContentSlider.Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod);
        }

        public ContentSlider GetById(Guid id, string userId)
        {
            return db.ContentSlider.FirstOrDefault(x => x.IdUser == userId && x.Id == id);
        }

        public ContentSlider GetBy(int viewCod, int position, string userId)
        {
            return db.ContentSlider.FirstOrDefault(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }      

        public List<ContentSlider> GetAllByViewCod(int viewCod, int sliderPosition, string userId)
        {
            return db.ContentSlider.Where(x => x.ViewCod == viewCod && x.Position == sliderPosition && x.IdUser == userId).ToList();
        }

        public ContentSlider GetByImageId(Guid imageId)
        {
            string imageFileName = db.UserImageGallery.FirstOrDefault(x => x.Id == imageId).FileName;
            if (!string.IsNullOrEmpty(imageFileName))
                return db.ContentSlider.FirstOrDefault(x => x.ImageFileName == imageFileName);
            else
                return null;
        }

        public void AddRanger(IEnumerable<ContentSlider> contentSlider)
        {
            db.ContentSlider.AddRange(contentSlider);
            db.SaveChanges();
        }       
    
        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ContentSlider.RemoveRange(obj);
            db.SaveChanges();
        }


        // Async Methods
        public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await db.ContentSlider.Where(x => x.SiteNumber == siteNumber).ToListAsync();
        }

        public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await db.ContentSlider.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await db.ContentSlider.Where(x => x.SiteNumber == siteNumber && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<IEnumerable<ContentSlider>> GetAllByUserIdAsync(string userId)
        {
            return await db.ContentSlider.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<IEnumerable<ContentSlider>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await db.ContentSlider.Where(x => x.IdUser == userId && x.Position <= maxPosition).ToListAsync();
        }

        public async Task<IEnumerable<ContentSlider>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await db.ContentSlider.Where(x => x.IdUser == userId && x.Position <= maxPosition && x.ViewCod == viewCod).ToListAsync();
        }

        public async Task<ContentSlider> GetByIdAsync(Guid id, string userId)
        {
            return await db.ContentSlider.FirstOrDefaultAsync(x => x.IdUser == userId && x.Id == id);
        }

        public async Task<ContentSlider> GetByAsync(int viewCod, int position, string userId)
        {
            return await db.ContentSlider.FirstOrDefaultAsync(x => x.ViewCod == viewCod && x.Position == position && x.IdUser == userId);
        }

        public async Task<List<ContentSlider>> GetAllByViewCodAsync(int viewCod, int sliderPosition, string userId)
        {
            return await db.ContentSlider.Where(x => x.ViewCod == viewCod && x.Position == sliderPosition && x.IdUser == userId).ToListAsync();
        }

        public async Task<ContentSlider> GetByImageIdAsync(Guid imageId)
        {
            var img = await db.UserImageGallery.FirstOrDefaultAsync(x => x.Id == imageId);
            if (!string.IsNullOrEmpty(img.FileName))
                return await db.ContentSlider.FirstOrDefaultAsync(x => x.ImageFileName == img.FileName);
            else
                return null;
        }
    }
}
