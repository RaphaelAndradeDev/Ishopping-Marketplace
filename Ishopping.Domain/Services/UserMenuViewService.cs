using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Domain.Services
{
    public class UserMenuViewService : ServiceBaseT2<UserMenuView>, IUserMenuViewService
    {
        private readonly IUserMenuViewRepository _userMenuViewRepository;

        public UserMenuViewService(IUserMenuViewRepository userMenuViewRepository)
            :base(userMenuViewRepository)
        {
            _userMenuViewRepository = userMenuViewRepository;
        }

        public IEnumerable<UserMenuView> GetUserMenu(int siteNumber)
        {
            return ClearMenu(_userMenuViewRepository.GetUserMenu(siteNumber).ToList());
        }


        // Private Methods
        private List<UserMenuView> ClearMenu(List<UserMenuView> listUserMenuView)
        {
            return GetNoActivated(listUserMenuView) ? RemoveNoActivated(listUserMenuView) : listUserMenuView;
        }

        private bool GetNoActivated(List<UserMenuView> listUserMenuView)
        {
            var listUserMenuViewItem = new List<UserMenuViewItem>();
            foreach (var userMenuView in listUserMenuView)
            {
                return userMenuView.UserMenuViewItem.Any(x => x.Activated == false || x.TextMenu == "");
            }
            return false;
        }

        private List<UserMenuView> RemoveNoActivated(List<UserMenuView> listUserMenuView)
        {
            for (int i = 0; i < listUserMenuView.Count; i++)
            {
                for (int j = 0; j < listUserMenuView.ElementAt(i).UserMenuViewItem.Count; j++)
                {
                    if ((!listUserMenuView.ElementAt(i).UserMenuViewItem.ElementAt(j).Activated) || (listUserMenuView.ElementAt(i).UserMenuViewItem.ElementAt(j).TextMenu == ""))
                    {
                        listUserMenuView.ElementAt(i).UserMenuViewItem.Remove(listUserMenuView.ElementAt(i).UserMenuViewItem.ElementAt(j));
                    }
                }
            }
            return listUserMenuView;
        }
    }
}
