using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentExtraLinkDapperRepository : Commun.Repository, IComponentExtraLinkDapperRepository
    {
        public IEnumerable<ComponentExtraLink> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As ExtraLinkId, cm.IdUser, cm.SiteNumber, cm.TextLink, cm.Link, cm.Description," +
                " st.Id As OptionId, st.TextLink, st.Description" +
                " FROM ComponentExtraLink cm" +
                " INNER JOIN ComponentExtraLinkOption st ON cm.ComponentExtraLinkOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentExtraLink> list = cn.Query<ComponentExtraLink, ComponentExtraLinkOption, ComponentExtraLink>(str, (cm, st) => { cm.AddComponentExtraLinkOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ExtraLinkId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentExtraLink>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As ExtraLinkId, cm.IdUser, cm.SiteNumber, cm.TextLink, cm.Link, cm.Description," +
                " st.Id As OptionId, st.TextLink, st.Description" +
                " FROM ComponentExtraLink cm" +
                " INNER JOIN ComponentExtraLinkOption st ON cm.ComponentExtraLinkOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentExtraLink> list = await cn.QueryAsync<ComponentExtraLink, ComponentExtraLinkOption, ComponentExtraLink>(str, (cm, st) => { cm.AddComponentExtraLinkOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ExtraLinkId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
