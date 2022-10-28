using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentSocialNetworkAppService : AppServiceBaseT2<ComponentSocialNetwork>, IComponentSocialNetworkAppService
    {
        private readonly IComponentSocialNetworkService _componentSocialNetworkService;
        private readonly IUserRegisterProfileAppService _userRegisterProfileAppService;
        private readonly IAdminSocialNetWorkService _adminSocialNetWorkService;

        public ComponentSocialNetworkAppService(
            IComponentSocialNetworkService componentSocialNetworkService,
            IUserRegisterProfileAppService userRegisterProfileAppService,
            IAdminSocialNetWorkService adminSocialNetWorkService)
            :base(componentSocialNetworkService)
        {
            _componentSocialNetworkService = componentSocialNetworkService;
            _userRegisterProfileAppService = userRegisterProfileAppService;
            _adminSocialNetWorkService = adminSocialNetWorkService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentSocialNetworkService.Search(startsWith, userId);
        }

        public IEnumerable<ComponentSocialNetwork> GetAllBySiteNumber(int siteNumber)
        {
            return _componentSocialNetworkService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentSocialNetwork GetBySiteNumber(int siteNumber)
        {
            return _componentSocialNetworkService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentSocialNetwork> GetAllByUserId(string userId)
        {
            return _componentSocialNetworkService.GetAllByUserId(userId);
        }

        public ComponentSocialNetwork GetById(Guid id, string userId)
        {
            return _componentSocialNetworkService.GetById(id, userId);
        }

        public ComponentSocialNetwork GetByTerm(string title, string userId)
        {
            return _componentSocialNetworkService.GetByTerm(title, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentSocialNetworkService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentSocialNetwork> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentSocialNetworkService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSocialNetwork>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentSocialNetworkService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentSocialNetwork>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSocialNetworkService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSocialNetwork> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSocialNetworkService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSocialNetwork> GetByTermAsync(string term, string userId)
        {
            return await _componentSocialNetworkService.GetByTermAsync(term, userId);
        } 


        // Others Methods
        public IEnumerable<string> GetAdminSocialNetworks(string userId)
        {
            var profile = _userRegisterProfileAppService.GetByUserId(userId);
            return _adminSocialNetWorkService.GetAllRedeByTemplateCod(profile.TemplateCod);
        }

        public AdminSocialNetWork GetAdminSocialNetworks(string rede, int templateCod)
        {
            return _adminSocialNetWorkService.GetBy(rede, templateCod);
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, string rede, string link)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var profile = _userRegisterProfileAppService.GetByUserId(userId);     
            var sn = _adminSocialNetWorkService.GetBy(rede, profile.TemplateCod);

            if(sn == null)
            {
                json.Message = "Rede Social incompatível com o template";
                json.Serialize = false;
                return json;
            }

            if (_id != Guid.Empty)
            {
                var socialNetwork = await _componentSocialNetworkService.GetByIdAsync(_id, userId);
                socialNetwork.Change(rede, link);
                _componentSocialNetworkService.Update(socialNetwork);
                json.Id = socialNetwork.Id.ToString();             
                return json;
            }
            else
            {
                var socialNetwork = new ComponentSocialNetwork(userId, profile.SiteNumber, rede, link);
                _componentSocialNetworkService.Add(socialNetwork);
                json.Id = socialNetwork.Id.ToString();
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var socialNetwork = await _componentSocialNetworkService.GetByIdAsync(_id, userId);

            if (socialNetwork != null)
            {
                _componentSocialNetworkService.Remove(socialNetwork);
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(socialNetwork.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentSocialNetworkService.DeleteAll(userId);
        }       
      
    }
}
