using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentTeamDapperRepository : Repository, IComponentTeamDapperRepository
    {
        public IEnumerable<ComponentTeam> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As TeamId, cm.IdUser, cm.SiteNumber, cm.Name, cm.Functio, cm.Description," +
                " st.Id As OptionId, st.Name, st.Functio, st.Description," +
                " sn.Id As SnId, sn.Link, sn.Rede, sn.Classe1, sn.Classe2, sn.Classe3, sn.Classe4," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentTeam cm" +
                " INNER JOIN ComponentTeamOption st ON cm.ComponentTeamOptionId = st.Id" +
                " INNER JOIN ComponentTeamSocialNetwork sn ON cm.Id = sn.ComponentTeamId" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentTeam> list = cn.Query<ComponentTeam, ComponentTeamSocialNetwork, ComponentTeamOption, UserImageGallery, ComponentTeam>(str, (cm, sn, st, img) => { cm.AddComponentTeamSocialNetwork(sn); cm.AddComponentTeamOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "TeamId,SnId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentTeam>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As TeamId, cm.IdUser, cm.SiteNumber, cm.Name, cm.Functio, cm.Description," +
                " st.Id As OptionId, st.Name, st.Functio, st.Description," +
                " sn.Id As SnId, sn.Link, sn.Rede, sn.Classe1, sn.Classe2, sn.Classe3, sn.Classe4," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentTeam cm" +
                " INNER JOIN ComponentTeamOption st ON cm.ComponentTeamOptionId = st.Id" +
                " INNER JOIN ComponentTeamSocialNetwork sn ON cm.Id = sn.ComponentTeamId" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentTeam> list = await cn.QueryAsync<ComponentTeam, ComponentTeamSocialNetwork, ComponentTeamOption, UserImageGallery, ComponentTeam>(str, (cm, sn, st, img) => { cm.AddComponentTeamSocialNetwork(sn); cm.AddComponentTeamOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "TeamId,SnId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }
    }
}
