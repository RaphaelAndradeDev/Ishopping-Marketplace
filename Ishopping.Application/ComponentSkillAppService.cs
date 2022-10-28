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
    public class ComponentSkillAppService : AppServiceBaseT2<ComponentSkill>, IComponentSkillAppService
    {
        private readonly IComponentSkillService _componentSkillService;
        private readonly IComponentSkillOptionService _componentSkillOptionService;

        public ComponentSkillAppService(
            IComponentSkillService componentSkillService,
            IComponentSkillOptionService componentSkillOptionService)
            :base(componentSkillService)
        {
            _componentSkillService = componentSkillService;
            _componentSkillOptionService = componentSkillOptionService;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentSkillService.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentSkill> GetAllBySiteNumber(int siteNumber)
        {
            return _componentSkillService.GetAllBySiteNumber(siteNumber);
        }        

        public ComponentSkill GetBySiteNumber(int siteNumber)
        {
            return _componentSkillService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentSkill> GetAllByUserId(string userId)
        {
            return _componentSkillService.GetAllByUserId(userId);
        }

        public ComponentSkill GetById(Guid id, string userId)
        {
            return _componentSkillService.GetById(id, userId);
        }

        public ComponentSkill GetBy(string title, int position, string userId)
        {
            return _componentSkillService.GetBy(title, position, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentSkillService.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentSkill> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentSkillService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSkill>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentSkillService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSkill>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSkillService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSkill> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSkillService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSkill> GetByAsync(string search, int position, string userId)
        {
            return await _componentSkillService.GetByAsync(search, position, userId);
        }
      

        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentSkillOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, category = obj.Category, description = obj.Description, level = obj.Level };
            }
            else
            {
                return new JsonFileNotFound();
            } 
        }

        public async Task<object> GetObjetoAsync(string search, int position, string userId)
        {
            var obj = await _componentSkillService.GetByAsync(search, position, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, description = obj._Description, category = obj.Category, level = obj.Level, stCategory = obj.ComponentSkillOption.Category, stDescription = obj.ComponentSkillOption.Description, stLevel = obj.ComponentSkillOption.Level };
            }
            else
            {
                return new JsonFileNotFound();
            } 
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string category, string styleCategory, int level, string styleLevel, string description, string styleDescription)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var skillOption = await _componentSkillOptionService.PutAsync(styleCategory, styleLevel, styleDescription, userId);

            if (_id != Guid.Empty)
            {
                var skill = await _componentSkillService.GetByIdAsync(_id, userId);
                skill.Change(category, level, description, position);

                if(skillOption.Id == Guid.Empty)
                {
                    if(skill.ComponentSkillOption.Default)
                    {
                        skill.AddComponentSkillOption(skillOption);
                    }
                    else
                    {
                        skill.ComponentSkillOption.Change(false, styleCategory, styleDescription, styleLevel);
                    }
                    _componentSkillService.Update(skill);
                }
                else
                {
                    var optionOld = skill.ComponentSkillOptionId;
                    bool optionDefault = skill.ComponentSkillOption.Default;

                    skill.ChangeComponentSkillOption(skillOption.Id);
                    _componentSkillService.Update(skill);

                    if (!optionDefault)
                    {
                        var obj = await _componentSkillOptionService.GetByIdAsync(optionOld);
                        _componentSkillOptionService.Remove(obj);
                    }
                }
                json.Id = skill.Id.ToString();
                return json;
            }
            else
            {
                if(skillOption.Id == Guid.Empty)
                {
                    var skill = new ComponentSkill(userId, siteNumber, skillOption, category, level, description, position);
                    _componentSkillService.Add(skill);
                    json.Id = skill.Id.ToString();
                    return json;
                }
                else
                {
                    var skill = new ComponentSkill(userId, siteNumber, skillOption.Id, category, level, description, position);
                    _componentSkillService.Add(skill);
                    json.Id = skill.Id.ToString();
                    return json;
                }            
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var skill = await _componentSkillService.GetByIdAsync(_id, userId);

            if (skill != null)
            {
                var optionOld = skill.ComponentSkillOptionId;
                bool optionDefault = skill.ComponentSkillOption.Default;

                _componentSkillService.Remove(skill);

                if (!optionDefault)
                {
                    var obj = await _componentSkillOptionService.GetByIdAsync(optionOld);
                    _componentSkillOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(skill.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentSkillService.DeleteAll(userId);
        }
    }
}
