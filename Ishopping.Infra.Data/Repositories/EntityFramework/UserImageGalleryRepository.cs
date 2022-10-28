using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class UserImageGalleryRepository : RepositoryBaseT2<UserImageGallery>, IUserImageGalleryRepository
    {
        // Sync Methods
        public int CountImg(int fileType, string userId)
        {
            return db.UserImageGallery.Count(x => x.FileType == fileType && x.IdUser == userId);
        }
        
        public UserImageGallery GetBy(int fileType, Guid id, string userId)
        {
            return db.UserImageGallery.FirstOrDefault(x => x.FileType == fileType && x.Id == id && x.IdUser == userId);
        }

        public UserImageGallery GetBy(int fileType, string fileName, string userId)
        {
            return db.UserImageGallery.FirstOrDefault(x => x.FileType == fileType && x.FileName == fileName && x.IdUser == userId);
        }

        public UserImageGallery GetById(string id, string userId)
        {
            return db.UserImageGallery.FirstOrDefault(x => x.Id.ToString() == id && x.IdUser == userId);
        }

        public UserImageGallery GetByFileName(string fileName)
        {
            return db.UserImageGallery.FirstOrDefault(x => x.FileName == fileName);
        }  

        public IEnumerable<UserImageGallery> GetAllBySiteNumber(int siteNumber, int fileType)
        {
            return db.UserImageGallery.Where(x => x.SiteNumber == siteNumber && x.FileType == fileType);
        }

        public IEnumerable<UserImageGallery> GetAllBy(int fileType, int viewCod, string userId)
        {
            return db.UserImageGallery.Where(b => b.IdUser == userId && b.FileType == fileType && b.ViewCod == viewCod);
        }

        public IEnumerable<UserImageGallery> GetAllBy(int fileType, string userId)
        {
            return db.UserImageGallery.Where(b => b.IdUser == userId && b.FileType == fileType);
        }      

        public IEnumerable<UserImageGallery> GetAllisContain(List<string> listFileName, int fileType, string userId)
        {
            return db.UserImageGallery.Where(x => listFileName.Contains(x.FileName) && x.FileType == fileType && x.IdUser == userId);
        }      
                    
        public IEnumerable<UserImageGallery> GetAllisContain(IEnumerable<int> fileType, string userId)
        {
            return db.UserImageGallery.Where(x => fileType.Contains(x.FileType) && x.IdUser == userId).ToList();
        }

        public void AddRanger(IEnumerable<UserImageGallery> userImageGallery)
        {
            db.UserImageGallery.AddRange(userImageGallery);
            db.SaveChanges();
        }

        public void UpdateAll(IEnumerable<UserImageGallery> userImageGallery)
        {
            foreach (var item in userImageGallery)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        public void RemoveRanger(IEnumerable<UserImageGallery> userImageGallery)
        {
            db.UserImageGallery.RemoveRange(userImageGallery);
            db.SaveChanges();
        }

        // Async Methods
        public async Task<UserImageGallery> GetByAsync(int fileType, Guid id, string userId)
        {
            return await db.UserImageGallery.FirstOrDefaultAsync(x => x.FileType == fileType && x.Id == id && x.IdUser == userId);
        }

        public async Task<UserImageGallery> GetByAsync(int fileType, string fileName, string userId)
        {
            return await db.UserImageGallery.FirstOrDefaultAsync(x => x.FileType == fileType && x.FileName == fileName && x.IdUser == userId);
        }

        public async Task<UserImageGallery> GetByIdAsync(string id, string userId)
        {
            return await db.UserImageGallery.FirstOrDefaultAsync(x => x.Id.ToString() == id && x.IdUser == userId);
        }

        public async Task<UserImageGallery> GetByFileNameAsync(string fileName)
        {
            return await db.UserImageGallery.FirstOrDefaultAsync(x => x.FileName == fileName);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllBySiteNumberAsync(int siteNumber, int fileType)
        {
            return await db.UserImageGallery.Where(x => x.SiteNumber == siteNumber && x.FileType == fileType).ToListAsync();
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllByAsync(int fileType, int viewCod, string userId)
        {
            return await db.UserImageGallery.Where(b => b.IdUser == userId && b.FileType == fileType && b.ViewCod == viewCod).ToListAsync();
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllByAsync(int fileType, string userId)
        {
            return await db.UserImageGallery.Where(b => b.IdUser == userId && b.FileType == fileType).ToListAsync();
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllisContainAsync(List<string> listFileName, int fileType, string userId)
        {
            return await db.UserImageGallery.Where(x => listFileName.Contains(x.FileName) && x.FileType == fileType && x.IdUser == userId).ToListAsync();
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllisContainAsync(IEnumerable<int> fileType, string userId)
        {
            return await db.UserImageGallery.Where(x => fileType.Contains(x.FileType) && x.IdUser == userId).ToListAsync();
        }

        // Methods for admin
        public async Task<IEnumerable<UserImageGallery>> GetAllToVerifyAsync()
        {
            return await db.UserImageGallery.Where(x => x.Checked == false).Take(12).ToListAsync();
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllToVerifyAsync(int fileType)
        {
            return await db.UserImageGallery.Where(x => x.FileType == fileType && x.Checked == false).Take(12).ToListAsync();
        }
    }
}
