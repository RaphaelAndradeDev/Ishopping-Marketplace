using Ishopping.Domain.Entities;
using System;

namespace Ishopping.Application.Interface
{
    public interface IUserFinancialHistoryAppService : IAppServiceBaseT2<UserFinancialHistory>
    {
        DateTime? GetDueDate(string userId);
    }
}
