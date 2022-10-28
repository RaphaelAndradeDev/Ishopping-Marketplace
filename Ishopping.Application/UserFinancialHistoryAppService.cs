using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;

namespace Ishopping.Application
{
    public class UserFinancialHistoryAppService : AppServiceBaseT2<UserFinancialHistory>, IUserFinancialHistoryAppService
    {
        private readonly IUserFinancialHistoryService _userFinancialHistoryService;

        public UserFinancialHistoryAppService(IUserFinancialHistoryService userFinancialHistoryService)
            :base(userFinancialHistoryService)
        {
            _userFinancialHistoryService = userFinancialHistoryService;
        }

        public DateTime? GetDueDate(string userId)
        {
            return _userFinancialHistoryService.GetDueDate(userId);
        }
    }
}
