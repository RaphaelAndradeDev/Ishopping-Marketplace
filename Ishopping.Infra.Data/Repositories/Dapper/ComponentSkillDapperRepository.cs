using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentSkillDapperRepository : Repository, IComponentSkillDapperRepository
    {
        public IEnumerable<ComponentSkill> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As SkillId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Category, cm.Level, cm.Description," +
                " st.Id As OptionId, st.Category, st.Level, st.Description" +
                " FROM ComponentSkill cm" +
                " INNER JOIN ComponentSkillOption st ON cm.ComponentSkillOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentSkill> list = cn.Query<ComponentSkill, ComponentSkillOption, ComponentSkill>(str, (cm, st) => { cm.AddComponentSkillOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "SkillId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentSkill>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As SkillId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Category, cm.Level, cm.Description," +
                " st.Id As OptionId, st.Category, st.Level, st.Description" +
                " FROM ComponentSkill cm" +
                " INNER JOIN ComponentSkillOption st ON cm.ComponentSkillOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentSkill> list = await cn.QueryAsync<ComponentSkill, ComponentSkillOption, ComponentSkill>(str, (cm, st) => { cm.AddComponentSkillOption(st); return cm; }, new { SiteNumber = siteNumber }, splitOn: "SkillId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
