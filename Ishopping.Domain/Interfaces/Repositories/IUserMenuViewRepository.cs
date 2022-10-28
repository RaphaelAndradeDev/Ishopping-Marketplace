using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IUserMenuViewRepository : IRepositoryBaseT2<UserMenuView>
    {
        IEnumerable<UserMenuView> GetUserMenu(int siteNumber);
    }
}
