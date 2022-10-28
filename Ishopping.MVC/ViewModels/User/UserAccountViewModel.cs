using Ishopping.Domain.ApplicationClass;
using System;

namespace Ishopping.ViewModels.User
{
    public class UserAccountViewModel
    {
        // Block    
        public bool HasInsufficientValue { get; set; }
        public bool HasRestriction { get; set; }
        public bool IsTimeOver { get; set; }

        // Maintenance
        public bool IsMaintenance { get; set; }

        // ******** Identity     
        public int SiteNumber { get; set; }                     // identificação única
        public string SiteName { get; set; }

        // Config
        public string Controller { get; set; }                  // Controler das views 


        // ******* Layout
        public int Group { get; set; }
        public int TemplateCod { get; set; }
        public int ViewStart { get; set; }                   // ViewCod, página inicial do usuário, somente tipo home

        // ****** Serialize
        public bool Serialize { get; set; }


        // ******* Application Menu
        public string AppMenu { get; set; }                  // Usado para configurar o menu da aplicação 


        // ********  Data
        public string Empresa { get; set; }


        // Group
        public GroupPlan GroupPlan { get; set; }

        // DueDate
        public DateTime? DueDate { get; set; }

        // ***** Services Quantity      
        public int EmailQuantity { get; set; }


        // Messages
        public string MsgLatePayment { get { return "Pendente de pagamento"; } }
        public string MsgInsufficientValue { get { return "O saldo disponivel é insuficiente"; } }
        public string MsgRestriction { get { return "Existem restrições de uso em sua conta"; } }
        public string MsgTimeOver { get { return "O período de testes expirou"; } }
        public string MsgIsMaintenance { get { return "Modo de manutenção ativado"; } }
        public string MsgDueDate { get { return GetDaysForDueDate(DueDate); } }
        public string MsgEmail { get { return GetMsgForEmail(EmailQuantity); } }          


        // Private Methods
        private string GetDaysForDueDate(DateTime? dueDate)
        {
            if(dueDate.HasValue)
            {
                int days = dueDate.Value.Subtract(DateTime.Now).Days;
                string day = days > 1 ? "dias" : "dia";
                return !IsLock() && days <= 15 ? "Restam " + days + " " + day + " para próxima data de vencimento." : null;
            }
            return null;
        }

        private string GetMsgForEmail(int emailQuantity)
        {
            if (emailQuantity > 0)
            {
                string msg = emailQuantity > 1 ? "mensagens" : "mensagem";
                return  "Você recebeu " + emailQuantity + " " + msg + " de e-mail hoje";
            }
            return ""; 
        }

        private bool IsLock()
        {
            return HasInsufficientValue || HasRestriction || IsTimeOver;
        }
    }
}