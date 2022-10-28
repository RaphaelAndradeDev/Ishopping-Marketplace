using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentBrandAppService : AppServiceBaseT2<ComponentBrand>, IComponentBrandAppService
    {
        private readonly IComponentBrandService _componentBrandService;
        private readonly IComponentBrandOptionService _componentBrandOptionService;
        private readonly IUserImageGalleryService _userImageGalleryService;       
        

        public ComponentBrandAppService(
            IComponentBrandService componentBrandService,
            IComponentBrandOptionService componentBrandOptionService,
            IUserImageGalleryService userImageGalleryService)
            : base(componentBrandService)
        {
            _componentBrandService = componentBrandService;
            _componentBrandOptionService = componentBrandOptionService;
            _userImageGalleryService = userImageGalleryService;
        }

        // Sync Methdos
        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentBrandService.Search(startsWith, userId);
        }

        public ComponentBrand GetByImageId(Guid imageId)
        {
            return _componentBrandService.GetByImageId(imageId);
        }

        public IEnumerable<ComponentBrand> GetAllBySiteNumber(int siteNumber)
        {
            return _componentBrandService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentBrand GetBySiteNumber(int siteNumber)
        {
            return _componentBrandService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentBrand> GetAllByUserId(string userId)
        {
            return _componentBrandService.GetAllByUserId(userId);
        }

        public ComponentBrand GetById(Guid id, string userId)
        {
            return _componentBrandService.GetById(id, userId);
        }

        public ComponentBrand GetByTerm(string title, string userId)
        {
            return _componentBrandService.GetByTerm(title, userId);
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentBrandService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentBrand> GetByImageIdAsync(Guid imageId)
        {
            return await _componentBrandService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentBrand> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentBrandService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentBrand>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentBrandService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentBrand>> GetAllByUserIdAsync(string userId)
        {
            return await _componentBrandService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentBrand> GetByIdAsync(Guid id, string userId)
        {
            return await _componentBrandService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentBrand> GetByTermAsync(string term, string userId)
        {
            return await _componentBrandService.GetByTermAsync(term, userId);
        }  


        // Other Methods

        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentBrandOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, marca = obj.Marca, comment = obj.Comment };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string marca, string styleMarca, string comment, string styleComment, string siteOficial, string fileName)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var imageGallery = await _userImageGalleryService.GetByAsync(6, fileName, userId);
              if (imageGallery == null)
              {
                  json.Redirect = false;
                  json.Message = "Imagem não encontrada";
                  return json;
              }                        

            var brandOption = await _componentBrandOptionService.PutAsync(styleMarca, styleComment, userId);

            if (_id != Guid.Empty)
            {
                var brand = await _componentBrandService.GetByIdAsync(_id, userId);
                json.Redirect = brand.UserImageGallery.FileName != imageGallery.FileName;
                brand.Change(imageGallery.Id, marca, comment, siteOficial);

                if(brandOption.Id == Guid.Empty)
                {
                    if(brand.ComponentBrandOption.Default)
                    {
                        brand.AddComponentBrandOption(brandOption);
                    }
                    else
                    {
                        brand.ComponentBrandOption.Change(false, styleMarca, styleComment);
                    }
                    _componentBrandService.Update(brand);
                }
                else
                {
                    var optionOld = brand.ComponentBrandOptionId;
                    bool optionDefault = brand.ComponentBrandOption.Default;

                    brand.ChangeComponentBrandOption(brandOption.Id);
                    _componentBrandService.Update(brand);

                    if (!optionDefault)
                    {
                        var obj = await _componentBrandOptionService.GetByIdAsync(optionOld);
                        _componentBrandOptionService.Remove(obj);
                    }
                }              
                json.Id = brand.Id.ToString();
                return json;
            }
            else
            {
                if(brandOption.Id == Guid.Empty)
                {
                    var brand = new ComponentBrand(userId, siteNumber, imageGallery.Id, brandOption, marca, comment, siteOficial);
                    _componentBrandService.Add(brand);
                }
                else
                {
                    var brand = new ComponentBrand(userId, siteNumber, imageGallery.Id, brandOption.Id, marca, comment, siteOficial);
                    _componentBrandService.Add(brand);
                }
                json.Redirect = true;            
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var brand = await _componentBrandService.GetByIdAsync(_id, userId);

            if (brand != null)
            {
                var optionOld = brand.ComponentBrandOptionId;
                bool optionDefault = brand.ComponentBrandOption.Default;

                _componentBrandService.Remove(brand);

                if (!optionDefault)
                {
                    var obj = await _componentBrandOptionService.GetByIdAsync(optionOld);
                    _componentBrandOptionService.Remove(obj);
                }
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(brand.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentBrandService.DeleteAll(userId);
        }
    }
}
