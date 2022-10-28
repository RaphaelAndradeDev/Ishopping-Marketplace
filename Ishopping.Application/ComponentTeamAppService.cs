using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;
using Ishopping.Application.Common;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentTeamAppService : AppServiceBaseT2<ComponentTeam>, IComponentTeamAppService
    {
        private readonly IComponentTeamService _componentTeamService;
        private readonly IComponentTeamOptionService _componentTeamOptionService;
        private readonly IComponentTeamSocialNetworkService _componentTeamSocialNetwork;
        private readonly IUserImageGalleryService _userImageGalleryService; 

        public ComponentTeamAppService(
            IComponentTeamService componentTeamService,
            IComponentTeamOptionService componentTeamOptionService,
            IComponentTeamSocialNetworkService componentTeamSocialNetwork,
            IUserImageGalleryService userImageGalleryService)
            :base(componentTeamService)
        {
            _componentTeamService = componentTeamService;
            _componentTeamOptionService = componentTeamOptionService;
            _componentTeamSocialNetwork = componentTeamSocialNetwork;
            _userImageGalleryService = userImageGalleryService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentTeamService.Search(startsWith, userId);
        }

        public ComponentTeam GetByImageId(Guid imageId)
        {
            return _componentTeamService.GetByImageId(imageId);
        }

        public IEnumerable<ComponentTeam> GetAllBySiteNumber(int siteNumber)
        {
            return _componentTeamService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentTeam Get(string title, string userId)
        {
            return _componentTeamService.GetByTerm(title, userId);
        }
   
        public ComponentTeam GetBySiteNumber(int siteNumber)
        {
            return _componentTeamService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentTeam> GetAllByUserId(string userId)
        {
            return _componentTeamService.GetAllByUserId(userId);
        }

        public AdminSocialNetWork GetAdminSocialNetworks(string rede, int templateCod)
        {
            return _componentTeamSocialNetwork.GetAdminSocialNetworks(rede, templateCod);
        }

        public ComponentTeam GetById(Guid id, string userId)
        {
            return _componentTeamService.GetById(id, userId);
        }

        public ComponentTeam GetByTerm(string term, string userId)
        {
            return _componentTeamService.GetByTerm(term, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentTeamService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentTeam> GetByImageIdAsync(Guid imageId)
        {
            return await _componentTeamService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentTeam> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentTeamService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentTeam>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentTeamService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentTeam>> GetAllByUserIdAsync(string userId)
        {
            return await _componentTeamService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentTeam> GetByIdAsync(Guid id, string userId)
        {
            return await _componentTeamService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentTeam> GetByTermAsync(string term, string userId)
        {
            return await _componentTeamService.GetByTermAsync(term, userId);
        }  
           
   
        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentTeamOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, description = obj.Description, functio = obj.Functio, name = obj.Name };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string name, string styleName, string functio, string styleFunctio, string description, string styleDescription, string imageFileName)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var imageGallery = await _userImageGalleryService.GetByAsync(5, imageFileName, userId);
            if (imageGallery == null)
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            var teamSocialNetwork = new List<ComponentTeamSocialNetwork>();

            var teamOption = await _componentTeamOptionService.PutAsync(styleName, styleFunctio, styleDescription, userId);

            if (_id != Guid.Empty)
            {
                var team = await _componentTeamService.GetByIdAsync(_id, userId);
                json.Redirect = team.UserImageGallery.FileName != imageGallery.FileName;
                team.Change(imageGallery.Id, name, functio, description);

                if(teamOption.Id == Guid.Empty)
                {
                    if(team.ComponentTeamOption.Default)
                    {
                        team.AddComponentTeamOption(teamOption);
                    }
                    else
                    {
                        team.ComponentTeamOption.Change(false, styleName, styleFunctio, styleDescription);
                    }
                    _componentTeamService.Update(team);
                }
                else
                {
                    var optionOld = team.ComponentTeamOptionId;
                    bool optionDefault = team.ComponentTeamOption.Default;

                    team.ChangeComponentTeamOption(teamOption.Id);
                    _componentTeamService.Update(team);

                    if (!optionDefault)
                    {
                        var obj = await _componentTeamOptionService.GetByIdAsync(optionOld);
                        _componentTeamOptionService.Remove(obj);
                    }
                }                
                json.Id = team.Id.ToString();
                return json;
            }
            else
            {
                if(teamOption.Id == Guid.Empty)
                {
                    var team = new ComponentTeam(userId, siteNumber, imageGallery.Id, teamOption, name, functio, description);
                    _componentTeamService.Add(team);
                }
                else
                {
                    var team = new ComponentTeam(userId, siteNumber, imageGallery.Id, teamOption.Id, name, functio, description);
                    _componentTeamService.Add(team);
                }            
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var team = await _componentTeamService.GetByIdAsync(_id, userId);

            if (team != null)
            {
                var optionOld = team.ComponentTeamOptionId;
                bool optionDefault = team.ComponentTeamOption.Default;

                _componentTeamService.Remove(team);

                if (!optionDefault)
                {
                    var obj = await _componentTeamOptionService.GetByIdAsync(optionOld);
                    _componentTeamOptionService.Remove(obj);
                }
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(team.Id.ToString());
            }
        }

        public async Task<JsonDelete> AppDeleteSnAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var teamSn = await _componentTeamSocialNetwork.GetByIdAsync(_id, userId);

            if (teamSn != null)
            {              
                string name = teamSn.ComponentTeam.Search;
                _componentTeamSocialNetwork.Remove(teamSn);
                
                return new JsonDelete(true, term:name);
            }
            else
            {
                return new JsonDelete(teamSn.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentTeamService.DeleteAll(userId);
        }
    }
}
