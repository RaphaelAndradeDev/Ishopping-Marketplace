using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class UserMenuRepository : RepositoryBaseT2<UserMenu>, IUserMenuRepository
    {
        public UserMenu GetBySiteNumber(int siteNumber)
        {
            return db.UserMenu.Include("UserMenuView").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }

        public UserMenu GetByUserId(string userId)
        {
            return db.UserMenu.Include("UserMenuView").FirstOrDefault(x => x.IdUser == userId);
        }
        
        public UserMenu GetMenuBySiteNumber(int siteNumber)
        {
            return db.UserMenu.Include("UserMenuView").FirstOrDefault(x => x.SiteNumber == siteNumber);
        }
    }
}
