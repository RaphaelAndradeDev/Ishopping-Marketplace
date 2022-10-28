using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentTeamSocialNetworkAppService : AppServiceBaseT2<ComponentTeamSocialNetwork>, IComponentTeamSocialNetworkAppService
    {
        private readonly IAdminSocialNetWorkService _adminSocialNetWorkService;
        private readonly IComponentTeamService _componentTeamService;
        private readonly IComponentTeamSocialNetworkService _componentTeamSocialNetworkService;
        private readonly IUserRegisterProfileService _userRegisterProfile;

        public ComponentTeamSocialNetworkAppService(
            IAdminSocialNetWorkService adminSocialNetWorkService,
            IComponentTeamService componentTeamService,
            IComponentTeamSocialNetworkService componentTeamSocialNetworkService,
            IUserRegisterProfileService userRegisterProfile)
            :base(componentTeamSocialNetworkService)
        {
            _adminSocialNetWorkService = adminSocialNetWorkService;
            _componentTeamService = componentTeamService;
            _componentTeamSocialNetworkService = componentTeamSocialNetworkService;
            _userRegisterProfile = userRegisterProfile;
        }
               

        public IEnumerable<string> GetAdminSocialNetworks(string userId)
        {
            var profile = _userRegisterProfile.GetByUserId(userId);
            return _adminSocialNetWorkService.GetAllRedeByTemplateCod(profile.TemplateCod);
        }

        public AdminSocialNetWork GetAdminSocialNetworks(string rede, int templateCod)
        {
            return _adminSocialNetWorkService.GetBy(rede, templateCod);
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string idSn, string userId, string link, string rede)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            Guid _idSn = new Guid();
            Guid.TryParse(idSn, out _idSn);

            JsonResponse json = new JsonResponse();

            if (_id == Guid.Empty)
            {
                json.Message = "Erro na tentativa de salvar dados";             
                return json;
            }

            var profile = _userRegisterProfile.GetByUserId(userId);
            var adminsocialNetWork = _adminSocialNetWorkService.GetBy(rede, profile.TemplateCod);

            if (adminsocialNetWork == null)
            {
                json.Message = "Rede Social incompatível com o template";
                json.Serialize = false;
                return json;
            }
                        
            var componentTeam = await _componentTeamService.GetByIdAsync(_id, userId);

            if(componentTeam == null)
            {
                json.Message = "Erro na tentativa de salvar dados";
                return json;
            }

            if (_idSn != Guid.Empty)
            {
                var sn = await _componentTeamSocialNetworkService.GetByIdAsync(_idSn, userId);
                sn.Change(link, rede);
                _componentTeamSocialNetworkService.Update(sn);

                json.Term = componentTeam.Search;
                json.Redirect = true;
                return json;
            }
            else
            {
                var sn = new ComponentTeamSocialNetwork(componentTeam.Id, link, rede);
                _componentTeamSocialNetworkService.Add(sn);

                json.Term = componentTeam.Search;
                json.Redirect = true;
                return json;
            }
       
        }

        public void DeleteAll(Guid componentTeamId)
        {
            _componentTeamSocialNetworkService.DeleteAll(componentTeamId);
        }
    }
}
