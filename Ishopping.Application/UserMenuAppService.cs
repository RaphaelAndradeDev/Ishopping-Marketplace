using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class UserMenuAppService : AppServiceBaseT2<UserMenu>, IUserMenuAppService
    {
        private readonly IUserMenuService _userMenuService;

        public UserMenuAppService(IUserMenuService userMenuService)
            :base(userMenuService)
        {
            _userMenuService = userMenuService;
        }

        public UserMenu GetBySiteNumber(int siteNumber)
        {
            return _userMenuService.GetBySiteNumber(siteNumber);
        }

        public UserMenu GetByUserId(string userId)
        {
            return _userMenuService.GetByUserId(userId);
        }
        
        public UserMenu GetMenuBySiteNumber(int siteNumber)
        {
            return _userMenuService.GetMenuBySiteNumber(siteNumber);
        }
    }
}
