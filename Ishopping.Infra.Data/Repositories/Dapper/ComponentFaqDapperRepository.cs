using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentFaqDapperRepository : Commun.Repository, IComponentFaqDapperRepository
    {
        public IEnumerable<ComponentFaq> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As FaqId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Category, cm.Pergunta, cm.Resposta," +
                " st.Id As OptionId, st.Pergunta, st.Resposta" +
                " FROM ComponentFaq cm" +
                " INNER JOIN ComponentFaqOption st ON cm.ComponentFaqOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentFaq> list = cn.Query<ComponentFaq, ComponentFaqOption, ComponentFaq>(str, (cm, st) => { cm.AddComponentFaqOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "FaqId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentFaq>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As FaqId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Category, cm.Pergunta, cm.Resposta," +
                " st.Id As OptionId, st.Pergunta, st.Resposta" +
                " FROM ComponentFaq cm" +
                " INNER JOIN ComponentFaqOption st ON cm.ComponentFaqOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentFaq> list = await cn.QueryAsync<ComponentFaq, ComponentFaqOption, ComponentFaq>(str, (cm, st) => { cm.AddComponentFaqOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "FaqId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
