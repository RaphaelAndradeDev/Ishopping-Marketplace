using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;
using Ishopping.Application.Common;
using Ishopping.Domain.ApplicationClass;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentServiceAppService : AppServiceBaseT2<ComponentService>, IComponentServiceAppService
    {
        private readonly IComponentServiceService _componentServiceService;
        private readonly IComponentServiceOptionService _componentServiceOptionService;
        private readonly IUserImageGalleryService _userImageGalleryService;  

        public ComponentServiceAppService(
            IComponentServiceService componentServiceService,
            IComponentServiceOptionService componentServiceOptionService,
            IUserImageGalleryService userImageGalleryService)
            :base(componentServiceService)
        {
            _componentServiceService = componentServiceService;
            _componentServiceOptionService = componentServiceOptionService;
            _userImageGalleryService = userImageGalleryService;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentServiceService.Search(startsWith, position, userId);
        }

        public ComponentService GetByImageId(Guid imageId)
        {
            return _componentServiceService.GetByImageId(imageId);
        }

        public IEnumerable<ComponentService> GetAllBySiteNumber(int siteNumber)
        {
            return _componentServiceService.GetAllBySiteNumber(siteNumber);
        }
   
        public ComponentService GetBySiteNumber(int siteNumber)
        {
            return _componentServiceService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentService> GetAllByUserId(string userId)
        {
            return _componentServiceService.GetAllByUserId(userId);
        }

        public ComponentService GetById(Guid id, string userId)
        {
            return _componentServiceService.GetById(id, userId);
        }

        public ComponentService GetBy(string title, int position, string userId)
        {
            return _componentServiceService.GetBy(title, position, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentServiceService.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentService> GetByImageIdAsync(Guid imageId)
        {
            return await _componentServiceService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentService> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentServiceService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentService>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentServiceService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentService>> GetAllByUserIdAsync(string userId)
        {
            return await _componentServiceService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentService> GetByIdAsync(Guid id, string userId)
        {
            return await _componentServiceService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentService> GetByAsync(string search, int position, string userId)
        {
            return await _componentServiceService.GetByAsync(search, position, userId);
        }


        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentServiceOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, description = obj.Description, title = obj.Title };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string description, string styleDescription, string imageFileName)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var imageGallery = await _userImageGalleryService.GetByAsync(11, imageFileName, userId);
            if (imageGallery == null)
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            var serviceOption = await _componentServiceOptionService.PutAsync(styleTitle, styleDescription, userId);

            if (_id != Guid.Empty)
            {
                var service = await _componentServiceService.GetByIdAsync(_id, userId);
                json.Redirect = service.UserImageGallery.FileName != imageGallery.FileName;
                service.Change(imageGallery.Id, title, description, position);

                if(serviceOption.Id == Guid.Empty)
                {
                    if(service.ComponentServiceOption.Default)
                    {
                        service.AddComponentServiceOption(serviceOption);
                    }
                    else
                    {
                        service.ComponentServiceOption.Change(false, styleTitle, styleDescription);
                    }
                    _componentServiceService.Update(service);
                }
                else
                {
                    var optionOld = service.ComponentServiceOptionId;
                    bool optionDefault = service.ComponentServiceOption.Default;

                    service.ChangeComponentServiceOption(serviceOption.Id);
                    _componentServiceService.Update(service);

                    if (!optionDefault)
                    {
                        var obj = await _componentServiceOptionService.GetByIdAsync(optionOld);
                        _componentServiceOptionService.Remove(obj);
                    }
                }
                json.Id = service.Id.ToString();
                return json;
            }
            else
            {
                if(serviceOption.Id == Guid.Empty)
                {
                    var service = new ComponentService(userId, siteNumber, imageGallery.Id, serviceOption, title, description, position);
                    _componentServiceService.Add(service);
                }
                else
                {
                    var service = new ComponentService(userId, siteNumber, imageGallery.Id, serviceOption.Id, title, description, position);
                    _componentServiceService.Add(service);
                }              
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var service = await _componentServiceService.GetByIdAsync(_id, userId);

            if (service != null)
            {
                var optionOld = service.ComponentServiceOptionId;
                bool optionDefault = service.ComponentServiceOption.Default;

                _componentServiceService.Remove(service);

                if (!optionDefault)
                {
                    var obj = await _componentServiceOptionService.GetByIdAsync(optionOld);
                    _componentServiceOptionService.Remove(obj);
                }
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(service.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentServiceService.DeleteAll(userId);
        }
    }
}
