using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Application.Interface
{
    public interface IUserMenuViewAppService : IAppServiceBaseT2<UserMenuView>
    {
        IEnumerable<UserMenuView> GetUserMenu(int siteNumber);
    }
}
