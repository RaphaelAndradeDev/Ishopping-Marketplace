using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IUserMenuViewItemRepository : IRepositoryBaseT2<UserMenuViewItem>
    {
        UserMenuViewItem GetBy(string userId, int viewCod, string itemType);
    }
}
