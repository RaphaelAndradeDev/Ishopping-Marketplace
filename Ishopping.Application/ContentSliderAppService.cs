using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ContentSliderAppService : AppServiceBaseT2<ContentSlider>, IContentSliderAppService
    {
        private readonly IContentSliderService _contentSliderService;
        private readonly IAdminSliderConfigService _adminSliderConfigService;
        private readonly IUserImageGalleryService _userImageGalleryService;
        private readonly IUserRegisterProfileService _userRegisterProfile;

        public ContentSliderAppService(
            IContentSliderService contentSliderService,
            IAdminSliderConfigService adminSliderConfigService,
            IUserImageGalleryService userImageGalleryService,
            IUserRegisterProfileService userRegisterProfile)
            :base(contentSliderService)
        {
            _contentSliderService = contentSliderService;
            _adminSliderConfigService = adminSliderConfigService;
            _userImageGalleryService = userImageGalleryService;
            _userRegisterProfile = userRegisterProfile;
        }

        public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber)
        {
            return _contentSliderService.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentSliderService.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentSliderService.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentSlider> GetAllByUserId(string userId)
        {
            return _contentSliderService.GetAllByUserId(userId);
        }

        public IEnumerable<ContentSlider> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentSliderService.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentSlider> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentSliderService.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentSlider GetById(Guid id, string userId)
        {
            return _contentSliderService.GetById(id, userId);
        }

        public ContentSlider GetBy(int viewCod, int position, string userId)
        {
            return _contentSliderService.GetBy(viewCod, position, userId);
        }

        public List<ContentSlider> GetAllByViewCod(int viewCod, int sliderPosition, string userId)
        {
            return _contentSliderService.GetAllByViewCod(viewCod, sliderPosition, userId);
        }

        public void AddRanger(IEnumerable<ContentSlider> contentSlider)
        {
            _contentSliderService.AddRanger(contentSlider);
        }

        public ContentSlider GetByImageId(Guid imageId)
        {
            return _contentSliderService.GetByImageId(imageId);
        }


        // Async Methods
        public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentSliderService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentSliderService.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentSliderService.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentSlider>> GetAllByUserIdAsync(string userId)
        {
            return await _contentSliderService.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentSlider>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentSliderService.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentSlider>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentSliderService.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentSlider> GetByIdAsync(Guid id, string userId)
        {
            return await _contentSliderService.GetByIdAsync(id, userId);
        }

        public async Task<ContentSlider> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentSliderService.GetByAsync(viewCod, position, userId);
        }

        public async Task<List<ContentSlider>> GetAllByViewCodAsync(int viewCod, int sliderPosition, string userId)
        {
            return await _contentSliderService.GetAllByViewCodAsync(viewCod, sliderPosition, userId);
        }

        public async Task<ContentSlider> GetByImageIdAsync(Guid imageId)
        {
            return await _contentSliderService.GetByImageIdAsync(imageId);
        }


        // Others Methods
        public async Task<JsonResponse> AppUpdateAsync(string userId, ContentSlider contentSlider)
        {
            JsonResponse json = new JsonResponse();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);
            var adminSliderConfig = _adminSliderConfigService.GetBy(contentSlider.ViewCod, contentSlider.SliderType, contentSlider.SliderName, contentSlider.SliderClass);

            if (adminSliderConfig == null)
            {
                json.Serialize = false;
                json.Id = contentSlider.Id.ToString();
                json.Message = "Configurações de sliders não encontradas";                
                return json;
            }
            
            switch (contentSlider.SliderType)
            {
                case 1:
                    contentSlider.DataSplitin = "";
                    contentSlider.DataSplitout = "";
                    contentSlider.DataElementdelay = "";
                    contentSlider.DataEndelementdelay = "";
                    contentSlider.DataImgHeight = "";
                    contentSlider.DataImgWidth = "";
                    contentSlider.DataImgZindex = "";
                    contentSlider.ImageFileName = "";
                    break;
                case 2:       
                    contentSlider.DataImgHeight = "";
                    contentSlider.DataImgWidth = "";
                    contentSlider.DataImgZindex = "";
                    contentSlider.Url = "";
                    contentSlider.ImageFileName = "";
                    break;
                case 3:
                    contentSlider.Text = "";      
                    contentSlider.ImageFileName = "";
                    break;
                case 4:                               
                    var imageGallery = _userImageGalleryService.GetBy(16, contentSlider.ImageFileName, userId);
                      if (imageGallery == null)
                      {                        
                          json.Message = "Imagem não encontrada";
                          json.Id = contentSlider.Id.ToString();
                          return json;
                      }        
                    contentSlider.ImageUrl = "/Content/uploads/" + profile.SiteNumber + "/" + contentSlider.ImageFileName;
                     contentSlider.DataSplitin = "";
                    contentSlider.DataSplitout = "";
                    contentSlider.DataElementdelay = "";
                    contentSlider.DataEndelementdelay = "";
                    contentSlider.Caption = "";
                    contentSlider.Text = "";                
                    contentSlider.Url = "";
                    break;
            }

            contentSlider.PartialView = adminSliderConfig.PartialView;
            contentSlider.ClassTarget = adminSliderConfig.ClassTarget;
            contentSlider.SiteNumber = profile.SiteNumber;
            contentSlider.IdUser = userId;

            if (contentSlider.Id == Guid.Empty)
            {
                _contentSliderService.Add(contentSlider);
            }
            else
            {
                _contentSliderService.Update(contentSlider);
            }
            json.Id = contentSlider.Id.ToString();
            return json;
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var contentSlider = await _contentSliderService.GetByIdAsync(_id, userId);

            if (contentSlider != null)
            {
                _contentSliderService.Remove(contentSlider);                      
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(contentSlider.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _contentSliderService.DeleteAll(userId);
        }       
      
    }
}
