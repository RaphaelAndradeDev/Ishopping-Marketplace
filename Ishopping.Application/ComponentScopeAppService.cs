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
    public class ComponentScopeAppService : AppServiceBaseT2<ComponentScope>, IComponentScopeAppService
    {
        private readonly IComponentScopeService _componentScopeService;
        private readonly IComponentScopeOptionService _componentScopeOptionService;

        public ComponentScopeAppService(
            IComponentScopeService componentScopeService,
            IComponentScopeOptionService componentScopeOptionService)
            :base(componentScopeService)
        {
            _componentScopeService = componentScopeService;
            _componentScopeOptionService = componentScopeOptionService;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentScopeService.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentScope> GetAllBySiteNumber(int siteNumber)
        {
            return _componentScopeService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentScope GetBySiteNumber(int siteNumber)
        {
            return _componentScopeService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentScope> GetAllByUserId(string userId)
        {
            return _componentScopeService.GetAllByUserId(userId);
        }

        public ComponentScope GetById(Guid id, string userId)
        {
            return _componentScopeService.GetById(id, userId);
        }

        public ComponentScope GetBy(string title, int position, string userId)
        {
            return _componentScopeService.GetBy(title, position, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentScopeService.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentScope> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentScopeService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentScope>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentScopeService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentScope>> GetAllByUserIdAsync(string userId)
        {
            return await _componentScopeService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentScope> GetByIdAsync(Guid id, string userId)
        {
            return await _componentScopeService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentScope> GetByAsync(string search, int position, string userId)
        {
            return await _componentScopeService.GetByAsync(search, position, userId);
        }


        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentScopeOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, title = obj.Title, description = obj.Description, category = obj.Category };
            }
            else
            {
                return new JsonFileNotFound();
            } 
        }

        public async Task<object> GetObjetoAsync(string search, int position, string userId)
        {
            var obj = await _componentScopeService.GetByAsync(search, position, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, title = obj._Title, description = obj._Description, category = obj.Category, vectorIcon = obj.VectorIcon, stTitle = obj.ComponentScopeOption.Title, stDescription = obj.ComponentScopeOption.Description, stCategory = obj.Category };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string category, string styleCategory, string description, string styleDescription, string icon)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var scopeOption = await _componentScopeOptionService.PutAsync(styleTitle, styleCategory, styleDescription, userId);

            if (_id != Guid.Empty)
            {
                var scope = await _componentScopeService.GetByIdAsync(_id, userId);
                scope.Change(title, icon, category, description, position);

                if(scopeOption.Id == Guid.Empty)
                {
                    if(scope.ComponentScopeOption.Default)
                    {
                        scope.AddComponentScopeOption(scopeOption);
                    }
                    else
                    {
                        scope.ComponentScopeOption.Change(false, styleTitle, styleCategory, styleDescription);
                    }
                    _componentScopeService.Update(scope);
                }
                else
                {
                    var optionOld = scope.ComponentScopeOptionId;
                    bool optionDefault = scope.ComponentScopeOption.Default;

                    scope.ChangeComponentScopeOption(scopeOption.Id);
                    _componentScopeService.Update(scope);

                    if (!optionDefault)
                    {
                        var obj = await _componentScopeOptionService.GetByIdAsync(optionOld);
                        _componentScopeOptionService.Remove(obj);
                    } 
                }
                json.Id = scope.Id.ToString();
                return json;
            }
            else
            {
                if(scopeOption.Id == Guid.Empty)
                {
                    var scope = new ComponentScope(userId, siteNumber, scopeOption, title, icon, category, description, position);
                    _componentScopeService.Add(scope);
                    json.Id = scope.Id.ToString();
                    return json;
                }
                else
                {
                    var scope = new ComponentScope(userId, siteNumber, scopeOption.Id, title, icon, category, description, position);
                    _componentScopeService.Add(scope);
                    json.Id = scope.Id.ToString();
                    return json;
                }             
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var scope = await _componentScopeService.GetByIdAsync(_id, userId);

            if (scope != null)
            {
                var optionOld = scope.ComponentScopeOptionId;
                bool optionDefault = scope.ComponentScopeOption.Default;

                _componentScopeService.Remove(scope);

                if (!optionDefault)
                {
                    var obj = await _componentScopeOptionService.GetByIdAsync(optionOld);
                    _componentScopeOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(scope.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentScopeService.DeleteAll(userId);
        }
    }
}
