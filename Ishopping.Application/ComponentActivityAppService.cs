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
    public class ComponentActivityAppService : AppServiceBaseT2<ComponentActivity>, IComponentActivityAppService
    {
        private readonly IComponentActivityService _componentActivityService;
        private readonly IComponentActivityOptionService _componentActivityOptionService;

        public ComponentActivityAppService(
            IComponentActivityService componentActivityService,
            IComponentActivityOptionService componentActivityOptionService)
            :base(componentActivityService)
        {
            _componentActivityService = componentActivityService;
            _componentActivityOptionService = componentActivityOptionService;
        }            

        // Sync Methods
        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentActivityService.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentActivity> GetAllBySiteNumber(int siteNumber)
        {
            return _componentActivityService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentActivity GetBySiteNumber(int siteNumber)
        {
            return _componentActivityService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentActivity> GetAllByUserId(string userId)
        {
            return _componentActivityService.GetAllByUserId(userId);
        }

        public ComponentActivity GetById(Guid id, string userId)
        {
            return _componentActivityService.GetById(id, userId);
        }

        public ComponentActivity GetBy(string title, int position, string userId)
        {
            return _componentActivityService.GetBy(title, position, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentActivityService.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentActivity> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentActivityService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentActivity>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentActivityService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentActivity>> GetAllByUserIdAsync(string userId)
        {
            return await _componentActivityService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentActivity> GetByIdAsync(Guid id, string userId)
        {
            return await _componentActivityService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentActivity> GetByAsync(string search, int position, string userId)
        {
            return await _componentActivityService.GetByAsync(search, position, userId);
        }
        
        // Other Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentActivityOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true,  title = obj.Title, description = obj.Description };
            }
            else
            {
                return new JsonFileNotFound();
            } 
        }

        public async Task<object> GetObjetoAsync(string search, int position, string userId)
        {
            var obj = await _componentActivityService.GetByAsync(search, position, userId);
            if(obj != null)
            {
                return new {FileFound = true, id = obj.Id, title = obj._Title, description = obj._Description, icon = obj.VectorIcon, stTitle = obj.ComponentActivityOption.Title, stDescription = obj.ComponentActivityOption.Description };
            }
            else
            {
                return new JsonFileNotFound();
            }            
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string description, string styleDescription, string icon)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var activityOption = await _componentActivityOptionService.PutAsync(userId, styleTitle, styleDescription);

            if (_id != Guid.Empty)
            {
                var activity = await _componentActivityService.GetByIdAsync(_id, userId);
                activity.Change(title, icon, description, position);

                if(activityOption.Id == Guid.Empty)
                {
                    if(activity.ComponentActivityOption.Default)
                    {
                        activity.AddComponentActivityOption(activityOption);
                    }
                    else
                    {
                        activity.ComponentActivityOption.Change(false, styleTitle, styleDescription);
                    }
                    _componentActivityService.Update(activity);
                }
                else
                {
                    var optionOld = activity.ComponentActivityOptionId;
                    bool optionDefault = activity.ComponentActivityOption.Default;

                    activity.ChangeComponentActivityOption(activityOption.Id);
                    _componentActivityService.Update(activity);

                    if (!optionDefault)
                    {
                        var obj = _componentActivityOptionService.GetById(optionOld);
                        _componentActivityOptionService.Remove(obj);
                    }                  
                }              
                json.Id = activity.Id.ToString();
                return json;
            }
            else
            {
                if (activityOption.Id == Guid.Empty)
                {
                    var activity = new ComponentActivity(userId, siteNumber, activityOption, title, icon, description, position);
                    _componentActivityService.Add(activity);
                    json.Id = activity.Id.ToString();
                    return json;
                }
                else
                {
                    var activity = new ComponentActivity(userId, siteNumber, activityOption.Id, title, icon, description, position);
                    _componentActivityService.Add(activity);
                    json.Id = activity.Id.ToString();
                    return json;
                }                                                      
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var activity = await _componentActivityService.GetByIdAsync(_id, userId);

            if (activity != null)
            {
                var optionOld = activity.ComponentActivityOptionId;
                bool optionDefault = activity.ComponentActivityOption.Default;

                _componentActivityService.Remove(activity);

                if (!optionDefault)
                {
                    var obj = await _componentActivityOptionService.GetByIdAsync(optionOld);
                    _componentActivityOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(activity.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentActivityService.DeleteAll(userId);
        }



    }
}
