using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class SupportTransaction
    {
        public Guid Id { get; private set; }                            // esse id não será gerado automaticamente
        public string userId { get; private set; }                      // id do usuário
        public int FinanceCompanyCod { get; private set; }              // código único da financeira               
        public int TransactionFor { get; private set; }                 // 1 para clientes do Ishopping, 2 para clientes das lojas virtuais

        // Relacionamento
        public virtual ICollection<SupportTransactionStatus> SupportTransactionStatus { get; private set; }

        // Ctor
        protected SupportTransaction() {}

        public SupportTransaction(string userId, int financeCompanyCod, int transactionFor)
        {
            this.userId = userId;                   
            this.FinanceCompanyCod = financeCompanyCod;
            this.TransactionFor = transactionFor;
        }

        // Methods
        public void AddSupportTransactionStatus(SupportTransactionStatus supportTransactionStatus)
        {
            this.SupportTransactionStatus.Add(supportTransactionStatus);
        }
    }
}
