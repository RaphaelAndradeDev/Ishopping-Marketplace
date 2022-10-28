using Ishopping.Common.Validation;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class UserMenu
    {
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public int SiteNumber { get; private set; }
        public bool Blocked { get; private set; }
        public bool Maintenance { get; private set; }

        // Relacionamentos
        public virtual ICollection<UserMenuView> UserMenuView { get; private set; }

        // Ctor
        protected UserMenu() { }
     
        public UserMenu(string userId, int siteNumber, bool blocked, bool maintenance)
        {
            CommonValidate.Validate(userId, siteNumber);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;      
            this.Blocked = blocked;
            this.Maintenance = maintenance;
        }

        // Methods
        public void Change(ICollection<UserMenuView> userMenuView, bool blocked, bool maintenance)
        {
            this.UserMenuView = userMenuView;
            this.Blocked = blocked;
            this.Maintenance = maintenance;
        }  
   
        public void AddListUserMenuView(ICollection<UserMenuView> userMenuView)
        {
            this.UserMenuView = userMenuView;
        }

        public void AddUserMenuView(UserMenuView userMenuView)
        {
            this.UserMenuView.Add(userMenuView);
        }
    }
}
