
using System.Collections.Generic;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Application
{
    public class SupportTransactionStatusAppService : AppServiceBaseT2<SupportTransactionStatus>, ISupportTransactionStatusAppService
    {
        private readonly ISupportTransactionStatusService _supportTransactionStatusService;

        public SupportTransactionStatusAppService(ISupportTransactionStatusService supportTransactionStatusService)
            : base(supportTransactionStatusService)
        {
            _supportTransactionStatusService = supportTransactionStatusService;            
        }     
    }
}
