
using System.Collections.Generic;
using System.Linq;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Domain.Services
{
    public class SupportTransactionStatusService : ServiceBaseT2<SupportTransactionStatus>, ISupportTransactionStatusService
    {
        private readonly ISupportTransactionStatusRepository _supportTransactionStatus;

        public SupportTransactionStatusService(ISupportTransactionStatusRepository supportTransactionStatus)
            : base(supportTransactionStatus)
        {
            _supportTransactionStatus = supportTransactionStatus;
        }       
    }
}
