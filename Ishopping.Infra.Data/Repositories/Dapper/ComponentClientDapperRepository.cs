using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentClientDapperRepository : Commun.Repository, IComponentClientDapperRepository
    {
        public IEnumerable<ComponentClient> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As ClientId, cm.IdUser, cm.SiteNumber, cm.Name, cm.Functio, cm.Comment, cm.Projects, cm.SiteOficial," +
            " st.Id As OptionId, st.Name, st.Functio, st.Comment, st.Projects," +
            " img.Id As ImageId, img.Folder, img.FileName" +
            " FROM ComponentClient cm" +
            " INNER JOIN ComponentClientOption st ON cm.ComponentClientOptionId = st.Id" +
            " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
            " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentClient> list = cn.Query<ComponentClient, ComponentClientOption, UserImageGallery, ComponentClient>(str, (cm, st, img) => { cm.AddComponentClientOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ClientId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentClient>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As ClientId, cm.IdUser, cm.SiteNumber, cm.Name, cm.Functio, cm.Comment, cm.Projects, cm.SiteOficial," +
           " st.Id As OptionId, st.Name, st.Functio, st.Comment, st.Projects," +
           " img.Id As ImageId, img.Folder, img.FileName" +
           " FROM ComponentClient cm" +
           " INNER JOIN ComponentClientOption st ON cm.ComponentClientOptionId = st.Id" +
           " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
           " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentClient> list = await cn.QueryAsync<ComponentClient, ComponentClientOption, UserImageGallery, ComponentClient>(str, (cm, st, img) => { cm.AddComponentClientOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ClientId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }
    }
}
