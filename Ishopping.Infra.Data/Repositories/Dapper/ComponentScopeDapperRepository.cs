using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentScopeDapperRepository : Commun.Repository, IComponentScopeDapperRepository
    {
        public IEnumerable<ComponentScope> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As ScopeId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.Category, cm.VectorIcon, cm.Description," +
                " st.Id As OptionId, st.Title, st.Category, st.Description" +
                " FROM ComponentScope cm" +
                " INNER JOIN ComponentScopeOption st ON cm.ComponentScopeOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentScope> list = cn.Query<ComponentScope, ComponentScopeOption, ComponentScope>(str, (cm, st) => { cm.AddComponentScopeOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ScopeId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentScope>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As ScopeId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.Category, cm.VectorIcon, cm.Description," +
                " st.Id As OptionId, st.Title, st.Category, st.Description" +
                " FROM ComponentScope cm" +
                " INNER JOIN ComponentScopeOption st ON cm.ComponentScopeOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentScope> list = await cn.QueryAsync<ComponentScope, ComponentScopeOption, ComponentScope>(str, (cm, st) => { cm.AddComponentScopeOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ScopeId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
