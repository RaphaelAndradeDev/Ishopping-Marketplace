using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentSocialNetworkDapperRepository : Repository, IComponentSocialNetworkDapperRepository
    {
        public IEnumerable<ComponentSocialNetwork> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As SnId, cm.IdUser, cm.SiteNumber, cm.Link, cm.Rede, cm.Classe1, cm.Classe2, cm.Classe3, cm.Classe4" +
            " FROM ComponentSocialNetwork cm" +           
            " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentSocialNetwork> list = cn.Query<ComponentSocialNetwork>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentSocialNetwork>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As SnId, cm.IdUser, cm.SiteNumber, cm.Link, cm.Rede, cm.Classe1, cm.Classe2, cm.Classe3, cm.Classe4" +
            " FROM ComponentSocialNetwork cm" +
            " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentSocialNetwork> list = await cn.QueryAsync<ComponentSocialNetwork>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return list;
            }
        }
    }
}
