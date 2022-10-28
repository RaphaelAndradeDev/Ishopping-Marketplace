using System;
using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.User
{
    public class UserFinancialViewModel
    {
        public Guid Id { get; set; }
        public int SiteNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AreaCod { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public int CurrentPlan { get; set; }
        public string PaymentDisable { get { return ButtonPaymentDisable(CurrentPlan); } }

        // Relacionamento
        public virtual ICollection<UserFinancialHistoryViewModel> UserFinancialHistory { get; set; }

        private string ButtonPaymentDisable(int currentPlan)
        {
            return currentPlan == 0 ? "disabled" : "";
        }
    }
}
