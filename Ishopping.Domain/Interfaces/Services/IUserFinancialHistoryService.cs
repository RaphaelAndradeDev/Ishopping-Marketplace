using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IUserFinancialHistoryService : IServiceBaseT2<UserFinancialHistory>
    {
        UserFinancialHistory GetBy(Guid id);
        DateTime? GetDueDate(string userId);
        IEnumerable<UserFinancialHistory> GetAllDueDate();
        void SetHistoryBlock(IEnumerable<Guid> id);
        void Persist(UserFinancialHistory userFinancialHistory, bool insert);

        // Async Methods
        Task<UserFinancialHistory> GetByAsync(Guid id);
    }
}
