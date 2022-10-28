using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace Ishopping.Infra.Data.Repositories
{
    public class UserMenuViewRepository : RepositoryBaseT2<UserMenuView>, IUserMenuViewRepository
    {     
        public IEnumerable<UserMenuView> GetUserMenu(int siteNumber)
        {
            return db.UserMenuView.Include("UserMenu").Include("UserMenuViewItem").Where(x => x.UserMenu.SiteNumber == siteNumber && x.Activated == true && x.OnMenu == true);
        }        
    }
}
