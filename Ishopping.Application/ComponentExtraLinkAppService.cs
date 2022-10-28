using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;
using Ishopping.Application.Common;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentExtraLinkAppService : AppServiceBaseT2<ComponentExtraLink>, IComponentExtraLinkAppService
    {
        private readonly IComponentExtraLinkService _componentExtraLinkService;
        private readonly IComponentExtraLinkOptionService _componentExtraLinkOptionService;

        public ComponentExtraLinkAppService(
            IComponentExtraLinkService componentExtraLinkService,
            IComponentExtraLinkOptionService componentExtraLinkOptionService)
            :base(componentExtraLinkService)
        {
            _componentExtraLinkService = componentExtraLinkService;
            _componentExtraLinkOptionService = componentExtraLinkOptionService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentExtraLinkService.Search(startsWith, userId);
        }

        public IEnumerable<ComponentExtraLink> GetAllBySiteNumber(int siteNumber)
        {
            return _componentExtraLinkService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentExtraLink Get(string title, string userId)
        {
            return _componentExtraLinkService.GetByTerm(title, userId);
        }

        public ComponentExtraLink GetBySiteNumber(int siteNumber)
        {
            return _componentExtraLinkService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentExtraLink> GetAllByUserId(string userId)
        {
            return _componentExtraLinkService.GetAllByUserId(userId);
        }

        public ComponentExtraLink GetById(Guid id, string userId)
        {
            return _componentExtraLinkService.GetById(id, userId);
        }

        public ComponentExtraLink GetByTerm(string title, string userId)
        {
            return _componentExtraLinkService.GetByTerm(title, userId);
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentExtraLinkService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentExtraLink> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentExtraLinkService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentExtraLink>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentExtraLinkService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentExtraLink>> GetAllByUserIdAsync(string userId)
        {
            return await _componentExtraLinkService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentExtraLink> GetByIdAsync(Guid id, string userId)
        {
            return await _componentExtraLinkService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentExtraLink> GetByTermAsync(string term, string userId)
        {
            return await _componentExtraLinkService.GetByTermAsync(term, userId);
        }  


        // Other Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentExtraLinkOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, description = obj.Description, textLink = obj.TextLink };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<object> GetObjetoAsync(string search, string userId)
        {
            var obj = await _componentExtraLinkService.GetByTermAsync(search, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, description = obj._Description, textLink = obj._TextLink, link = obj.Link, stDescription = obj.ComponentExtraLinkOption.Description, stTextLink = obj.ComponentExtraLinkOption.TextLink };
            }
            else
            {
                return new JsonFileNotFound();
            }  
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string link, string textLink, string styleTextLink, string description, string styleDescription)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var extraLinkOption = await _componentExtraLinkOptionService.PutAsync(styleTextLink, styleDescription, userId);

            if (_id != Guid.Empty)
            {
                var extraLink = await _componentExtraLinkService.GetByIdAsync(_id, userId);
                extraLink.Change(textLink, link, description);

                if(extraLinkOption.Id == Guid.Empty)
                {
                    if(extraLink.ComponentExtraLinkOption.Default)
                    {
                        extraLink.AddComponentExtraLinkOption(extraLinkOption);
                    }
                    else
                    {
                        extraLink.ComponentExtraLinkOption.Change(false, styleTextLink, styleDescription);
                    }
                    _componentExtraLinkService.Update(extraLink);
                }
                else
                {
                    var optionOld = extraLink.ComponentExtraLinkOptionId;
                    bool optionDefault = extraLink.ComponentExtraLinkOption.Default;

                    extraLink.ChangeComponentExtraLinkOption(extraLinkOption.Id);
                    _componentExtraLinkService.Update(extraLink);

                    if (!optionDefault)
                    {
                        var obj = await _componentExtraLinkOptionService.GetByIdAsync(optionOld);
                        _componentExtraLinkOptionService.Remove(obj);
                    }
                }                            
                json.Id = extraLink.Id.ToString();
                return json;
            }
            else
            {
                if(extraLinkOption.Id == Guid.Empty)
                {
                    var extraLink = new ComponentExtraLink(userId, siteNumber, extraLinkOption, textLink, link, description);
                    _componentExtraLinkService.Add(extraLink);
                    json.Id = extraLink.Id.ToString();
                    return json;
                }
                else
                {
                    var extraLink = new ComponentExtraLink(userId, siteNumber, extraLinkOption.Id, textLink, link, description);
                    _componentExtraLinkService.Add(extraLink);
                    json.Id = extraLink.Id.ToString();
                    return json;
                }                           
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var extraLink = await _componentExtraLinkService.GetByIdAsync(_id, userId);

            if (extraLink != null)
            {
                var optionOld = extraLink.ComponentExtraLinkOptionId;
                bool optionDefault = extraLink.ComponentExtraLinkOption.Default;

                _componentExtraLinkService.Remove(extraLink);

                if (!optionDefault)
                {
                    var obj = await _componentExtraLinkOptionService.GetByIdAsync(optionOld);
                    _componentExtraLinkOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(extraLink.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentExtraLinkService.DeleteAll(userId);
        }
    }
}
