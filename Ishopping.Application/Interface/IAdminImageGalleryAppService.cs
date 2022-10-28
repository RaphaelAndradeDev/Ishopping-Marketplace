using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ishopping.Domain.Entities;

namespace Ishopping.Application.Interface
{
    public interface IAdminImageGalleryAppService : IAppServiceBase<AdminImageGallery>
    {
        void AddRanger(IEnumerable<AdminImageGallery> adminImageGallery);
        void UpdateAll(IEnumerable<AdminImageGallery> adminImageGallery);
        IEnumerable<AdminImageGallery> GetAllByViewCod(int viewCod, int fileType);
        IEnumerable<AdminImageGallery> GetAllByViewDataId(int viewDataId, int fileType);
        AdminImageGallery GetByFileName(string fileName);
    }
}
