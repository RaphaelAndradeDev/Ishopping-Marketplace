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
    public class ComponentPortofolioAppService : AppServiceBaseT2<ComponentPortofolio>, IComponentPortofolioAppService
    {
        private readonly IComponentPortofolioService _componentPortofolioService;
        private readonly IComponentPortfolioOptionService _componentPortfolioOptionService;
        private readonly IUserImageGalleryService _userImageGalleryService;   

        public ComponentPortofolioAppService(
            IComponentPortofolioService componentPortofolioService,
            IComponentPortfolioOptionService componentPortfolioOptionService,
            IUserImageGalleryService userImageGalleryService)
            :base(componentPortofolioService)
        {
            _componentPortofolioService = componentPortofolioService;
            _componentPortfolioOptionService = componentPortfolioOptionService;
            _userImageGalleryService = userImageGalleryService;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentPortofolioService.Search(startsWith, position, userId);
        }

        public ComponentPortofolio GetByImageId(Guid imageId)
        {
            return _componentPortofolioService.GetByImageId(imageId);
        }

        public IEnumerable<ComponentPortofolio> GetAllBySiteNumber(int siteNumber)
        {
            return _componentPortofolioService.GetAllBySiteNumber(siteNumber);
        }             
             
        public ComponentPortofolio GetBySiteNumber(int siteNumber)
        {
            return _componentPortofolioService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPortofolio> GetAllByUserId(string userId)
        {
            return _componentPortofolioService.GetAllByUserId(userId);
        }

        public ComponentPortofolio GetById(Guid id, string userId)
        {
            return _componentPortofolioService.GetById(id, userId);
        }

        public ComponentPortofolio GetBy(string title, int position, string userId)
        {
            return _componentPortofolioService.GetBy(title, position, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentPortofolioService.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentPortofolio> GetByImageIdAsync(Guid imageId)
        {
            return await _componentPortofolioService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentPortofolio> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentPortofolioService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPortofolio>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentPortofolioService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPortofolio>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPortofolioService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPortofolio> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPortofolioService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPortofolio> GetByAsync(string search, int position, string userId)
        {
            return await _componentPortofolioService.GetByAsync(search, position, userId);
        }


        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentPortfolioOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, category = obj.Category, title = obj.Title, description = obj.Description, list = obj.List };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, bool displayOnPage, bool displayOnlyPage, bool portfolioHead, bool portfolioChild, int position, string title, string styleTitle, string description, string styleDescription, string category, string styleCategory, string subCategory, string list, string styleList, string tags, string imageFileName)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var imageGallery = await _userImageGalleryService.GetByAsync(7, imageFileName, userId);
            if (imageGallery == null)
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            var portfolioOption = await _componentPortfolioOptionService.PutAsync(styleCategory, styleTitle, styleDescription, styleList, userId);

            if (_id != Guid.Empty)
            {
                var portfolio = await _componentPortofolioService.GetByIdAsync(_id, userId);
                json.Redirect = portfolio.UserImageGallery.FileName != imageGallery.FileName;
                portfolio.Change(imageGallery.Id, displayOnPage, displayOnlyPage, portfolioHead, portfolioChild, title, description, category, subCategory, list, false, position, tags);

                if(portfolioOption.Id == Guid.Empty)
                {
                    if(portfolio.ComponentPortofolioOption.Default)
                    {
                        portfolio.AddComponentPortofolioOption(portfolioOption);
                    }
                    else
                    {
                        portfolio.ComponentPortofolioOption.Change(false, styleCategory, styleTitle, styleDescription, styleList);
                    }
                    _componentPortofolioService.Update(portfolio);
                }
                else
                {
                    var optionOld = portfolio.ComponentPortofolioOptionId;
                    bool optionDefault = portfolio.ComponentPortofolioOption.Default;

                    portfolio.ChangeComponentPortofolioOption(portfolioOption.Id);
                    _componentPortofolioService.Update(portfolio);

                    if (!optionDefault)
                    {
                        var obj = await _componentPortfolioOptionService.GetByIdAsync(optionOld);
                        _componentPortfolioOptionService.Remove(obj);
                    }
                }
                json.Id = portfolio.Id.ToString();
                return json;
            }
            else
            {
                if(portfolioOption.Id == Guid.Empty)
                {
                    var portfolio = new ComponentPortofolio(userId, siteNumber, imageGallery.Id, portfolioOption, displayOnPage, displayOnlyPage, portfolioHead, portfolioChild, title, description, category, subCategory, list, false, position, tags);
                    _componentPortofolioService.Add(portfolio);
                }
                else
                {
                    var portfolio = new ComponentPortofolio(userId, siteNumber, imageGallery.Id, portfolioOption.Id, displayOnPage, displayOnlyPage, portfolioHead, portfolioChild, title, description, category, subCategory, list, false, position, tags);
                    _componentPortofolioService.Add(portfolio);
                }
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var portfolio = await _componentPortofolioService.GetByIdAsync(_id, userId);

            if (portfolio != null)
            {
                var optionOld = portfolio.ComponentPortofolioOptionId;
                bool optionDefault = portfolio.ComponentPortofolioOption.Default;

                _componentPortofolioService.Remove(portfolio);

                if (!optionDefault)
                {
                    var obj = await _componentPortfolioOptionService.GetByIdAsync(optionOld);
                    _componentPortfolioOptionService.Remove(obj);
                }
               
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(portfolio.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentPortofolioService.DeleteAll(userId);
        }
    }
}
