using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Domain.Services
{
    public class UserMenuViewItemService : ServiceBaseT2<UserMenuViewItem>, IUserMenuViewItemService
    {
        private readonly IUserMenuViewItemRepository _userMenuViewItemRepository;

        public UserMenuViewItemService(IUserMenuViewItemRepository userMenuViewItemRepository)
            :base(userMenuViewItemRepository)
        {
            _userMenuViewItemRepository = userMenuViewItemRepository;
        }

        public UserMenuViewItem GetBy(string userId, int viewCod, string itemType)
        {
            return _userMenuViewItemRepository.GetBy(userId, viewCod, itemType);
        }
    }
}
