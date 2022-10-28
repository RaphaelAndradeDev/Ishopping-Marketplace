using Ishopping.Domain.Entities;
using System;
using System.Configuration;
using System.Linq;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Resources;

namespace Ishopping.Application.AppService
{
    public class AdminPagSeguro
    {
        private UserRegisterProfile _profile;
        private UserFinancial _financial;
        private string _transactionId;

        public AdminPagSeguro(UserRegisterProfile profile, UserFinancial financial, string transactionId)
        {
            this._profile = profile;
            this._financial = financial;
            this._transactionId = transactionId;
        }

        public string NewPayment()
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

            string siteCurrent = isSandbox ? "localhost:1548/profiles" : ConfigurationManager.AppSettings["IshoppingDomain"] + "/profiles";

            var plan = _financial.UserFinancialHistory.OrderBy(x => x.Date).Last();
            PaymentRequest payment = new PaymentRequest();
            payment.Items.Add(new Item(plan.Id.ToString(), plan.AdminFinancialPlan.Name, 1, plan.Payment));

            // Moeda
            payment.Currency = Currency.Brl;

            //Dados de quem ira pagar, normalmente o proprio usuario 
            payment.Reference = _transactionId;
            Sender sender = new Sender(_financial.Name, _financial.Email, new Phone(_financial.AreaCod, _financial.Phone));
            SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CPF"), _financial.Cpf);
            sender.Documents.Add(senderCPF);

            // Frete e Endereço
            payment.Shipping = new Shipping();
            payment.Shipping.ShippingType = ShippingType.NotSpecified;
            payment.Shipping.Cost = 0.00m;

            payment.Shipping.Address = new Address(
                _profile.Pais,
                _profile.Estado,
                _profile.Cidade,
                _profile.Distrito,
                _profile.CEP,
                _profile.Rua,
                _profile.NumRua,
                "Sem complemento"
            );


            // Redirecionamento do link após efetuado o pagamento          
            payment.RedirectUri = new Uri(siteCurrent);

            // Credenciais do Ishoopping
            AccountCredentials credential = new AccountCredentials(credentialEmail, credentialToken);

            // uri de retorno para redirecionar o cliente ao site do pagseguro
            return payment.Register(credential).ToString();        
        }
    }
}
