using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentProjectDapperRepository : Commun.Repository, IComponentProjectDapperRepository
    {
        public IEnumerable<ComponentProject> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As ProjectId, cm.IdUser, cm.SiteNumber, cm.Name, cm.Title, cm.DateIn, cm.Client, cm.Description, cm.Category, cm.WebSite, cm.UrlVideo, cm.Team," +
                " st.Id As OptionId, st.Name, st.Title, st.Client, st.Description, st.Category, st.Team" +
                " FROM ComponentProject cm" +
                " INNER JOIN ComponentProjectOption st ON cm.ComponentProjectOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentProject> list = cn.Query<ComponentProject, ComponentProjectOption, ComponentProject>(str, (cm, st) => { cm.AddComponentProjectOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ProjectId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentProject>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As ProjectId, cm.IdUser, cm.SiteNumber, cm.Name, cm.Title, cm.DateIn, cm.Client, cm.Description, cm.Category, cm.WebSite, cm.UrlVideo, cm.Team," +
                " st.Id As OptionId, st.Name, st.Title, st.Client, st.Description, st.Category, st.Team" +
                " FROM ComponentProject cm" +
                " INNER JOIN ComponentProjectOption st ON cm.ComponentProjectOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentProject> list = await cn.QueryAsync<ComponentProject, ComponentProjectOption, ComponentProject>(str, (cm, st) => { cm.AddComponentProjectOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ProjectId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
