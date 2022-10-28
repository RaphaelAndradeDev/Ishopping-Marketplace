using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentPanelDapperRepository : Commun.Repository, IComponentPanelDapperRepository
    {
        public IEnumerable<ComponentPanel> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As PanelId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Icon, cm.Title, cm.Text," +
                " st.Id As OptionId, st.Title, st.Text" +
                " FROM ComponentPanel cm" +
                " INNER JOIN ComponentPanelOption st ON cm.ComponentPanelOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentPanel> list = cn.Query<ComponentPanel, ComponentPanelOption, ComponentPanel>(str, (cm, st) => { cm.AddComponentPanelOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "PanelId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentPanel>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As PanelId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Icon, cm.Title, cm.Text," +
                " st.Id As OptionId, st.Title, st.Text" +
                " FROM ComponentPanel cm" +
                " INNER JOIN ComponentPanelOption st ON cm.ComponentPanelOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentPanel> list = await cn.QueryAsync<ComponentPanel, ComponentPanelOption, ComponentPanel>(str, (cm, st) => { cm.AddComponentPanelOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "PanelId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
