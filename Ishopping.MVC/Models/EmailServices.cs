using Microsoft.AspNet.Identity;
using SendGrid;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Ishopping.Models
{
    public class EmailServices
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        public async Task SendAsync(string emailTo, string emailFrom, string subject, string message)
        {
            await configSendGridasync(emailTo, emailFrom, subject, message);
        }

        public async Task SendAsync(string emailTo, string emailFrom, string name, string subject, string message, string phone)
        {
            await configSendGridasync(emailTo, emailFrom, name, subject, message, phone);
        }              


        // Private Methods
        private async Task configSendGridasync(string mailTo, string email, string name, string subject, string message, string phone)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(mailTo);
            myMessage.From = new System.Net.Mail.MailAddress(email);
            myMessage.Subject = subject;
            myMessage.Text = GetFormattedMessageHTML(name, subject, email, message, phone);
            myMessage.Html = GetFormattedMessageHTML(name, subject, email, message, phone);

            var credentials = new NetworkCredential(
                       ConfigurationManager.AppSettings["mailAccount"],
                       ConfigurationManager.AppSettings["mailPassword"]
                       );

            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }

        private async Task configSendGridasync(string emailTo, string emailFrom, string subject, string message)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(emailTo);
            myMessage.From = new System.Net.Mail.MailAddress(emailFrom);
            myMessage.Subject = subject;
            myMessage.Text = GetFormattedMessageHTML(subject, message);
            myMessage.Html = GetFormattedMessageHTML(subject, message);

            var credentials = new NetworkCredential(
                       ConfigurationManager.AppSettings["mailAccount"],
                       ConfigurationManager.AppSettings["mailPassword"]
                       );

            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }

        private async Task configSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new System.Net.Mail.MailAddress("rio_edesign@hotmail.com", "IShoopping.com.br");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            var credentials = new NetworkCredential(
                       ConfigurationManager.AppSettings["mailAccount"],
                       ConfigurationManager.AppSettings["mailPassword"]
                       );

            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }

        private String GetFormattedMessageHTML(string name, string subject, string mail, string message, string phone)
        {
            return "<!DOCTYPE html>" +
                    "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                    "<head>" +
                    "<title>IShoopping</title>" +
                    "</head>" +
                    "<body style='font-family:Century Gothic'>" +
                    "<h2 style='font-family:georgia,serif;background-color:#0033ff;color:#FFFFFF;padding-left:20px;margin-right:0;padding-bottom:10px;padding-top:10px'>IShoopping</h2>" +
                    "<div style='padding-left:20px'>" +
                    "<h4><span style='font-family:verdana,geneva,sans-serif'><span style='color:#999966'><span style='font-size:16px'>Você tem uma nova mensagem</span></span></span></h4>" +
                    "<hr />" +
                    "<h4><span style='color:#808080'>Enviado por:</span> <span style='color:#333300'> "+ name +"</span></h4>" +
                    "<h4><span style='color:#808080'>E-mail:</span> <span style='color:#333300'> "+ mail +"</span></h4>" +
                    "<h4><span style='color:#808080'>Telefone:</span> <span style='color:#333300'> "+ phone +"</span></h4>" +
                    "<h4><span style='color:#808080'>Assunto:</span> <span style='color:#333300'> "+ subject +"</span></h4>" +
                    "<h4><span style='color:#808080'>Mensagem:</span> <span style='font-size:13px'><span style='font-family:tahoma,geneva,sans-serif'><span style='color:#000000;font-size:15px;font-weight:normal'> "+ message +"</span></span></span></h4>" +
                    "<hr />" +
                    "<p><span style='color:#0000CD'> "+ name +"</span><span style='color:#0000ff'> enviou uma nova mensagem para você</span></p>" +
                    "<p><span style='color:#0000ff'>Responda através do e-mail </span><span style='color:#0000CD'> "+ mail +" </span><span style='color:#0000ff'> ou pelo telefone </span><span style='color:#0000CD'> "+ phone +"</span></p>" +
                    "<p>&nbsp;</p>" +
                    "</div>" +
                    "</body>" +
                    "</html>";
        }

        private String GetFormattedMessageHTML(string subject, string message)
        {
            return "<!DOCTYPE html>" +
                    "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                    "<head>" +
                    "<title>IShoopping</title>" +
                    "</head>" +
                    "<body style='font-family:Century Gothic'>" +
                    "<h2 style='font-family:georgia,serif;background-color:#0033ff;color:#FFFFFF;padding-left:20px;margin-right:0;padding-bottom:10px;padding-top:10px'>IShoopping</h2>" +
                    "<div style='padding-left:20px'>" +
                    "<h4><span style='font-family:verdana,geneva,sans-serif'><span style='color:#999966'><span style='font-size:16px'>"+ subject +"</span></span></span></h4>" +
                    "<hr />" +
                    message +
                    "<p>&nbsp;</p>" +
                    "</div>" +
                    "</body>" +
                    "</html>";
        }
    }
}