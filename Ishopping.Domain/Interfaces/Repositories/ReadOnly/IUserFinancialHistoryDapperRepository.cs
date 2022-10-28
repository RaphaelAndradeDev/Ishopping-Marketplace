using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IUserFinancialHistoryDapperRepository
    {
        void Persist(UserFinancialHistory userFinancialHistory, bool insert);
        void SetHistoryBlock(IEnumerable<Guid> id);
    }
}
