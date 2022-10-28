using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IAdminImageGalleryService : IServiceBase<AdminImageGallery>
    {
        void AddRanger(IEnumerable<AdminImageGallery> adminImageGallery);
        void UpdateAll(IEnumerable<AdminImageGallery> adminImageGallery);
        IEnumerable<AdminImageGallery> GetAllByViewCod(int viewCod, int fileType);
        IEnumerable<AdminImageGallery> GetAllByViewDataId(int viewDataId, int fileType);
        AdminImageGallery GetByFileName(string fileName);
    }
}
