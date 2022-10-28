using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentFeaturesDapperRepository : Commun.Repository, IComponentFeaturesDapperRepository
    {
        public IEnumerable<ComponentFeatures> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As FeaturesId, cm.IdUser, cm.SiteNumber, cm.Title, cm.Icon, cm.Count, cm.Description," +
                " st.Id As OptionId, st.Title, st.Count, st.Description" +
                " FROM ComponentFeatures cm" +
                " INNER JOIN ComponentFeaturesOption st ON cm.ComponentFeaturesOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentFeatures> list = cn.Query<ComponentFeatures, ComponentFeaturesOption, ComponentFeatures>(str, (cm, st) => { cm.AddComponentFeaturesOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "FeaturesId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentFeatures>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As FeaturesId, cm.IdUser, cm.SiteNumber, cm.Title, cm.Icon, cm.Count, cm.Description," +
                " st.Id As OptionId, st.Title, st.Count, st.Description" +
                " FROM ComponentFeatures cm" +
                " INNER JOIN ComponentFeaturesOption st ON cm.ComponentFeaturesOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentFeatures> list = await cn.QueryAsync<ComponentFeatures, ComponentFeaturesOption, ComponentFeatures>(str, (cm, st) => { cm.AddComponentFeaturesOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "FeaturesId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
