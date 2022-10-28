using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class AdminImageGalleryRepository : RepositoryBase<AdminImageGallery>, IAdminImageGalleryRepository
    {
        public IEnumerable<AdminImageGallery> GetAllByViewCod(int viewCod, int fileType)
        {
            return db.AdminImageGallery.Where(x => x.Folder == viewCod && x.FileType == fileType);
        }

        public void AddRanger(IEnumerable<AdminImageGallery> adminImageGallery)
        {
            db.AdminImageGallery.AddRange(adminImageGallery);
            db.SaveChanges();
        }
        
        public IEnumerable<AdminImageGallery> GetAllByViewDataId(int viewDataId, int fileType)
        {
            return db.AdminImageGallery.Where(x => x.AdminViewDataId == viewDataId && x.FileType == fileType);
        }

        public AdminImageGallery GetByFileName(string fileName)
        {
            return db.AdminImageGallery.FirstOrDefault(x => x.FileName == fileName);
        }
        
        public void UpdateAll(IEnumerable<AdminImageGallery> adminImageGallery)
        {
            foreach (var item in adminImageGallery)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}
