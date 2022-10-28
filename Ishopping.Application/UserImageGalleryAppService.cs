using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class UserImageGalleryAppService : AppServiceBaseT2<UserImageGallery>, IUserImageGalleryAppService
    {
        private readonly IAdminViewDataService _adminViewDataService;
        private readonly IUserImageGalleryService _userImageGalleryService;
        private readonly IUserFinancialService _userFinancialService;
        private readonly IUserRegisterProfileService _userRegisterProfileService; 

        public UserImageGalleryAppService(
            IAdminViewDataService adminViewDataService,
            IUserImageGalleryService userImageGalleryService,
            IUserFinancialService userFinancialService,
            IUserRegisterProfileService userRegisterProfileService)
            :base(userImageGalleryService)
        {
            _adminViewDataService = adminViewDataService;
            _userImageGalleryService = userImageGalleryService;
            _userFinancialService = userFinancialService;
            _userRegisterProfileService = userRegisterProfileService;
        }

        // Sync Methods
        public int CountImg(int fileType, string userId)
        {
            return _userImageGalleryService.CountImg(fileType, userId);
        }

        public UserImageGallery GetBy(int fileType, Guid id, string userId)
        {
            return _userImageGalleryService.GetBy(fileType, id, userId);
        }

        public UserImageGallery GetBy(int fileType, string fileName, string userId)
        {
            return _userImageGalleryService.GetBy(fileType, fileName, userId);
        }

        public UserImageGallery GetById(string id, string userId)
        {
            return _userImageGalleryService.GetById(id, userId);
        }

        public UserImageGallery GetByFileName(string fileName)
        {
            return _userImageGalleryService.GetByFileName(fileName);
        }

        public IEnumerable<UserImageGallery> GetAllBySiteNumber(int siteNumber, int fileType)
        {
            return _userImageGalleryService.GetAllBySiteNumber(siteNumber, fileType);
        }

        public IEnumerable<UserImageGallery> GetAllBy(int fileType, int viewCod, string userId)
        {
            return _userImageGalleryService.GetAllBy(fileType, viewCod, userId);
        }
        
        public IEnumerable<UserImageGallery> GetAllBy(int fileType, string userId)
        {
            return _userImageGalleryService.GetAllBy(fileType, userId);
        }

        public IEnumerable<UserImageGallery> GetAllisContain(List<string> listFileName, int fileType, string userId)
        {
            return _userImageGalleryService.GetAllisContain(listFileName, fileType, userId);
        } 

        public void AddRanger(IEnumerable<UserImageGallery> userImageGallery)
        {
            _userImageGalleryService.AddRanger(userImageGallery);
        }
                        
        public void UpdateAll(IEnumerable<UserImageGallery> userImageGallery)
        {
            _userImageGalleryService.UpdateAll(userImageGallery);
        }
         
        public void RemoveRanger(IEnumerable<UserImageGallery> userImageGallery)
        {
            _userImageGalleryService.RemoveRanger(userImageGallery);
        }           

        public ImageGalleryResponse FileUpload(string userId, int fileType, int templateCod)
        {
            var currentPlan = _userFinancialService.GetCurrentPlan(userId);
            int imgCount = _userImageGalleryService.CountImg(fileType, userId);
            return new ImageGalleryResponse(imgCount, currentPlan.Gallery, fileType);
        }


        // Async Methods
        public async Task<ImageGalleryResponse> FileUploadAsync(string userId, int fileType, int templateCod)
        {
            var currentPlan = await _userFinancialService.GetCurrentPlanAsync(userId);
            int imgCount = await _userImageGalleryService.CountImgAsync(fileType, userId);
            return new ImageGalleryResponse(imgCount, currentPlan.Gallery, fileType);
        }

        public async Task<ImageGalleryResponse> FileUploadAsync(string userId, int fileType, int templateCod, int viewCod)
        {
            if (!Validate(fileType, templateCod, viewCod)) return new ImageGalleryResponse();
                          
            int? imageQuantity = null;
            if(fileType <= 3 && viewCod != 0)
            {
                imageQuantity = await ImageQuantity(fileType, templateCod, viewCod);
                if (imageQuantity == null) return new ImageGalleryResponse();
            }
                                                     
            int imgCount = await _userImageGalleryService.CountImgAsync(fileType, userId);
            var currentPlan = await _userFinancialService.GetCurrentPlanAsync(userId);

            return new ImageGalleryResponse(imgCount, currentPlan.Gallery, fileType, viewCod, imageQuantity);          
        }               
                
        public async Task<UserImageGallery> GetByAsync(int fileType, Guid id, string userId)
        {
            return await _userImageGalleryService.GetByAsync(fileType, id, userId);
        }

        public async Task<UserImageGallery> GetByAsync(int fileType, string fileName, string userId)
        {
            return await _userImageGalleryService.GetByAsync(fileType, fileName, userId);
        }

        public async Task<UserImageGallery> GetByIdAsync(string id, string userId)
        {
            return await _userImageGalleryService.GetByIdAsync(id, userId);
        }

        public async Task<UserImageGallery> GetByFileNameAsync(string fileName)
        {
            return await _userImageGalleryService.GetByFileNameAsync(fileName);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllBySiteNumberAsync(int siteNumber, int fileType)
        {
            return await _userImageGalleryService.GetAllBySiteNumberAsync(siteNumber, fileType);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllByAsync(int fileType, int viewCod, string userId)
        {
            return await _userImageGalleryService.GetAllByAsync(fileType, viewCod, userId);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllByAsync(int fileType, string userId)
        {
            return await _userImageGalleryService.GetAllByAsync(fileType, userId);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllisContainAsync(List<string> listFileName, int fileType, string userId)
        {
            return await _userImageGalleryService.GetAllisContainAsync(listFileName, fileType, userId);
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllisContainAsync(IEnumerable<int> fileType, string userId)
        {
            return await _userImageGalleryService.GetAllisContainAsync(fileType, userId);
        }

        // Methods for admin
        public async Task<IEnumerable<UserImageGallery>> GetAllToVerifyAsync()
        {
            return await _userImageGalleryService.GetAllToVerifyAsync();
        }

        public async Task<IEnumerable<UserImageGallery>> GetAllToVerifyAsync(int fileType)
        {
            return await _userImageGalleryService.GetAllToVerifyAsync(fileType);
        }

        public void SetImageCheck(IEnumerable<AdminImageChecked> adminImageChecked)
        {
            _userImageGalleryService.SetImageCheck(adminImageChecked);
            BlockProfile(adminImageChecked);
        }


        // Private Methods       
        private async Task<int?> ImageQuantity(int fileType, int templateCod, int viewCod)
        {
            var viewData = await _adminViewDataService.GetListImageAsync(templateCod, viewCod);

            if (viewData == null) return null;

            switch (fileType)
            {
                case 1:
                    return viewData.ListImage;
                case 2:
                    return viewData.ListIconPng;
                case 3:
                    return viewData.ListLogo;
                default:
                    return null;
            }
        }

        private bool Validate(int fileType, int templateCod, int viewCod)
        {
            bool a = !(fileType < 1 || fileType > 16 || templateCod < 2000 || templateCod > 5000);  // retorna v se for aprovado
            bool b = (viewCod > 2000 && viewCod < 5000) || viewCod == 0;                            // retorna v se for aprovado
            return a && b;                                                                          // retorna v se a & b for aprovada
        }

        private void BlockProfile(IEnumerable<AdminImageChecked> adminImageChecked)
        {
            var imageBlocks = adminImageChecked.Where(x => x.IsBlock);                      
            List<ProfileRestriction> profileRestrictions = new List<ProfileRestriction>();

            foreach (var item in imageBlocks)
	        {
                var profile = new ProfileRestriction(item.SiteNumber, true, item.FileType, item.FileName);
		        profileRestrictions.Add(profile);
	        }                                
            _userRegisterProfileService.SetRestriction(profileRestrictions);
        }
    }
}
