using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IUserMenuViewItemService : IServiceBaseT2<UserMenuViewItem>
    {
        UserMenuViewItem GetBy(string userId, int viewCod, string itemType);
    }
}
