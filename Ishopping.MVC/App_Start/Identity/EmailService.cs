using Microsoft.AspNet.Identity;
using SendGrid;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Ishopping.MVC.Identity
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return ConfigSendGridasync(message);
            //return SendMail(message);
        }

        // Implementação do SendGrid
        private Task ConfigSendGridasync(IdentityMessage message)
        {
            string suportEmail = ConfigurationManager.AppSettings["supportEmail"];

            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new MailAddress(suportEmail, "IShoopping");
            myMessage.Subject = message.Subject;
            myMessage.Text = "IShoopping";
            myMessage.Html = message.Body; 


            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["mailAccount"], ConfigurationManager.AppSettings["mailPassword"]);

            // Criar um transport web para envio de e-mail
            var transportWeb = new Web(credentials);

            // Enviar o e-mail
            if (transportWeb != null)
            {
                var x = transportWeb.DeliverAsync(myMessage);
                return x;
            }
            else
            {
                return Task.FromResult(0);
            }
        }

        // Implementação de e-mail manual
        private Task SendMail(IdentityMessage message)
        {
            if (ConfigurationManager.AppSettings["Internet"] == "true")
            {             
                var msg = new MailMessage();
                msg.From = new MailAddress("rio_edesign@hotmail.com", "IShoopping");
                msg.To.Add(new MailAddress(message.Destination));
                msg.Subject = message.Subject;            
                msg.IsBodyHtml = true;
                msg.Body = message.Body;

                var smtpClient = new SmtpClient("smtp.live.com", Convert.ToInt32(25));
                var credentials = new NetworkCredential(ConfigurationManager.AppSettings["ContaDeEmail"],
                    ConfigurationManager.AppSettings["SenhaEmail"]);
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
            }

            return Task.FromResult(0);
        }        
    }        
}