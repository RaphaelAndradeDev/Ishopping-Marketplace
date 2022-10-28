using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.ApplicationClass;

namespace Ishopping.Domain.Services
{
    public class UserImageGalleryService : ServiceBaseT2<UserImageGallery>, IUserImageGalleryService
    {
        private readonly IUserImageGalleryRepository _userImageGalleryRepository;
        private readonly IUserImageGalleryDapperRepository _userImageGalleryDapperRepository;

        public UserImageGalleryService(
            IUserImageGalleryRepository userImageGalleryRepository,
            IUserImageGalleryDapperRepository userImageGalleryDapperRepository)
            :base(userImageGalleryRepository)
        {
            _userImageGalleryRepository = userImageGalleryRepository;
            _userImageGalleryDapperRepository = userImageGalleryDapperRepository;
        }

        // Sync Methods
        public int CountImg(int fileType, string userId)
        {
            return _userImageGalleryDapperRepository.CountImg(fileType, userId);
        }

        public UserImageGallery GetBy(int fileType, Guid id, string userId)
        {
            throw new NotImplementedException();
        }

        public UserImageGallery GetBy(int fileType, string fileName, string userId)
        {
            return _userImageGalleryRepository.GetBy(fileType, fileName, userId);
        }

        public UserImageGallery GetById(string id, string userId)
        {
            return _userImageGalleryRepository.GetById(id, userId);
        }

        public UserImageGallery GetByFileName(string fileName)
        {
            return _userImageGalleryRepository.GetByFileName(fileName);
        }

        public IEnumerable<UserImageGallery> GetAllBySiteNumber(int siteNumber, int fileType)
        {
            return _userImageGalleryRepository.GetAllBySiteNumber(siteNumber, fileType);
        }

        public IEnumerable<UserImageGallery> GetAllBy(int fileType, int viewCod, string userId)
        {
            return _userImageGalleryRepository.GetAllBy(fileType, viewCod, userId);
        }
        
        public IEnumerable<UserImageGallery> GetAllBy(int fileType, string userId)
        {
            return _userImageGalleryRepository.GetAllBy(fileType, userId);
        }

        public IEnumerable<UserImageGallery> GetAllisContain(List<string> listFileName, int fileType, string userId)
        {
            return _userImageGalleryRepository.GetAllisContain(listFileName, fileType, userId);
        }

        public void AddRanger(IEnumerable<UserImageGallery> userImageGallery)
        {
            _userImageGalleryRepository.AddRanger(userImageGallery);
        }

        public void UpdateAll(IEnumerable<UserImageGallery> userImageGallery)
        {
            _userImageGalleryRepository.UpdateAll(userImageGallery);
        }

        public void RemoveRanger(IEnumerable<UserImageGallery> userImageGallery)
        {
            _userImageGalleryRepository.RemoveRanger(userImageGallery);
        }
          

        // Async Methods
        public async Task<int> CountImgAsync(int fileType, string userId)
        {
            return await _userImageGalleryDapperRepository.CountImgAsync(fileType, userId);
        }

        public async Task<UserImageGallery> GetByAsync(int fileType, Guid id, string userId)
        {
            return await _userImageGalleryRepository.GetByAsync(fileType, id, userId);
        }

        public async Task<UserImageGallery> GetByAsync(int fileType, string fileName, string userId)
        {
            return await _userImageGalleryRepository.GetByAsync(fileType, fileName, userId);
        }

        public async Task<UserImageGallery> GetByIdAsync(string id, string userId)
        {
            return await _userImageGalleryRepository.GetByIdAsync(id, userId);
        }

        public async Task<UserImageGallery> GetByFileNameAsync(string fileName)
        {
            return await _userImageGalleryRepository.GetByFileNameAsync(fileName);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllBySiteNumberAsync(int siteNumber, int fileType)
        {
            return await _userImageGalleryRepository.GetAllBySiteNumberAsync(siteNumber, fileType);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllByAsync(int fileType, int viewCod, string userId)
        {
            return await _userImageGalleryRepository.GetAllByAsync(fileType, viewCod, userId);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllByAsync(int fileType, string userId)
        {
            return await _userImageGalleryRepository.GetAllByAsync(fileType, userId);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllisContainAsync(List<string> listFileName, int fileType, string userId)
        {
            return await _userImageGalleryRepository.GetAllisContainAsync(listFileName, fileType, userId);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllisContainAsync(IEnumerable<int> fileType, string userId)
        {
            return await _userImageGalleryRepository.GetAllisContainAsync(fileType, userId);
        }

        public async Task<BasicImage> GetImageByViewCod(int viewCod, int fileType, int position, int siteNumber)
        {
            return await _userImageGalleryDapperRepository.GetImageByViewCod(viewCod, fileType, position, siteNumber);
        }


        // Methods for admin
        public async Task<IEnumerable<UserImageGallery>> GetAllToVerifyAsync()
        {
            return await _userImageGalleryRepository.GetAllToVerifyAsync();
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllToVerifyAsync(int fileType)
        {
            return await _userImageGalleryRepository.GetAllToVerifyAsync(fileType);
        }
        
        public void SetImageCheck(IEnumerable<AdminImageChecked> adminImageChecked)
        {
            _userImageGalleryDapperRepository.SetImageCheck(adminImageChecked);
        }
    }
}
