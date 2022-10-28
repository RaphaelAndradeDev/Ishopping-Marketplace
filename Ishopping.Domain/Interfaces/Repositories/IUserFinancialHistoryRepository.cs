using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IUserFinancialHistoryRepository : IRepositoryBaseT2<UserFinancialHistory>
    {
        UserFinancialHistory GetBy(Guid id);
        DateTime? GetDueDate(string userId);
        IEnumerable<UserFinancialHistory> GetAllDueDate();

        // Async Methods
        Task<UserFinancialHistory> GetByAsync(Guid id);
    }
}
