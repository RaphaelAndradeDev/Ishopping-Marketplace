using System;
using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.User
{
    public class UserMenu_ViewModel
    {
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public int SiteNumber { get; private set; }
        public bool Blocked { get; private set; }
        public bool Maintenance { get; private set; }

        // Relacionamentos
        public virtual ICollection<UserMenuView_ViewModel> UserMenuView { get; private set; }
    }
}
