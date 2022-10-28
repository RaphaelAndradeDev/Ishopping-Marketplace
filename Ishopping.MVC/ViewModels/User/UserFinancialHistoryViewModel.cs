using Ishopping.Common.ConfigGlobal;
using Ishopping.Common.Constants;
using Ishopping.ViewModels.Admin;
using System;

namespace Ishopping.MVC.ViewModels.User
{
    public class UserFinancialHistoryViewModel
    {
        public int Group { get; set; }
        public int Company { get; set; }                    // Financeira (até o momento somente a uol pagseguro cod = 1) 
        public DateTime LastChange { get; set; }            // Data da criação (nunca deve ser alterada)
        public int Status { get; set; }                     // Status do serviço 
        public decimal PlanValue { get; set; }              // Valor do plano atual      
        public decimal Discount { get; set; }               // Desconto se o antigo plano tiver um valor mais alto que o plano atual
        public decimal Payment { get; set; }                // Valor total a pagar
        public double AddDayToPlan { get; set; }            // Em caso do desconto ser maior que o valor do plano atual, sera adicionado dias a mais ao plano  
        public DateTime DueDate { get; set; }               // Data do próximo vencimento    

        public decimal Balance;

        // formated itens
        public string _Date { get { return Timezone.DateTimeNow(LastChange).ToString(); } }
        public string _Company { get { return ConstantFinancial.GetCompany(Company); } }
        public string _Status { get { return ConstantFinancial.GetStatus(Status); } }
        public string _PlanValue { get { return PlanValue.ToString("C"); } }
        public string _Month { get { return GetMonth(); } }
        public string _Discount { get { return Discount.ToString("C"); } }
        public string _Balance { get { return GetBalance().ToString("C"); } }
        public string _Bonus { get { return GetBonus(); } }
        public string _DueDate { get { return Timezone.DateTimeNow(DueDate).ToShortDateString(); } }
        public string _Payment { get { return Payment.ToString("C"); } }
        public string _PaymentConfirmed { get { return GetPaymentConfirmed(); } } 


        // Relacionamento
        public int AdminFinancialPlanId { get; set; }
        public virtual AdminFinancialPlanViewModel AdminFinancialPlan { get; set; }


        // Private Methods
        private string GetPaymentConfirmed()
        {
            return this.Status == (int)ConstantFinancial.Transaction.Approved ? this._Payment : "R$ 0,00";
        }

        private decimal GetBalance()
        {
            if (this.Company == (int)ConstantFinancial.Company.None)
                return this.Discount + this.PlanValue;
            return 0;
        }

        private string GetBonus()
        {
            double bonus = this.AddDayToPlan;
            return bonus >= 2 ? bonus.ToString("0.00") + " dias" : bonus.ToString("0.00") + " dia";
        }

        private string GetMonth()
        {
            int month = this.AdminFinancialPlan.Month;
            return month > 1 ? month.ToString() + " meses" : month.ToString() + " mês";
        }
    }
}
