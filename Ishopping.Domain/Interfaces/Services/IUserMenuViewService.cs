using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IUserMenuViewService : IServiceBaseT2<UserMenuView>
    {
        IEnumerable<UserMenuView> GetUserMenu(int siteNumber);
    }
}
