using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Twilio;

namespace Ishopping.MVC.Identity
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            if (ConfigurationManager.AppSettings["Internet"] == "true")
            {
                // Utilizando TWILIO como SMS Provider.
                // https://www.twilio.com/docs/quickstart/csharp/sms/sending-via-rest

                const string accountSid = "AC11629d31b4b01d848f534e8556584ca9";
                const string authToken = "2f04f5486c06c20ad5f7dfa4cdf9432f";

                var client = new TwilioRestClient(accountSid, authToken);

                client.SendMessage("1554140421604", message.Destination, message.Body);
            }

            return Task.FromResult(0);
        }
    }
}