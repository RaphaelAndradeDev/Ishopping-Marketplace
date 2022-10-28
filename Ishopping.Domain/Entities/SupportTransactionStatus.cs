using System;

namespace Ishopping.Domain.Entities
{
    public class SupportTransactionStatus
    {
        public Guid Id { get; private set; }
        public int TransactionStatus { get; private set; }              // status da transação (varia de acordo com cada financeira)
        public DateTime TransactionDate { get; private set; }           // data da ocorrência  
        public string ReferenceA { get; private set; }                  // referência da transação. Ex: notificationCode(UolPagSeguro)
        public string ReferenceB { get; private set; }

        // Relacionamento
        public int SupportTransactionId { get; private set; }
        public virtual SupportTransaction SupportTransaction { get; private set; }

        // Ctor
        protected SupportTransactionStatus() { }
        public SupportTransactionStatus(SupportTransaction supportTransaction, int transactionStatus, DateTime transactionDate, string referenceA, string referenceB)
        {
            this.SupportTransaction = supportTransaction;
            this.TransactionStatus = transactionStatus;
            this.TransactionDate = transactionDate;
            this.ReferenceA = referenceA;
            this.ReferenceB = referenceB;
        }       
    }
}
