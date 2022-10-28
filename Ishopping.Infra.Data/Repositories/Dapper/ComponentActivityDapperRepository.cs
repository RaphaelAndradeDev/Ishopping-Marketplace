using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentActivityDapperRepository : Repository, IComponentActivityDapperRepository
    {
        public IEnumerable<ComponentActivity> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As ActivityId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.VectorIcon, cm.Description," +
                " st.Id As OptionId, st.Title, st.Description" +
                " FROM ComponentActivity cm" +
                " INNER JOIN ComponentActivityOption st ON cm.ComponentActivityOptionId = st.Id" + 
                " WHERE cm.SiteNumber = @SiteNumber";              

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentActivity> list = cn.Query<ComponentActivity, ComponentActivityOption, ComponentActivity>(str, (cm, st) => { cm.AddComponentActivityOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ActivityId,OptionId");                
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentActivity>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As ActivityId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.VectorIcon, cm.Description," +
               " st.Id As OptionId, st.Title, st.Description" +
               " FROM ComponentActivity cm" +
               " INNER JOIN ComponentActivityOption st ON cm.ComponentActivityOptionId = st.Id" +
               " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentActivity> list = await cn.QueryAsync<ComponentActivity, ComponentActivityOption, ComponentActivity>(str, (cm, st) => { cm.AddComponentActivityOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ActivityId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
