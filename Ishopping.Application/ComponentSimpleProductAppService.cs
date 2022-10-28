using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentSimpleProductAppService : AppServiceBaseT2<ComponentSimpleProduct>, IComponentSimpleProductAppService
    {
        private readonly IComponentSimpleProductService _componentSimpleProductService;
        private readonly IComponentSimpleProductOptionService _componentSimpleProductOptionService;
        private readonly IUserImageGalleryService _userImageGalleryService;  

        public ComponentSimpleProductAppService(
            IComponentSimpleProductService componentSimpleProductService,
            IComponentSimpleProductOptionService componentSimpleProductOptionService,
            IUserImageGalleryService userImageGalleryService)
            : base(componentSimpleProductService)
        {
            _componentSimpleProductService = componentSimpleProductService;
            _componentSimpleProductOptionService = componentSimpleProductOptionService;
            _userImageGalleryService = userImageGalleryService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentSimpleProductService.Search(startsWith, userId);
        }

        public ComponentSimpleProduct GetByImageId(Guid imageId)
        {
            return _componentSimpleProductService.GetByImageId(imageId);
        }

        public IEnumerable<ComponentSimpleProduct> GetAllBySiteNumber(int siteNumber)
        {
            return _componentSimpleProductService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentSimpleProduct GetBySiteNumber(int siteNumber)
        {
            return _componentSimpleProductService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentSimpleProduct> GetAllByUserId(string userId)
        {
            return _componentSimpleProductService.GetAllByUserId(userId);
        }

        public ComponentSimpleProduct GetById(Guid id, string userId)
        {
            return _componentSimpleProductService.GetById(id, userId);
        }

        public ComponentSimpleProduct GetByTerm(string title, string userId)
        {
            return _componentSimpleProductService.GetByTerm(title, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentSimpleProductService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentSimpleProduct> GetByImageIdAsync(Guid imageId)
        {
            return await _componentSimpleProductService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentSimpleProduct> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentSimpleProductService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSimpleProduct>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentSimpleProductService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSimpleProduct>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSimpleProductService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSimpleProduct> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSimpleProductService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSimpleProduct> GetByTermAsync(string term, string userId)
        {
            return await _componentSimpleProductService.GetByTermAsync(term, userId);
        } 
          

        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentSimpleProductOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, brand = obj.Brand, category = obj.Category, description = obj.Description, model = obj.Model, name = obj.Name, price = obj.Price };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, bool displayOnPage, bool displayOnlyPage, string name, string styleName, int category, string styleCategory, int subCategory, string brand, string styleBrand, string model, string styleModel, decimal price, string stylePrice, string description, string styleDescription, string tags, string img1, string img2, string img3)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var listImg = new List<string>() { img1, img2, img3 };

            var listImageGallery = await _userImageGalleryService.GetAllisContainAsync(listImg, 9, userId);

            if (listImageGallery.Count() == 0)
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            var productOption = await _componentSimpleProductOptionService.PutAsync(styleName, styleCategory, styleBrand, styleModel, styleDescription, stylePrice, userId);

            if (_id != Guid.Empty)
            {
                var product = await _componentSimpleProductService.GetByIdAsync(_id, userId);
                List<string> listImg2 = product.UserImageGallery.Select(x => x.FileName).ToList();
                json.Redirect = listImg.Except(listImg2).Any();
                product.Change(listImageGallery.ToList(), displayOnPage, displayOnlyPage, name, price, category, subCategory, brand, model, description, tags);

                if(productOption.Id == Guid.Empty)
                {
                    if(product.ComponentSimpleProductOption.Default)
                    {
                        product.AddComponentSimpleProductOption(productOption);
                    }
                    else
                    {
                        product.ComponentSimpleProductOption.Change(false, styleName, styleCategory, styleBrand, styleModel, styleDescription, stylePrice);
                    }
                    _componentSimpleProductService.UpdateBy(product);
                }
                else
                {
                    var optionOld = product.ComponentSimpleProductOptionId;
                    bool optionDefault = product.ComponentSimpleProductOption.Default;

                    product.ChangeComponentSimpleProductOption(productOption.Id);
                    _componentSimpleProductService.UpdateBy(product);

                    if (!optionDefault)
                    {
                        var obj = await _componentSimpleProductOptionService.GetByIdAsync(optionOld);
                        _componentSimpleProductOptionService.Remove(obj);
                    }
                }                
                json.Id = product.Id.ToString();
                return json;
            }
            else
            {
                if(productOption.Id == Guid.Empty)
                {
                    var product = new ComponentSimpleProduct(userId, siteNumber, listImageGallery.ToList(), productOption, displayOnPage, displayOnlyPage, name, price, category, subCategory, brand, model, description, tags);
                    _componentSimpleProductService.AddBy(product);
                }
                else
                {
                    var product = new ComponentSimpleProduct(userId, siteNumber, listImageGallery.ToList(), productOption.Id, displayOnPage, displayOnlyPage, name, price, category, subCategory, brand, model, description, tags);
                    _componentSimpleProductService.AddBy(product);
                }            
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var product = await _componentSimpleProductService.GetByIdAsync(_id, userId);

            if (product != null)
            {
                var optionOld = product.ComponentSimpleProductOptionId;
                bool optionDefault = product.ComponentSimpleProductOption.Default;

                _componentSimpleProductService.Remove(product);

                if (!optionDefault)
                {
                    var obj = await _componentSimpleProductOptionService.GetByIdAsync(optionOld);
                    _componentSimpleProductOptionService.Remove(obj);
                }
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(product.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentSimpleProductService.DeleteAll(userId);
        }
    }
}
