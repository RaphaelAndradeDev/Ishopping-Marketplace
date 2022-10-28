using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.IO;

namespace Ishopping.Application
{
    public class AccountManagerAppService : IAccountManagerAppService
    {
        private readonly IAccountManagerService _accountManagerService;
        private readonly IConfigUserDisplayService _configUserDisplayService;
        private readonly IUserFinancialAppService _userFinancialAppService;
        private readonly IUserRegisterProfileService _userRegisterProfileService;

        public AccountManagerAppService(
            IAccountManagerService accountManagerService, 
            IConfigUserDisplayService configUserDisplayService,
            IUserFinancialAppService userFinancialAppService,
            IUserRegisterProfileService userRegisterProfileService)            
        {
            _accountManagerService = accountManagerService;
            _configUserDisplayService = configUserDisplayService;
            _userFinancialAppService = userFinancialAppService;
            _userRegisterProfileService = userRegisterProfileService;
        }

        public void AccountCreate(string userId, int group, int templateCod, int viewStart, int siteNumber, string siteName, string semantica1, string semantica2, string semantica3, string semantica4, 
            string empresa, string cnpj, string rua, string numero, string distrito, string cidade, string estado, string cep, string pais,
            string telefone, string telefone2, string whatsapp, string email, string webSite, bool googleMaps, double latitude, double longitude, string[] cssPath)
        {
            var userRegisterProfile = new UserRegisterProfile(userId, true, templateCod, viewStart, siteNumber, googleMaps, latitude, longitude, siteName, semantica1, rua, numero, distrito, cidade, estado, telefone,
                semantica2, semantica3, semantica4, empresa, cnpj, cep, "Brasil", telefone2, whatsapp, email, webSite);

            AddProfile(userRegisterProfile);
            AddProfileExtension(userRegisterProfile, null, cssPath);
            SetApplication(userRegisterProfile);
            AddDefaultPlan(userRegisterProfile, group);
            SaveProfile(userRegisterProfile);
        }

        public JsonResponse AccountUpdate(string userId, int group, int templateCod, int plan, int viewStart, string[] cssPath)
        {
            var json = new JsonResponse();

            string message = string.Empty;
            if (!AccountUpdateValidate(userId, group, plan, out message))
            {                                
                json.Message = message;
                return json;
            }

            DeleteProfileExtension(userId, templateCod);

            var userRegisterProfile = _userRegisterProfileService.GetByUserId(userId); 
            int oldTemplateCod = userRegisterProfile.TemplateCod;
            userRegisterProfile.ChangeLayout(templateCod, viewStart);
            AddProfileExtension(userRegisterProfile, oldTemplateCod, cssPath);
            SetApplication(userRegisterProfile);
            PlanProfileUpdate(userRegisterProfile, group, plan);
            SaveProfile(userRegisterProfile);

            json.Redirect = true;
            return json;
        }

        public JsonResponse AccountUpdate(string userId, string configUserViewId, int viewCod, bool ativo, string textMenu)
        {
            var json = new JsonResponse();   
            _accountManagerService.ProfileViewUpdate(userId, configUserViewId, viewCod, ativo, textMenu);
            return json;
        }

        public JsonResponse AccountUpdate(string userId, string configUserViewItemId, bool ativo, string textMenu, string textView)
        {
            var json = new JsonResponse();
            _accountManagerService.ProfileViewItemUpdate(userId, configUserViewItemId, ativo, textMenu, textView);
            return json;
        }


        // Private Methods
        private bool AccountUpdateValidate(string userId, int group, int plan, out string message)
        {
            // Retorna falso se houver alguma restrição para alteração do plano. 
            // Não é valida para alteração de templates do mesmo plano
            return _userFinancialAppService.PlanUpdateValidate(userId, group, plan, out message);
        }

        private void AddProfile(UserRegisterProfile userRegisterProfile)
        {
            _accountManagerService.AddProfile(userRegisterProfile);
        }

        private void AddProfileExtension(UserRegisterProfile userRegisterProfile, int? oldTemplateCod, string[] cssPath)
        {
            _accountManagerService.AddProfileExtension(userRegisterProfile, oldTemplateCod, cssPath);
        }   
        
        private void SetApplication(UserRegisterProfile userRegisterProfile)
        {
            _accountManagerService.SetApplication(userRegisterProfile);
        }

        private void AddDefaultPlan(UserRegisterProfile userRegisterProfile, int group)
        {
            _userFinancialAppService.AddFinancialToDefaultPlan(userRegisterProfile, group);            
        }

        private void PlanProfileUpdate(UserRegisterProfile userRegisterProfile, int group, int plan)
        {
            _userFinancialAppService.PlanUpdate(userRegisterProfile, group, plan);
            _configUserDisplayService.ConfigUserDisplayPlanUpdate(userRegisterProfile.IdUser, "Index", userRegisterProfile.Controller, userRegisterProfile.IsBlock(), userRegisterProfile.Plan, true);
        }

        private void DeleteProfileExtension(string userId, int newTemplateCod)
        {
            _accountManagerService.DeleteProfileExtension(userId, newTemplateCod);
        }

        private void SaveProfile(UserRegisterProfile userRegisterProfile)
        {
            _userRegisterProfileService.Update(userRegisterProfile);
            _userRegisterProfileService.Dispose();
        }
             
    }
}
