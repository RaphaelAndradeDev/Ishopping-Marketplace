using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ishopping.Domain.Entities;

namespace Ishopping.Application.Interface
{
    public interface IUserMenuAppService : IAppServiceBaseT2<UserMenu>, IAppServiceIdentified<UserMenu>
    {
        UserMenu GetByUserId(string userId);
        UserMenu GetMenuBySiteNumber(int siteNumber);
    }
}
