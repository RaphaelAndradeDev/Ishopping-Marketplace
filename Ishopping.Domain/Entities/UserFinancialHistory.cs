using Ishopping.Common.Constants;
using System;
using System.Linq;

/*
 *   Essa classe armazena todas as transações financeiras feitas pelo usuário
 *   Essa classe armazena somente transações financeiras relacionadas ao troca de plano
 *   Todos os dados do plano estão disponiveis na classe AdminFinancialPlan
 */

namespace Ishopping.Domain.Entities
{
    public class UserFinancialHistory
    {
        public Guid Id { get; set; }
        public int Group { get; private set; }
        public int Company { get; private set; }                    // Financeira (até o momento somente a uol pagseguro cod = 1) 
        public DateTime Date { get; private set; }                  // Data da criação (nunca deve ser alterada)
        public int Status { get; private set; }                     // Status do serviço
        public DateTime LastChange { get; private set; }            // Data da alteração de status
        public decimal PlanValue { get; private set; }              // Valor do plano atual 
        public decimal Discount { get; private set; }               // Desconto se o antigo plano tiver um valor mais alto que o plano atual
        public decimal Payment { get; private set; }                // Valor total a pagar
        public double AddDayToPlan { get; private set; }            // Em caso do desconto ser maior que o valor do plano atual, sera adicionado dias a mais ao plano  
        public DateTime DueDate { get; private set; }               // Data do próximo vencimento 
        public bool IsBlock { get; private set; }                   // Define profile como já bloqueado para evitar que seja setado mais de uma vez

        public decimal Balance;
        
        // Relacionamento
        public Guid UserFinancialId { get; private set; }
        public virtual UserFinancial UserFinancial { get; private set; }

        public int AdminFinancialPlanId  { get; private set; }
        public virtual AdminFinancialPlan AdminFinancialPlan { get; private set; }

        // Private     
        private int _LastGroup;        
        private bool _HasChangedPlan;
        private DateTime _FirstPayment;

        // Ctor
        protected UserFinancialHistory() { }

        public UserFinancialHistory(Guid userFinancialId, AdminFinancialPlan adminFinancialPlan)
        {
            this.UserFinancialId = userFinancialId;
            this.AdminFinancialPlanId = adminFinancialPlan.Id;
            this.AdminFinancialPlan = adminFinancialPlan;
            this.Group = adminFinancialPlan.Value > 0 ? 1 : 0; 
            this.Company = 1;
            this.Date = DateTime.Now;
            this.Status = adminFinancialPlan.Value > 0 ? (int)ConstantFinancial.Transaction.Pendent : (int)ConstantFinancial.Transaction.Warranted;
            this.LastChange = DateTime.Now;
            this.PlanValue = adminFinancialPlan.Value;
            this.Discount = 0;
            this.Payment = adminFinancialPlan.Value;
            this.AddDayToPlan = 0;
            this.DueDate =  DateTime.Now.AddMonths(adminFinancialPlan.Month);
            this.IsBlock = false;
        }    

        public UserFinancialHistory(UserFinancial userFinancial, int group, AdminFinancialPlan adminFinancialPlan, int company, bool addDueDate)
        {          
            this.UserFinancialId = userFinancial.Id;
            this.AdminFinancialPlanId = adminFinancialPlan.Id;
            this.AdminFinancialPlan = adminFinancialPlan;
            this.Group = adminFinancialPlan.Value > 0 ? group : 0;
            this.Company = company;
            this.Date = DateTime.Now;
            this.Status = adminFinancialPlan.Value > 0 ? (int)ConstantFinancial.Transaction.Pendent : (int)ConstantFinancial.Transaction.Warranted;
            this.LastChange = DateTime.Now;
            this.PlanValue = adminFinancialPlan.Value;
            this.Discount = 0;
            this.Payment = adminFinancialPlan.Value;
            this.AddDayToPlan = 0;
            this.DueDate = addDueDate ? GetDueDateForNewPayment(userFinancial) : DateTime.Now.AddMonths(adminFinancialPlan.Month);
            this.IsBlock = false;

            SetId(userFinancial);
        }            

        public UserFinancialHistory(UserFinancial userFinancial, AdminFinancialPlan adminFinancialPlan, int company, int daysLocked)
        {               
            this.UserFinancialId = userFinancial.Id;       
            this.AdminFinancialPlanId = adminFinancialPlan.Id;
            this.AdminFinancialPlan = adminFinancialPlan;
            this.Company = company;
            this.Date = DateTime.Now;       
            this.LastChange = DateTime.Now;                   
            this.PlanValue = adminFinancialPlan.Value;
            this.IsBlock = false;

            if(adminFinancialPlan.Value > 0)
            {
                AppStart(userFinancial, adminFinancialPlan, daysLocked);
            }
            else
            {
                AppStart(userFinancial, adminFinancialPlan);
            }                      
        }

        public void SetStatus(int status)
        {
            this.Status = status;
        }

        public void SetIsBlock(bool isBlock)
        {
            this.IsBlock = isBlock;
        }

        public void SetDueDate(DateTime dueDate)
        {
            this.DueDate = dueDate;
        }

        // Private Methods
        private void AppStart(UserFinancial userFinancial, AdminFinancialPlan adminFinancialPlan, int daysLocked)
        {
            LastGroupForNewPlan(userFinancial);
            SetId(userFinancial);
            GetFirstPaymentForNewPlan(userFinancial);
            HasChangedPlan(userFinancial, adminFinancialPlan);
            GetBalance(userFinancial, daysLocked);
            GetDiscount(adminFinancialPlan);
            GetPaymentForNewPlan(adminFinancialPlan);
            GetDueDateForNewPlan(userFinancial, adminFinancialPlan);
            SetStatus();            
            SetGroup(_LastGroup);
        }

        private void AppStart(UserFinancial userFinancial, AdminFinancialPlan adminFinancialPlan)
        {
            this.Group = 0;
            this.Status = (int)ConstantFinancial.Transaction.Warranted;
            this.LastChange = DateTime.Now;
            this.PlanValue = adminFinancialPlan.Value;
            this.Discount = 0;
            this.Payment = adminFinancialPlan.Value;
            this.AddDayToPlan = 0;
            this.DueDate = DateTime.Now.AddMonths(adminFinancialPlan.Month);
            this.IsBlock = false;         
        }

        private void SetGroup(int lastGroup)
        {
            if (_HasChangedPlan)
                this.Group = lastGroup + 1;
        }

        private void SetStatus()
        {
            int approved = this.Company == 0 ? (int)ConstantFinancial.Transaction.Deducted : (int)ConstantFinancial.Transaction.Approved;
            int pendent = _HasChangedPlan ? (int)ConstantFinancial.Transaction.Insufficient : (int)ConstantFinancial.Transaction.Pendent;
            this.Status = this.Payment <= 0 ? approved : pendent;
        }

        private void GetPaymentForNewPlan(AdminFinancialPlan adminFinancialPlan)
        {
            // retorna o valor absoluto de quanto o cliente deve pagar
            // se o pagamento for negativo sera adicionado dias a mais no plano atual e o pagamento sera zero
            decimal payment = adminFinancialPlan.Value - Balance;            
            if (payment < 0)
            {
                GetDiscount(adminFinancialPlan);
                payment = 0;
            }
            this.Payment = payment;
        }

        private void GetDueDateForNewPlan(UserFinancial userFinancial, AdminFinancialPlan adminFinancialPlan)
        {
            // retorna a data do próximo vencimento            
            int month = adminFinancialPlan.Month;
            this.DueDate = DateTime.Now.AddMonths(month).AddDays(this.AddDayToPlan);
        }

        private void GetDiscount(AdminFinancialPlan adminFinancialPlan)
        {
            decimal discount = 0;
            if (this.Balance > adminFinancialPlan.Value)
            {
                discount = this.Balance - adminFinancialPlan.Value;
                AddDaysForNewPlan(adminFinancialPlan, discount);
            }
            this.Discount = discount;
        }               

        private void GetBalance(UserFinancial userFinancial, int daysLocked)
        {
            // Retorna o saldo atual baseado no grupo
            decimal balance = SumTotal(userFinancial) - Consumed(userFinancial, daysLocked);
            this.Balance = balance < 0 ? 0 : balance;
        }

        private void SetId(UserFinancial userFinancial)
        {           
            var lastFinancialHistory = userFinancial.UserFinancialHistory.OrderByDescending(x => x.Date).FirstOrDefault();

            if(lastFinancialHistory == null)
            {
                this.Id = Guid.Empty;
                return;
            }                

            if (IsCreateNew(lastFinancialHistory.Status))
                this.Id = Guid.Empty;  
            else
                this.Id = lastFinancialHistory.Id;                              
        }                

        private void HasChangedPlan(UserFinancial userFinancial, AdminFinancialPlan adminFinancialPlan)
        {
            // retorna verdadeiro se houve troca de plano      
            int oldCod = userFinancial.UserFinancialHistory.OrderBy(x => x.LastChange).Last().AdminFinancialPlan.Cod;
            this._HasChangedPlan = oldCod != adminFinancialPlan.Cod;
        }

        private void GetFirstPaymentForNewPlan(UserFinancial userFinancial)
        {
            this._FirstPayment = userFinancial.UserFinancialHistory.Where(x => (x.Status == (int)ConstantFinancial.Transaction.Approved || x.Status == (int)ConstantFinancial.Transaction.Deducted) && x.Group == _LastGroup).OrderBy(x => x.Date).First().LastChange;
        }

        private void LastGroupForNewPlan(UserFinancial userFinancial)
        {            
            // Busca o último grupo
            var histrory = userFinancial.UserFinancialHistory.Where(x => x.Status == (int)ConstantFinancial.Transaction.Approved || x.Status == (int)ConstantFinancial.Transaction.Deducted).OrderBy(x => x.Date).Last();
            this._LastGroup = histrory.Group;                         
        }
                

        // Private Methods Invoke
        private void AddDaysForNewPlan(AdminFinancialPlan adminFinancialPlan, decimal discount)
        {
            decimal valueOfDay = adminFinancialPlan.Value / 30;
            this.AddDayToPlan = Convert.ToDouble(discount / valueOfDay);
        }

        private decimal Consumed(UserFinancial userFinancial, int daysLocked)
        {
            return Convert.ToDecimal(DaysOfUse(userFinancial, daysLocked)) * ValueOfDayCurrentPlan(userFinancial);
        }

        private decimal ValueOfDayCurrentPlan(UserFinancial userFinancial)
        {
            return userFinancial.UserFinancialHistory.First(x => x.Group == _LastGroup).PlanValue / 30;
        }

        private double DaysOfUse(UserFinancial userFinancial, int daysLocked)
        {
            // Retorna a primeira data de pagamento baseada no grupo
            double daysTotal = GetDataOff(userFinancial).Subtract(this._FirstPayment).TotalDays;
            return daysTotal - daysLocked;
        }

        private DateTime GetDataOff(UserFinancial userFinancial)
        {
            // Remove os dias em que o cliente usou o plano livre ou que ficou bloqueado
            var lastHistory = userFinancial.UserFinancialHistory.OrderBy(x => x.LastChange).Last();
            return lastHistory.Group == 0 ? lastHistory.LastChange : RemoveDaysLocked(userFinancial);
        }

        private DateTime RemoveDaysLocked(UserFinancial userFinancial)
        {
            // Remove os dias em que o cliente ficou bloqueado       
            var lastHistory = userFinancial.UserFinancialHistory.Where(x => (x.Status == (int)ConstantFinancial.Transaction.Approved || x.Status == (int)ConstantFinancial.Transaction.Deducted) && x.Group == _LastGroup).OrderBy(x => x.LastChange).Last();
                                        
            if (lastHistory.Status == (int)ConstantFinancial.Transaction.Approved || this.Status == (int)ConstantFinancial.Transaction.Deducted)
            {
                return DateTime.Now > lastHistory.DueDate ? lastHistory.DueDate : DateTime.Now;
            }

            return DateTime.Now;
        }     
            
        private decimal SumTotal(UserFinancial userFinancial)
        {
            // Retorna o saldo total baseado no grupo
            return SumDeducted(userFinancial) + SumPayment(userFinancial);   
        }

        private decimal SumDeducted(UserFinancial userFinancial)
        {
            // Retorna o saldo total baseado no grupo 
            decimal sum = 0;
            var deducted = userFinancial.UserFinancialHistory.FirstOrDefault(x => x.Status == (int)ConstantFinancial.Transaction.Deducted && x.Group == _LastGroup);
            if (deducted != null)
            {
                sum = deducted.Discount + deducted.PlanValue;
            }
            return sum;
        }

        private decimal SumPayment(UserFinancial userFinancial)
        {
            // Retorna o saldo total baseado no grupo 
            decimal sum = 0;
            var listHistory = userFinancial.UserFinancialHistory.Where(x => x.Status == (int)ConstantFinancial.Transaction.Approved && x.Group == _LastGroup);
            foreach (var history in listHistory)
            {
                sum += history.Payment;
            }
            return sum;
        }

        private bool IsCreateNew(int status)
        {
            // Retorna verdadeiro se deve ser criado um novo history
            switch (status)
            {
                case (int)ConstantFinancial.Transaction.Insufficient:
                    return false;
                case (int)ConstantFinancial.Transaction.Pendent:
                    return false;
                default:
                    return true;
            }
        }


        // Methods for Payment
        private DateTime GetDueDateForNewPayment(UserFinancial userFinancial)
        {
            // retorna a data do próximo vencimento
            LastGroupForNewPayment(userFinancial);
            GetFirstDueDateForNewPayment(userFinancial);
            int month = userFinancial.UserFinancialHistory.First(x => x.Group == _LastGroup).AdminFinancialPlan.Month;
            int payments = userFinancial.UserFinancialHistory.Count(x => (x.Status == (int)ConstantFinancial.Transaction.Approved || x.Status == (int)ConstantFinancial.Transaction.Deducted) && x.Group == _LastGroup);
            return _FirstPayment.AddMonths(month * payments).AddDays(this.AddDayToPlan);
        }

        private void LastGroupForNewPayment(UserFinancial userFinancial)
        {
            // Busca o último grupo
            var lastFinancialHistory = userFinancial.UserFinancialHistory.OrderBy(x => x.Date).Last();
            this._LastGroup = lastFinancialHistory.Group; 
        }

        private void GetFirstDueDateForNewPayment(UserFinancial userFinancial)
        {
            var firstDueDate = userFinancial.UserFinancialHistory.Where(x => (x.Status == (int)ConstantFinancial.Transaction.Approved || x.Status == (int)ConstantFinancial.Transaction.Deducted) && x.Group == _LastGroup).OrderBy(x => x.Date).FirstOrDefault();
            if (firstDueDate != null)
                this._FirstPayment = firstDueDate.DueDate;
            else
                this._FirstPayment = DateTime.Now;
        }

        private void Validate(int company, int status)
        {
   
        }

        
    }
}
