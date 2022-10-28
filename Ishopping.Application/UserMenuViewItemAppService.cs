using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class UserMenuViewItemAppService : AppServiceBaseT2<UserMenuViewItem>, IUserMenuViewItemAppService
    {
        private readonly IUserMenuViewItemService _userMenuViewItemService;

        public UserMenuViewItemAppService(IUserMenuViewItemService userMenuViewItemService)
            :base(userMenuViewItemService)
        {
            _userMenuViewItemService = userMenuViewItemService;
        }
    }
}
