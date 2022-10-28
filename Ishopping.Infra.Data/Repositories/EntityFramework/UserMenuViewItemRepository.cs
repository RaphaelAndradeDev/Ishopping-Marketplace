using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class UserMenuViewItemRepository : RepositoryBaseT2<UserMenuViewItem>, IUserMenuViewItemRepository
    {
        public UserMenuViewItem GetBy(string userId, int viewCod, string itemType)
        {
            return db.UserMenuViewItem.Include("UserMenuView").First(x => x.UserMenuView.ViewCod == viewCod && x.ItemTipo == itemType && x.UserMenuView.UserMenu.IdUser == userId);
        }
    }
}
