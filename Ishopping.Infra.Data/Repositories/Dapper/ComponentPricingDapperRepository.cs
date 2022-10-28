using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentPricingDapperRepository : Commun.Repository, IComponentPricingDapperRepository
    {
        public IEnumerable<ComponentPricing> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As PricingId, cm.IdUser, cm.SiteNumber, cm.NomePlano, cm.Destacar, cm.Moeda, cm.PriceUnid, cm.PriceCent, cm.Periodo, cm.Description, cm.Comment, cm.TextButton, cm.UrlButton," +
                " st.Id As OptionId, st.NomePlano, st.Moeda, st.PriceUnid, st.PriceCent, st.Periodo, st.Description, st.Comment, st.TextButton, st.Price" +
                " FROM ComponentPricing cm" +
                " INNER JOIN ComponentPricingOption st ON cm.ComponentPricingOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentPricing> list = cn.Query<ComponentPricing, ComponentPricingOption, ComponentPricing>(str, (cm, st) => { cm.AddComponentPricingOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "PricingId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentPricing>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As PricingId, cm.IdUser, cm.SiteNumber, cm.NomePlano, cm.Destacar, cm.Moeda, cm.PriceUnid, cm.PriceCent, cm.Periodo, cm.Description, cm.Comment, cm.TextButton, cm.UrlButton," +
                " st.Id As OptionId, st.NomePlano, st.Moeda, st.PriceUnid, st.PriceCent, st.Periodo, st.Description, st.Comment, st.TextButton, st.Price" +
                " FROM ComponentPricing cm" +
                " INNER JOIN ComponentPricingOption st ON cm.ComponentPricingOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentPricing> list = await cn.QueryAsync<ComponentPricing, ComponentPricingOption, ComponentPricing>(str, (cm, st) => { cm.AddComponentPricingOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "PricingId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
