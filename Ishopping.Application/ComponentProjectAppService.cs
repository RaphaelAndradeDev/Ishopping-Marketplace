using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;
using Ishopping.Application.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentProjectAppService : AppServiceBaseT2<ComponentProject>, IComponentProjectAppService
    {
        private readonly IComponentProjectService _componentProjectService;
        private readonly IComponentProjectOptionService _componentProjectOptionService;
        private readonly IUserImageGalleryService _userImageGalleryService;   

        public ComponentProjectAppService(
            IComponentProjectService componentProjectService,
            IComponentProjectOptionService componentProjectOptionService,
            IUserImageGalleryService userImageGalleryService)
            :base(componentProjectService)
        {
            _componentProjectService = componentProjectService;
            _componentProjectOptionService = componentProjectOptionService;
            _userImageGalleryService = userImageGalleryService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentProjectService.Search(startsWith, userId);
        }

        public ComponentProject GetByImageId(Guid imageId)
        {
            return _componentProjectService.GetByImageId(imageId);
        }

        public IEnumerable<ComponentProject> GetAllBySiteNumber(int siteNumber)
        {
            return _componentProjectService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentProject Get(string title, string userId)
        {
            return _componentProjectService.GetByTerm(title, userId);
        }
   
        public ComponentProject GetBySiteNumber(int siteNumber)
        {
            return _componentProjectService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentProject> GetAllByUserId(string userId)
        {
            return _componentProjectService.GetAllByUserId(userId);
        }

        public ComponentProject GetById(Guid id, string userId)
        {
            return _componentProjectService.GetById(id, userId);
        }

        public ComponentProject GetByTerm(string title, string userId)
        {
            return _componentProjectService.GetByTerm(title, userId);
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentProjectService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentProject> GetByImageIdAsync(Guid imageId)
        {
            return await _componentProjectService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentProject> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentProjectService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentProject>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentProjectService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentProject>> GetAllByUserIdAsync(string userId)
        {
            return await _componentProjectService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentProject> GetByIdAsync(Guid id, string userId)
        {
            return await _componentProjectService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentProject> GetByTermAsync(string term, string userId)
        {
            return await _componentProjectService.GetByTermAsync(term, userId);
        }  
        

        // Others Methods
        public void AddBy(ComponentProject componentProject)
        {
            _componentProjectService.AddBy(componentProject);
        }

        public void UpdateBy(ComponentProject componentProject)
        {
            _componentProjectService.UpdateBy(componentProject);
        }

        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentProjectOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, category = obj.Category, client = obj.Client, description = obj.Description, name = obj.Name, team = obj.Team, title = obj.Title };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string name, string styleName, string title, string styleTitle, string client, string styleClient, string description, string styleDescription, string category, string styleCategory, string team, string styleTeam, string webSite, string urlVideo, string date, string img1, string img2, string img3)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var listImg = new List<string>() { img1, img2, img3 };

            var listImageGallery = await _userImageGalleryService.GetAllisContainAsync(listImg, 8, userId);

            if (listImageGallery.Count() == 0)
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            var projectOption = await _componentProjectOptionService.PutAsync(styleName, styleTitle, styleClient, styleDescription, styleCategory, styleTeam, userId);

            if (_id != Guid.Empty)
            {
                var project = await _componentProjectService.GetByIdAsync(_id, userId);
                List<string> listImg2 = project.UserImageGallery.Select(x => x.FileName).ToList();
                json.Redirect = listImg.Except(listImg2).Any();
                project.Change(listImageGallery.ToList(), title, description, DateTime.Parse(date), name, client, category, webSite, team, urlVideo);

                if(projectOption.Id == Guid.Empty)
                {
                    if(project.ComponentProjectOption.Default)
                    {
                        project.AddComponentProjectOption(projectOption);
                    }
                    else
                    {
                        project.ComponentProjectOption.Change(false, styleName, styleTitle, styleClient, styleDescription, styleCategory, styleTeam);
                    }
                    _componentProjectService.Update(project);
                }
                else
                {
                    var optionOld = project.ComponentProjectOptionId;
                    bool optionDefault = project.ComponentProjectOption.Default;

                    project.ChangeComponentProjectOption(projectOption.Id);
                    _componentProjectService.Update(project);

                    if (!optionDefault)
                    {
                        var obj = await _componentProjectOptionService.GetByIdAsync(optionOld);
                        _componentProjectOptionService.Remove(obj);
                    }
                }               
                json.Id = project.Id.ToString();
                return json;
            }
            else
            {
                if(projectOption.Id == Guid.Empty)
                {
                    var project = new ComponentProject(userId, siteNumber, listImageGallery.ToList(), projectOption, title, description, DateTime.Parse(date), name, client, category, webSite, team, urlVideo);
                    _componentProjectService.Add(project);
                }
                else
                {
                    var project = new ComponentProject(userId, siteNumber, listImageGallery.ToList(), projectOption.Id, title, description, DateTime.Parse(date), name, client, category, webSite, team, urlVideo);
                    _componentProjectService.Add(project);
                }         
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var project = await _componentProjectService.GetByIdAsync(_id, userId);

            if (project != null)
            {
                var optionOld = project.ComponentProjectOptionId;
                bool optionDefault = project.ComponentProjectOption.Default;

                _componentProjectService.Remove(project);

                if (!optionDefault)
                {
                    var obj = await _componentProjectOptionService.GetByIdAsync(optionOld);
                    _componentProjectOptionService.Remove(obj);
                }
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(project.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentProjectService.DeleteAll(userId);
        }
    }
}
