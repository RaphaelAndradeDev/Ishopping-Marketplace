using Ishopping.Application.Interface;
using Ishopping.Common.Constants;
using Ishopping.Models;
using System;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;
using Uol.PagSeguro.Service;

namespace Ishopping.Controllers.Ishopping
{
    public class TransactionsController : Controller
    {
        private readonly IUserFinancialAppService _userFinancialAppService;

        public TransactionsController(IUserFinancialAppService userFinancialAppService)
        {
            _userFinancialAppService = userFinancialAppService;
        }                         

        [HttpPost]
        public async Task<JsonResult> PagSeguroNotification(string notificationCode, string notificationType)
        {
            try
            {
                bool isSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandBox"]);
                EnvironmentConfiguration.ChangeEnvironment(isSandbox);

                string credentialEmail = null;
                string credentialToken = null;

                if (isSandbox)
                {
                    credentialEmail = ConfigurationManager.AppSettings["PagSegSandboxEmail"];
                    credentialToken = ConfigurationManager.AppSettings["PagSegSandboxToken"];                
                }
                else
                {
                    credentialEmail = ConfigurationManager.AppSettings["PagSegAdminEmail"];
                    credentialToken = ConfigurationManager.AppSettings["PagSegAdminToken"];
                }
                         
                AccountCredentials credentials = new AccountCredentials(credentialEmail, credentialToken);
                Transaction transaction = NotificationService.CheckTransaction(credentials, notificationCode);
                string emailTo = await _userFinancialAppService.SetStatusFromNotification(transaction.Reference, transaction.TransactionStatus);

                string subject = "Status da Transação";
                string message = "<h4>O PagSeguro respondeu com o seguinte status:</h4>" +
                        "<p>Código do Status: "+ transaction.TransactionStatus + "</p>" +
                        "<p>" + ConstantFinancial.GetStatus(transaction.TransactionStatus) + "</p>" +
                        "<p>" + ConstantFinancial.GetStatusDetails(transaction.TransactionStatus) + "</p>" +
                        "<p>Para maiores detalhes visite o site da <a target='_blank' href='https://pagseguro.uol.com.br'>UolPagSeguro</a></p>";

                string suportEmail = ConfigurationManager.AppSettings["supportEmail"];                                 
                                  
                var emailService = new EmailServices();
                await emailService.SendAsync(emailTo, suportEmail, subject, message);

                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("mensagens enviadas", JsonRequestBehavior.DenyGet);
            }
            catch (PagSeguroServiceException ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "TransactionsController", "UolNotification");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Erro na tentativa de enviar mensagens", JsonRequestBehavior.DenyGet);
            }
        }


        // Private Methods
        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }
    }
}