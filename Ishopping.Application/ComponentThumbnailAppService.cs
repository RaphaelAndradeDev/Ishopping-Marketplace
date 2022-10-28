using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentThumbnailAppService : AppServiceBaseT2<ComponentThumbnail>, IComponentThumbnailAppService
    {
        private readonly IComponentThumbnailService _componentThumbnailService;
        private readonly IUserImageGalleryService _userImageGalleryService;   

        public ComponentThumbnailAppService(
            IComponentThumbnailService componentThumbnailService,
            IUserImageGalleryService userImageGalleryService)
            :base(componentThumbnailService)
        {
            _componentThumbnailService = componentThumbnailService;
            _userImageGalleryService = userImageGalleryService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentThumbnailService.Search(startsWith, userId);
        }

        public ComponentThumbnail GetByImageId(Guid imageId)
        {
            return _componentThumbnailService.GetByImageId(imageId);
        }

        public IEnumerable<ComponentThumbnail> GetAllBySiteNumber(int siteNumber)
        {
            return _componentThumbnailService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentThumbnail Get(string title, string userId)
        {
            return _componentThumbnailService.GetByTerm(title, userId);
        }

        public ComponentThumbnail GetBySiteNumber(int siteNumber)
        {
            return _componentThumbnailService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentThumbnail> GetAllByUserId(string userId)
        {
            return _componentThumbnailService.GetAllByUserId(userId);
        }

        public ComponentThumbnail GetById(Guid id, string userId)
        {
            return _componentThumbnailService.GetById(id, userId);
        }

        public ComponentThumbnail GetByTerm(string title, string userId)
        {
            return _componentThumbnailService.GetByTerm(title, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentThumbnailService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentThumbnail> GetByImageIdAsync(Guid imageId)
        {
            return await _componentThumbnailService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentThumbnail> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentThumbnailService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentThumbnail>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentThumbnailService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentThumbnail>> GetAllByUserIdAsync(string userId)
        {
            return await _componentThumbnailService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentThumbnail> GetByIdAsync(Guid id, string userId)
        {
            return await _componentThumbnailService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentThumbnail> GetByTermAsync(string term, string userId)
        {
            return await _componentThumbnailService.GetByTermAsync(term, userId);
        }  


        // Others Methods
        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string category, string icon, string webSite, string imageFileName)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var imageGallery = await _userImageGalleryService.GetByAsync(14, imageFileName, userId);
            if (imageGallery == null)
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            if (_id != Guid.Empty)
            {
                var thumbnail = await _componentThumbnailService.GetByIdAsync(_id, userId);
                thumbnail.Change(imageGallery.Id, category, icon, webSite);
                _componentThumbnailService.Update(thumbnail);

                json.Id = thumbnail.Id.ToString();
                json.Redirect = thumbnail.UserImageGallery.FileName != imageGallery.FileName;
                return json;
            }
            else
            {
                var thumbnail = new ComponentThumbnail(userId, siteNumber, imageGallery.Id, category, icon, webSite);
                _componentThumbnailService.Add(thumbnail);

                json.Id = thumbnail.Id.ToString();
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var thumbnail = await _componentThumbnailService.GetByIdAsync(_id, userId);

            if (thumbnail != null)
            {     
                _componentThumbnailService.Remove(thumbnail);             
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(thumbnail.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentThumbnailService.DeleteAll(userId);
        }
    }
}
