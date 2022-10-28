using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class UserMenuDapperRepository : Repository, IUserMenuDapperRepository
    {
        public UserMenu GetBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As ActivityId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.VectorIcon, cm.Description," +
                " st.Id As OptionId, st.Title, st.Description" +
                " FROM ComponentActivity cm" +
                " INNER JOIN ComponentActivityOption st ON cm.ComponentActivityOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var userMenu = cn.QueryFirst<UserMenu>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return userMenu;
            }
        }


        // Async Methods
        public async Task<UserMenu> GetBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As ActivityId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.VectorIcon, cm.Description," +
                " st.Id As OptionId, st.Title, st.Description" +
                " FROM ComponentActivity cm" +
                " INNER JOIN ComponentActivityOption st ON cm.ComponentActivityOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var userMenu = await cn.QueryFirstAsync<UserMenu>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return userMenu;
            }
        }
    }
}
