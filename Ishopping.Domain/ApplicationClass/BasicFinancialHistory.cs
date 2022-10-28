
using System;
namespace Ishopping.Domain.ApplicationClass
{
    public class BasicFinancialHistory
    {
        public string PlanName { get; set; }
        public string Month { get; set; }
        public string PlanValue { get; set; }
        public string Balance { get; set; }
        public string Bonus { get; set; }
        public string DueDate { get; set; }
        public string Payment { get; set; }
             
        public BasicFinancialHistory(string planName, int month, decimal planValue, decimal balance, double bonus, DateTime dueDate, decimal payment)
        {
            this.PlanName = planName;
            this.Month = GetMonth(month);
            this.PlanValue = planValue.ToString("C");
            this.Balance = balance.ToString("C");
            this.Bonus = bonus.ToString("0.00") +" dias"; 
            this.DueDate = dueDate.ToShortDateString();
            this.Payment = payment.ToString("C");
        }

        private string GetMonth(int month)
        {        
            return month > 1 ? month.ToString() + " meses" : month.ToString() + " mês";
        }
    }
}
