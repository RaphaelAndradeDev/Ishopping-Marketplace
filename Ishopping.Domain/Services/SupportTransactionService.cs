
using System.Collections.Generic;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Domain.Services
{
    public class SupportTransactionService : ServiceBaseT2<SupportTransaction>, ISupportTransactionService
    {
        private readonly ISupportTransactionRepository _supportTransactionRepository;

        public SupportTransactionService(ISupportTransactionRepository supportTransactionRepository)
            : base(supportTransactionRepository)
        {
            _supportTransactionRepository = supportTransactionRepository;
        }
    }
}
