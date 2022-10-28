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
    public class ComponentSummaryAppService : AppServiceBaseT2<ComponentSummary>, IComponentSummaryAppService
    {
        private readonly IComponentSummaryService _componentSummaryService;
        private readonly IComponentSummaryOptionService _componentSummaryOptionService;

        public ComponentSummaryAppService(
            IComponentSummaryService componentSummaryService,
            IComponentSummaryOptionService componentSummaryOptionService)
            :base(componentSummaryService)
        {
            _componentSummaryService = componentSummaryService;
            _componentSummaryOptionService = componentSummaryOptionService;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentSummaryService.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentSummary> GetAllBySiteNumber(int siteNumber)
        {
            return _componentSummaryService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentSummary GetBySiteNumber(int siteNumber)
        {
            return _componentSummaryService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentSummary> GetAllByUserId(string userId)
        {
            return _componentSummaryService.GetAllByUserId(userId);
        }

        public ComponentSummary GetById(Guid id, string userId)
        {
            return _componentSummaryService.GetById(id, userId);
        }

        public ComponentSummary GetBy(string title, int position, string userId)
        {
            return _componentSummaryService.GetBy(title, position, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentSummaryService.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentSummary> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentSummaryService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSummary>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentSummaryService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSummary>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSummaryService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSummary> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSummaryService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSummary> GetByAsync(string search, int position, string userId)
        {
            return await _componentSummaryService.GetByAsync(search, position, userId);
        }
         
   
        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentSummaryOptionService.GetDefaultAsync(userId);
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
            var obj = await _componentSummaryService.GetByAsync(search, position, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, title = obj._Title, description = obj._Description, category = obj.Category, stTitle = obj.ComponentSummaryOption.Title, stDescription = obj.ComponentSummaryOption.Description, stCategory = obj.ComponentSummaryOption.Category };
            }
            else
            {
                return new JsonFileNotFound();
            }  
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string category, string styleCategory, string description, string styleDescription)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var summaryOption = await _componentSummaryOptionService.PutAsync(styleTitle, styleCategory, styleDescription, userId);

            if (_id != Guid.Empty)
            {
                var summary = await _componentSummaryService.GetByIdAsync(_id, userId);
                summary.Change(title, description, category, position);

                if(summaryOption.Id == Guid.Empty)
                {
                    if(summary.ComponentSummaryOption.Default)
                    {
                        summary.AddComponentSummaryOption(summaryOption);
                    }
                    else
                    {
                        summary.ComponentSummaryOption.Change(false, styleTitle, styleCategory, styleDescription);
                    }
                    _componentSummaryService.Update(summary);
                }
                else
                {
                    var optionOld = summary.ComponentSummaryOptionId;
                    bool optionDefault = summary.ComponentSummaryOption.Default;

                    summary.ChangeComponentSummaryOption(summaryOption.Id);
                    _componentSummaryService.Update(summary);

                    if (!optionDefault)
                    {
                        var obj = await _componentSummaryOptionService.GetByIdAsync(optionOld);
                        _componentSummaryOptionService.Remove(obj);
                    }
                }
                json.Id = summary.Id.ToString();
                return json;
            }
            else
            {
                if(summaryOption.Id == Guid.Empty)
                {
                    var summary = new ComponentSummary(userId, siteNumber, summaryOption, title, description, category, position);
                    _componentSummaryService.Add(summary);
                    json.Id = summary.Id.ToString();
                    return json;
                }
                else
                {
                    var summary = new ComponentSummary(userId, siteNumber, summaryOption.Id, title, description, category, position);
                    _componentSummaryService.Add(summary);
                    json.Id = summary.Id.ToString();
                    return json;
                }               
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var summary = await _componentSummaryService.GetByIdAsync(_id, userId);

            if (summary != null)
            {
                var optionOld = summary.ComponentSummaryOptionId;
                bool optionDefault = summary.ComponentSummaryOption.Default;

                _componentSummaryService.Remove(summary);

                if (!optionDefault)
                {
                    var obj = await _componentSummaryOptionService.GetByIdAsync(optionOld);
                    _componentSummaryOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(summary.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentSummaryService.DeleteAll(userId);
        }
    }
}
