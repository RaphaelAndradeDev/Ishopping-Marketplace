using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;
using Ishopping.Application.Common;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentMenuAppService : AppServiceBaseT2<ComponentMenu>, IComponentMenuAppService
    {
        private readonly IComponentMenuService _componentMenuService;
        private readonly IComponentMenuOptionService _componentMenuOptionService;
        private readonly IUserImageGalleryService _userImageGalleryService;   

        public ComponentMenuAppService(
            IComponentMenuService componentMenuService,
            IComponentMenuOptionService componentMenuOptionService,
            IUserImageGalleryService userImageGalleryService)
            :base(componentMenuService)
        {
            _componentMenuService = componentMenuService;
            _componentMenuOptionService = componentMenuOptionService;
            _userImageGalleryService = userImageGalleryService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentMenuService.Search(startsWith, userId);
        }

        public ComponentMenu GetByImageId(Guid imageId)
        {
            return _componentMenuService.GetByImageId(imageId);
        }

        public IEnumerable<ComponentMenu> GetAllBySiteNumber(int siteNumber)
        {
            return _componentMenuService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentMenu Get(string title, string userId)
        {
            return _componentMenuService.GetByTerm(title, userId);
        }
             
        public ComponentMenu GetBySiteNumber(int siteNumber)
        {
            return _componentMenuService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentMenu> GetAllByUserId(string userId)
        {
            return _componentMenuService.GetAllByUserId(userId);
        }

        public ComponentMenu GetById(Guid id, string userId)
        {
            return _componentMenuService.GetById(id, userId);
        }

        public ComponentMenu GetByTerm(string title, string userId)
        {
            return _componentMenuService.GetByTerm(title, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentMenuService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentMenu> GetByImageIdAsync(Guid imageId)
        {
            return await _componentMenuService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentMenu> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentMenuService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentMenu>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentMenuService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentMenu>> GetAllByUserIdAsync(string userId)
        {
            return await _componentMenuService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentMenu> GetByIdAsync(Guid id, string userId)
        {
            return await _componentMenuService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentMenu> GetByTermAsync(string term, string userId)
        {
            return await _componentMenuService.GetByTermAsync(term, userId);
        }  
      

        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentMenuOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, description = obj.Description, price = obj.Price, title = obj.Title };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string title, string styleTitle, string description, string styleDescription, string category, decimal price, string stylePrice, bool isDynamic, string dayOfWeek, string imageFileName)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var imageGallery = await _userImageGalleryService.GetByAsync(13, imageFileName, userId);
            if (imageGallery == null)
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            var menuOption = await _componentMenuOptionService.PutAsync(styleTitle, styleDescription, stylePrice, userId);

            if (_id != Guid.Empty)
            {
                var menu = await _componentMenuService.GetByIdAsync(_id, userId);
                json.Redirect = menu.UserImageGallery.FileName != imageGallery.FileName;
                menu.Change(imageGallery.Id, menuOption.Id, title, price, category, description, dayOfWeek, isDynamic);

                if(menuOption.Id == Guid.Empty)
                {
                    if(menu.ComponentMenuOption.Default)
                    {
                        menu.AddComponentMenuOption(menuOption);
                    }
                    else
                    {
                        menu.ComponentMenuOption.Change(false, styleTitle, styleDescription, stylePrice);
                    }
                    _componentMenuService.Update(menu);
                }
                else
                {
                    var optionOld = menu.ComponentMenuOptionId;
                    bool optionDefault = menu.ComponentMenuOption.Default;

                    menu.ChangeComponentMenuOption(menuOption.Id);
                    _componentMenuService.Update(menu);

                    if (!optionDefault)
                    {
                        var obj = await _componentMenuOptionService.GetByIdAsync(optionOld);
                        _componentMenuOptionService.Remove(obj);
                    }
                }                
                json.Id = menu.Id.ToString();
                return json;
            }
            else
            {
                if(menuOption.Id == Guid.Empty)
                {
                    var menu = new ComponentMenu(userId, siteNumber, imageGallery.Id, menuOption, title, price, category, description, dayOfWeek, isDynamic);
                    _componentMenuService.Add(menu);               
                }
                else
                {
                    var menu = new ComponentMenu(userId, siteNumber, imageGallery.Id, menuOption.Id, title, price, category, description, dayOfWeek, isDynamic);
                    _componentMenuService.Add(menu);                  
                }
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var menu = await _componentMenuService.GetByIdAsync(_id, userId);

            if (menu != null)
            {
                var optionOld = menu.ComponentMenuOptionId;
                bool optionDefault = menu.ComponentMenuOption.Default;

                _componentMenuService.Remove(menu);

                if (!optionDefault)
                {
                    var obj = await _componentMenuOptionService.GetByIdAsync(optionOld);
                    _componentMenuOptionService.Remove(obj);
                }
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(menu.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentMenuService.DeleteAll(userId);
        }
    }
}
