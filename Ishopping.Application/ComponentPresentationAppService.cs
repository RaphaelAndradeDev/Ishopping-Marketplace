using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentPresentationAppService : AppServiceBaseT2<ComponentPresentation>, IComponentPresentationAppService
    {
        private readonly IComponentPresentationService _componentPresentationService;
        private readonly IComponentPresentationOptionService _componentPresentationOptionService;
        private readonly IUserImageGalleryService _userImageGalleryService;   

        public ComponentPresentationAppService(
            IComponentPresentationService componentPresentationService,
            IComponentPresentationOptionService componentPresentationOptionService,
            IUserImageGalleryService userImageGalleryService)
            :base(componentPresentationService)
        {
            _componentPresentationService = componentPresentationService;
            _componentPresentationOptionService = componentPresentationOptionService;
            _userImageGalleryService = userImageGalleryService;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentPresentationService.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentPresentation> GetAllBySiteNumber(int siteNumber)
        {
            return _componentPresentationService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentPresentation GetBySiteNumber(int siteNumber)
        {
            return _componentPresentationService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPresentation> GetAllByUserId(string userId)
        {
            return _componentPresentationService.GetAllByUserId(userId);
        }

        public ComponentPresentation GetById(Guid id, string userId)
        {
            return _componentPresentationService.GetById(id, userId);
        }

        public ComponentPresentation GetBy(string title, int position, string userId)
        {
            return _componentPresentationService.GetBy(title, position, userId);
        }                 

        public ComponentPresentation GetByImageId(Guid imageId)
        {
            return _componentPresentationService.GetByImageId(imageId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentPresentationService.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentPresentation> GetByImageIdAsync(Guid imageId)
        {
            return await _componentPresentationService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentPresentation> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentPresentationService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPresentation>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentPresentationService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPresentation>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPresentationService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPresentation> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPresentationService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPresentation> GetByAsync(string search, int position, string userId)
        {
            return await _componentPresentationService.GetByAsync(search, position, userId);
        }


        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentPresentationOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, category = obj.Category, description = obj.Description, title = obj.Title };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string category, string styleCategory, string icon, string description, string styleDescription, string imageFileName)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var imageGallery = await _userImageGalleryService.GetByAsync(15, imageFileName, userId);
            if (imageGallery == null)
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            var presentationOption = await _componentPresentationOptionService.PutAsync(styleTitle, styleCategory, styleDescription, userId);

            if (_id != Guid.Empty)
            {
                var presentation = await _componentPresentationService.GetByIdAsync(_id, userId);
                json.Redirect = presentation.UserImageGallery.FileName != imageGallery.FileName;
                presentation.Change(imageGallery.Id, title, category, description, icon, position);

                if(presentationOption.Id == Guid.Empty)
                {
                    if(presentation.ComponentPresentationOption.Default)
                    {
                        presentation.AddComponentPresentationOption(presentationOption);
                    }
                    else
                    {
                        presentation.ComponentPresentationOption.Change(false, styleTitle, styleCategory, styleDescription);
                    }
                    _componentPresentationService.Update(presentation);
                }
                else
                {
                    var optionOld = presentation.ComponentPresentationOptionId;
                    bool optionDefault = presentation.ComponentPresentationOption.Default;

                    presentation.ChangeComponentPresentationOption(presentationOption.Id);
                    _componentPresentationService.Update(presentation);

                    if (!optionDefault)
                    {
                        var obj = await _componentPresentationOptionService.GetByIdAsync(optionOld);
                        _componentPresentationOptionService.Remove(obj);
                    }
                }                
                json.Id = presentation.Id.ToString();
                return json;
            }
            else
            {
                if(presentationOption.Id == Guid.Empty)
                {
                    var presentation = new ComponentPresentation(userId, siteNumber, imageGallery.Id, presentationOption, title, category, description, icon, position);
                    _componentPresentationService.Add(presentation);
                }
                else
                {
                    var presentation = new ComponentPresentation(userId, siteNumber, imageGallery.Id, presentationOption.Id, title, category, description, icon, position);
                    _componentPresentationService.Add(presentation);
                }              
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var presentation = await _componentPresentationService.GetByIdAsync(_id, userId);

            if (presentation != null)
            {
                var optionOld = presentation.ComponentPresentationOptionId;
                bool optionDefault = presentation.ComponentPresentationOption.Default;

                _componentPresentationService.Remove(presentation);

                if (!optionDefault)
                {
                    var obj = await _componentPresentationOptionService.GetByIdAsync(optionOld);
                    _componentPresentationOptionService.Remove(obj);
                }
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(presentation.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentPresentationService.DeleteAll(userId);
        }
    }
}
