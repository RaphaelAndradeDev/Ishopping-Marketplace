using Ishopping.Application.Interface;
using Ishopping.Common.ConfigGlobal;
using Ishopping.Models;
using System;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.Controllers.Ishopping
{
    public class AppServicesController : Controller
    {
        
        private readonly IAdminFinancialPlanAppService _adminFinancialPlanAppService;
        private readonly IConfigUserMaintenanceAppService _configUserMaintenanceAppService;
        private readonly IUserFinancialAppService _userFinancialAppService;
        private readonly IUserRegisterProfileAppService _userRegisterProfileAppService;
                        
        public AppServicesController(
            IAdminFinancialPlanAppService adminFinancialPlanAppService,
            IConfigUserMaintenanceAppService configUserMaintenanceAppService,
            IUserFinancialAppService userFinancialAppService,
            IUserRegisterProfileAppService userRegisterProfileAppService)
        {
            _adminFinancialPlanAppService = adminFinancialPlanAppService;
            _configUserMaintenanceAppService = configUserMaintenanceAppService;
            _userFinancialAppService = userFinancialAppService;
            _userRegisterProfileAppService = userRegisterProfileAppService;
        }

        [HttpPost]
        public async Task<JsonResult> Email(int siteNumber, string mailFrom, string mailIdentity, string mailSubject, string message)
        {
            try
            {
                string mailTo = await CheckEmailQuantity(siteNumber);

                if(string.IsNullOrEmpty(mailTo))
                    return Json("Limite excedido, mensagem não enviada");

                var emailService = new EmailServices();
                await emailService.SendAsync(mailTo, mailFrom, mailIdentity, mailSubject, message, null);
                return Json("Sua mensagem foi enviada");
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "AppServicesController", "Email");
                return Json("A mensagem não pode ser enviada");
            }        
        }

        [HttpPost]
        public async Task<JsonResult> EmailS(int siteNumber, string email, string name, string subject, string message)
        {
            try
            {
                string mailTo = await CheckEmailQuantity(siteNumber);

                if (string.IsNullOrEmpty(mailTo))
                    return Json("Limite excedido, mensagem não enviada");

                var emailService = new EmailServices();
                await emailService.SendAsync(mailTo, email, name, subject, message, null);
                return Json("Sua mensagem foi enviada");
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "AppServicesController", "EmailS");
                return Json("A mensagem não pode ser enviada");
            }
        }

        [HttpPost]
        public async Task<JsonResult> EmailC(int siteNumber, string email, string name, string subject, string message, string phone)
        {
            try
            {
                string mailTo = await CheckEmailQuantity(siteNumber);

                if (string.IsNullOrEmpty(mailTo))
                    return Json("Limite excedido, mensagem não enviada");

                var emailService = new EmailServices();
                await emailService.SendAsync(mailTo, email, name, subject, message, phone);
                return Json("Sua mensagem foi enviada");
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "AppServicesController", "EmailC");
                return Json("A mensagem não pode ser enviada");
            }
        }

        public async Task<JsonResult> BlockProfiles(string token)
        {
            string subject = "Seu profile está inativo";
            string message = "<h4>Prezado cliente</h4>" +
                    "<p>O seu profile foi desativado temporariamente porquê a sua data de vencimento expirou." +
                    "<br>Você ainda pode entrar no seu perfil normalmente, mas a sua página não aparecera na página principal do IShoopping e nem para os seus clientes</p>" +
                    "<p>Para normalizar o seu perfil por favor vá até Planos e Pagamentos e clique em Efetuar Pagamento</p>";

            try
            {
                string suportEmail = ConfigurationManager.AppSettings["supportEmail"];
                string isToken = ConfigurationManager.AppSettings["isToken"];

                if(token != isToken)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json("Token inválido", JsonRequestBehavior.AllowGet);
                }                    

                int msgCount = 0;
                var emails = await _userFinancialAppService.BlockProfile();
                foreach (var emailTo in emails)
                {
                    var emailService = new EmailServices();
                    await emailService.SendAsync(emailTo, suportEmail, subject, message);
                    msgCount++;
                }
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json( msgCount + " mensagens enviadas", JsonRequestBehavior.AllowGet); 
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "AppServicesController", "BlockProfiles");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Erro na tentativa de enviar mensagens", JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult EventSchedule(string token)
        {
            try
            {
                string isToken = ConfigurationManager.AppSettings["isToken"];
                if (token != isToken)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json("Token inválido", JsonRequestBehavior.AllowGet);
                }

                RemoveMaintenance();
                EmailQuantityClear();

                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("2 eventos de cronograma executados", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "AppServicesController", "EventSchedule");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Erro na tentativa de executar eventos de cronograma", JsonRequestBehavior.AllowGet);
            }
        }


        // Private Methods      
        private void RemoveMaintenance()
        {                             
            _configUserMaintenanceAppService.RemoveMaintenance();              
        }

        private void EmailQuantityClear()
        {           
            DateTime dateNow = Timezone.DateTimeNow();
            if(dateNow.Hour == 0)
                _userRegisterProfileAppService.EmailQuantityClear();
        }

        private async Task<string> CheckEmailQuantity(int siteNumber)
        {
            string email = string.Empty;
            var profile = await _userRegisterProfileAppService.GetProfileServicesAsync(siteNumber);
            var adminPlan = await _adminFinancialPlanAppService.GetByCodAsync(profile.Plan);
            profile.SiteNumber = siteNumber;
                       
            int quantity = profile.HasRestrictionOnService() ? 3 : adminPlan.Email;
            if (profile.EmailQuantity <= quantity)
            {
                email = profile.Email;
                profile.EmailQuantity++;
                _userRegisterProfileAppService.SetProfileServices(profile);
            }                                          
            return email;
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}