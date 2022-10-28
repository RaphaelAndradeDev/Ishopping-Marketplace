using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ishopping.App_Start.Identity
{
    public class EmailGenerator
    {
        public string Subject { get; private set; }
        public String Body { get; private set; }

        public EmailGenerator(string generateFor, string callbackUrl)
        {
            switch (generateFor)
            {
                case "confirmEmail":
                    GetEmailBodyConfirmEmail(callbackUrl);
                    break;
                case "forgotPassword":
                    GetEmailBodyForgotPassword(callbackUrl);
                    break;
                default:
                    throw new Exception();
            }
        }

        private void GetEmailBodyConfirmEmail(string callbackUrl)
        {
            this.Subject = "Confirmação de E-mail";
            string messageBody = "Para confirmar o seu e-mail por favor clique no link abaixo";
            string messageFooter = "Por favor confirme seu email clicando no link acima para concluir o seu cadastro no IShoopping";
            this.Body = GetFormattedMessageHTML(callbackUrl, messageBody, messageFooter);
        }

        private void GetEmailBodyForgotPassword(string callbackUrl)
        {
            this.Subject = "Redefinição de Senha";
            string messageBody = "Para redefinir a sua senha por favor clique no link abaixo";
            string messageFooter = "Por favor clique no link acima para redefinir a sua senha";
            this.Body = GetFormattedMessageHTML(callbackUrl, messageBody, messageFooter);
        }

        private String GetFormattedMessageHTML(string callbackUrl, string messageBody, string messageFooter)
        {
            return "<!DOCTYPE html>" +
                    "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                    "<head>" +
                    "<title>IShoopping</title>" +
                    "</head>" +
                    "<body style='font-family:Century Gothic'>" +
                    "<h2 style='font-family:georgia,serif;background-color:#0033ff;color:#FFFFFF;padding-left:20px;margin-right:0;padding-bottom:10px;padding-top:10px'>IShoopping</h2>" +
                    "<div style='padding-left:20px'>" +
                    "<h4><span style='font-family:verdana,geneva,sans-serif'><span style='color:#999966'><span style='font-size:16px'>" + Subject + "</span></span></span></h4>" +
                    "<hr />" +
                    "<p style='color:#000'>" + messageBody + "</p>" +
                    "<h4><span style='color:#808080'><a href=" + callbackUrl + ">Clique aqui!</a></h4>" +
                    "<hr />" +
                    "<p style='color:#0000ff'>" + messageFooter + "</p>" +
                    "<p>&nbsp;</p>" +
                    "</div>" +
                    "</body>" +
                    "</html>";
        }
    }
}