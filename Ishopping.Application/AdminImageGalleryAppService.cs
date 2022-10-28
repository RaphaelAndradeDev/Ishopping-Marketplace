using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Application
{
    public class AdminImageGalleryAppService : AppServiceBase<AdminImageGallery>, IAdminImageGalleryAppService
    {
        private readonly IAdminImageGalleryService _adminImageGalleryService;

        public AdminImageGalleryAppService(IAdminImageGalleryService adminImageGalleryService)
            :base(adminImageGalleryService)
        {
            _adminImageGalleryService = adminImageGalleryService;
        }

        public IEnumerable<AdminImageGallery> GetAllByViewCod(int viewCod, int fileType)
        {
            return _adminImageGalleryService.GetAllByViewCod(viewCod, fileType);
        }

        public void AddRanger(IEnumerable<AdminImageGallery> adminImageGallery)
        {
            _adminImageGalleryService.AddRanger(adminImageGallery);
        }
        
        public IEnumerable<AdminImageGallery> GetAllByViewDataId(int viewDataId, int fileType)
        {
            return _adminImageGalleryService.GetAllByViewDataId(viewDataId, fileType);
        }
        
        public AdminImageGallery GetByFileName(string fileName)
        {
            return _adminImageGalleryService.GetByFileName(fileName);
        }
        
        public void UpdateAll(IEnumerable<AdminImageGallery> adminImageGallery)
        {
            _adminImageGalleryService.UpdateAll(adminImageGallery);
        }
    }
}
