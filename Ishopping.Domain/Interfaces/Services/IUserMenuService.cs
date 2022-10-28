using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IUserMenuService : IServiceBaseT2<UserMenu>, IServiceIdentified<UserMenu>
    {
        UserMenu GetByUserId(string userId);
        UserMenu GetMenuBySiteNumber(int siteNumber);
    }
}
