using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IAdminImageGalleryRepository : IRepositoryBase<AdminImageGallery>
    {
        void AddRanger(IEnumerable<AdminImageGallery> adminImageGallery);
        void UpdateAll(IEnumerable<AdminImageGallery> adminImageGallery);
        IEnumerable<AdminImageGallery> GetAllByViewCod(int viewCod, int fileType);
        IEnumerable<AdminImageGallery> GetAllByViewDataId(int viewDataId, int fileType);
        AdminImageGallery GetByFileName(string fileName);
    }
}
