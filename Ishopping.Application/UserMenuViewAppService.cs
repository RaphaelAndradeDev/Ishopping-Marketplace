using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Application
{
    public class UserMenuViewAppService : AppServiceBaseT2<UserMenuView>, IUserMenuViewAppService
    {
        private readonly IUserMenuViewService _userMenuViewService;

        public UserMenuViewAppService(IUserMenuViewService userMenuViewService)
            :base(userMenuViewService)
        {
            _userMenuViewService = userMenuViewService;
        }

        public IEnumerable<UserMenuView> GetUserMenu(int siteNumber)
        {
            return _userMenuViewService.GetUserMenu(siteNumber);
        }
    }
}
