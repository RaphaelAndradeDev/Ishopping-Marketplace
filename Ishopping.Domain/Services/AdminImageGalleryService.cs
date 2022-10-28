using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Domain.Services
{
    public class AdminImageGalleryService : ServiceBase<AdminImageGallery>, IAdminImageGalleryService
    {
        private readonly IAdminImageGalleryRepository _adminImageGalleryRepository;
        private readonly IAdminImageGalleryDapperRepository _adminImageGalleryDapperRepository;

        public AdminImageGalleryService(
            IAdminImageGalleryRepository adminImageGalleryRepository,
            IAdminImageGalleryDapperRepository adminImageGalleryDapperRepository)
            : base(adminImageGalleryRepository)
        {
            _adminImageGalleryRepository = adminImageGalleryRepository;
            _adminImageGalleryDapperRepository = adminImageGalleryDapperRepository;
        }

        public IEnumerable<AdminImageGallery> GetAllByViewCod(int viewCod, int fileType)
        {
            return _adminImageGalleryDapperRepository.GetAllByViewCod(viewCod, fileType);
        }

        public void AddRanger(IEnumerable<AdminImageGallery> adminImageGallery)
        {
            _adminImageGalleryRepository.AddRanger(adminImageGallery);
        }
        
        public IEnumerable<AdminImageGallery> GetAllByViewDataId(int viewDataId, int fileType)
        {
            return _adminImageGalleryRepository.GetAllByViewDataId(viewDataId, fileType);
        }
        
        public AdminImageGallery GetByFileName(string fileName)
        {
            return _adminImageGalleryRepository.GetByFileName(fileName);
        }


        public void UpdateAll(IEnumerable<AdminImageGallery> adminImageGallery)
        {
            _adminImageGalleryRepository.UpdateAll(adminImageGallery);
        }
    }
}
