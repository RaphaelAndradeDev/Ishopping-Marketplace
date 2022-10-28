using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentServiceDapperRepository : Commun.Repository, IComponentServiceDapperRepository
    {
        public IEnumerable<ComponentService> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As ServiceId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.Description," +
                " st.Id As OptionId, st.Title, st.Description," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentService cm" +
                " INNER JOIN ComponentServiceOption st ON cm.ComponentServiceOptionId = st.Id" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentService> list = cn.Query<ComponentService, ComponentServiceOption, UserImageGallery, ComponentService>(str, (cm, st, img) => { cm.AddComponentServiceOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ServiceId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentService>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As ServiceId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.Description," +
                " st.Id As OptionId, st.Title, st.Description," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentService cm" +
                " INNER JOIN ComponentServiceOption st ON cm.ComponentServiceOptionId = st.Id" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentService> list = await cn.QueryAsync<ComponentService, ComponentServiceOption, UserImageGallery, ComponentService>(str, (cm, st, img) => { cm.AddComponentServiceOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ServiceId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }
    }
}
