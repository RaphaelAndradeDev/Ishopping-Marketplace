
using System.Collections.Generic;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Application
{
    public class SupportTransactionAppService : AppServiceBaseT2<SupportTransaction>, ISupportTransactionAppService
    {
        private readonly ISupportTransactionService _supportTransactionService;

        public SupportTransactionAppService(ISupportTransactionService supportTransactionService)
            : base(supportTransactionService)
        {
            _supportTransactionService = supportTransactionService;
        }
    }
}
