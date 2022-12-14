using Ishopping.Application.Common;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IUserImageGalleryAppService : IAppServiceBaseT2<UserImageGallery>
    {        
        // Sync Methods
        int CountImg(int fileType, string userId);              
        UserImageGallery GetByFileName(string fileName);
        UserImageGallery GetBy(int fileType, Guid id, string userId);
        UserImageGallery GetBy(int fileType, string fileName, string userId);
        UserImageGallery GetById(string id, string userId);
        IEnumerable<UserImageGallery> GetAllBySiteNumber(int siteNumber, int fileType);
        IEnumerable<UserImageGallery> GetAllBy(int fileType, int viewCod, string userId);
        IEnumerable<UserImageGallery> GetAllBy(int fileType, string userId);
        IEnumerable<UserImageGallery> GetAllisContain(List<string> listFileName, int fileType, string userId);        
        void AddRanger(IEnumerable<UserImageGallery> userImageGallery);
        void UpdateAll(IEnumerable<UserImageGallery> userImageGallery);
        void RemoveRanger(IEnumerable<UserImageGallery> userImageGallery);
        ImageGalleryResponse FileUpload(string userId, int fileType, int templateCod);
                

        // Async Methods
        Task<UserImageGallery> GetByAsync(int fileType, Guid id, string userId);
        Task<UserImageGallery> GetByAsync(int fileType, string fileName, string userId);
        Task<UserImageGallery> GetByIdAsync(string id, string userId);
        Task<UserImageGallery> GetByFileNameAsync(string fileName);
        Task<IEnumerable<UserImageGallery>> GetAllBySiteNumberAsync(int siteNumber, int fileType);
        Task<IEnumerable<UserImageGallery>> GetAllByAsync(int fileType, int viewCod, string userId);
        Task<IEnumerable<UserImageGallery>> GetAllByAsync(int fileType, string userId);
        Task<IEnumerable<UserImageGallery>> GetAllisContainAsync(List<string> listFileName, int fileType, string userId);
        Task<IEnumerable<UserImageGallery>> GetAllisContainAsync(IEnumerable<int> fileType, string userId);
        Task<ImageGalleryResponse> FileUploadAsync(string userId, int fileType, int templateCod);
        Task<ImageGalleryResponse> FileUploadAsync(string userId, int fileType, int templateCod, int viewCod);

        // Methods for admin
        Task<IEnumerable<UserImageGallery>> GetAllToVerifyAsync();
        Task<IEnumerable<UserImageGallery>> GetAllToVerifyAsync(int fileType);
        void SetImageCheck(IEnumerable<AdminImageChecked> adminImageChecked);
    }
}
