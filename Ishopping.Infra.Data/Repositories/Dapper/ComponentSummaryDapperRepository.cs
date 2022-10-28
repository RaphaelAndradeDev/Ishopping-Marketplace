using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentSummaryDapperRepository : Repository, IComponentSummaryDapperRepository
    {
        public IEnumerable<ComponentSummary> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As SummaryId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.Category, cm.Description," +
                " st.Id As OptionId, st.Title, st.Category, st.Description" +
                " FROM ComponentSummary cm" +
                " INNER JOIN ComponentSummaryOption st ON cm.ComponentSummaryOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentSummary> list = cn.Query<ComponentSummary, ComponentSummaryOption, ComponentSummary>(str, (cm, st) => { cm.AddComponentSummaryOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "SummaryId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentSummary>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As SummaryId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.Category, cm.Description," +
                " st.Id As OptionId, st.Title, st.Category, st.Description" +
                " FROM ComponentSummary cm" +
                " INNER JOIN ComponentSummaryOption st ON cm.ComponentSummaryOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentSummary> list = await cn.QueryAsync<ComponentSummary, ComponentSummaryOption, ComponentSummary>(str, (cm, st) => { cm.AddComponentSummaryOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "SummaryId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
