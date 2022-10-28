using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;
using Ishopping.Application.Common;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentFeaturesAppService : AppServiceBaseT2<ComponentFeatures>, IComponentFeaturesAppService
    {
        private readonly IComponentFeaturesService _componentFeaturesService;
        private readonly IComponentFeaturesOptionService _componentFeaturesOptionService;

        public ComponentFeaturesAppService(
            IComponentFeaturesService componentFeaturesService,
            IComponentFeaturesOptionService componentFeaturesOptionService)
            :base(componentFeaturesService)
        {
            _componentFeaturesService = componentFeaturesService;
            _componentFeaturesOptionService = componentFeaturesOptionService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentFeaturesService.Search(startsWith, userId);
        }

        public IEnumerable<ComponentFeatures> GetAllBySiteNumber(int siteNumber)
        {
            return _componentFeaturesService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentFeatures GetBySiteNumber(int siteNumber)
        {
            return _componentFeaturesService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentFeatures> GetAllByUserId(string userId)
        {
            return _componentFeaturesService.GetAllByUserId(userId);
        }

        public ComponentFeatures GetById(Guid id, string userId)
        {
            return _componentFeaturesService.GetById(id, userId);
        }

        public ComponentFeatures GetByTerm(string title, string userId)
        {
            return _componentFeaturesService.GetByTerm(title, userId);
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentFeaturesService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentFeatures> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentFeaturesService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentFeatures>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentFeaturesService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentFeatures>> GetAllByUserIdAsync(string userId)
        {
            return await _componentFeaturesService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentFeatures> GetByIdAsync(Guid id, string userId)
        {
            return await _componentFeaturesService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentFeatures> GetByTermAsync(string term, string userId)
        {
            return await _componentFeaturesService.GetByTermAsync(term, userId);
        } 


        // Others Methods   
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentFeaturesOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, count = obj.Count, title = obj.Title, description = obj.Description };
            }
            else
            {
                return new JsonFileNotFound();
            } 
        }

        public async Task<object> GetObjetoAsync(string search, string userId)
        {
            var obj = await _componentFeaturesService.GetByTermAsync(search, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, title = obj._Title, icon = obj.Icon, description = obj._Description, count = obj.Count, stCount = obj.ComponentFeaturesOption.Count, stTitle = obj.ComponentFeaturesOption.Title, stDescription = obj.ComponentFeaturesOption.Description };
            }
            else
            {
                return new JsonFileNotFound();
            } 
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string title, string styleTitle, string icon, int count, string styleCount, string description, string styleDescription)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var featuresOption = await _componentFeaturesOptionService.PutAsync(styleTitle, styleCount, styleDescription, userId);

            if (_id != Guid.Empty)
            {
                var features = await _componentFeaturesService.GetByIdAsync(_id, userId);
                features.Change(title, count, icon, description);

                if(featuresOption.Id == Guid.Empty)
                {
                    if(features.ComponentFeaturesOption.Default)
                    {
                        features.AddComponentFeaturesOption(featuresOption);
                    }
                    else
                    {
                        features.ComponentFeaturesOption.Change(false, styleTitle, styleCount, styleDescription);
                    }
                    _componentFeaturesService.Update(features);
                }
                else
                {
                    var optionOld = features.ComponentFeaturesOptionId;
                    bool optionDefault = features.ComponentFeaturesOption.Default;

                    features.ChangeComponentFeaturesOption(featuresOption.Id);
                    _componentFeaturesService.Update(features);

                    if (!optionDefault)
                    {
                        var obj = await _componentFeaturesOptionService.GetByIdAsync(optionOld);
                        _componentFeaturesOptionService.Remove(obj);
                    } 
                }
                json.Id = features.Id.ToString();
                return json;
            }
            else
            {
                if(featuresOption.Id == Guid.Empty)
                {
                    var features = new ComponentFeatures(userId, siteNumber, featuresOption, title, count, icon, description);
                    _componentFeaturesService.Add(features);
                    json.Id = features.Id.ToString();
                    return json;
                }
                else
                {
                    var features = new ComponentFeatures(userId, siteNumber, featuresOption.Id, title, count, icon, description);
                    _componentFeaturesService.Add(features);
                    json.Id = features.Id.ToString();
                    return json;
                }           
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var features = await _componentFeaturesService.GetByIdAsync(_id, userId);

            if (features != null)
            {
                var optionOld = features.ComponentFeaturesOptionId;
                bool optionDefault = features.ComponentFeaturesOption.Default;

                _componentFeaturesService.Remove(features);

                if (!optionDefault)
                {
                    var obj = await _componentFeaturesOptionService.GetByIdAsync(optionOld);
                    _componentFeaturesOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(features.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentFeaturesService.DeleteAll(userId);
        }
    }
}
