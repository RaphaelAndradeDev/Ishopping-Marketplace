using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IUserMenuRepository : IRepositoryBaseT2<UserMenu>, IRepositoryIdentified<UserMenu>
    {
        UserMenu GetByUserId(string userId);
        UserMenu GetMenuBySiteNumber(int siteNumber);
    }
}
