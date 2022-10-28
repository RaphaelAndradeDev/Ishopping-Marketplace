using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentMenuDapperRepository : Commun.Repository, IComponentMenuDapperRepository
    {
        public IEnumerable<ComponentMenu> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As MenuId, cm.IdUser, cm.SiteNumber, cm.Category, cm.Title, cm.Description, cm.Price," +
                " st.Id As OptionId, st.Title, st.Description, st.Price," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentMenu cm" +
                " INNER JOIN ComponentMenuOption st ON cm.ComponentMenuOptionId = st.Id" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentMenu> list = cn.Query<ComponentMenu, ComponentMenuOption, UserImageGallery, ComponentMenu>(str, (cm, st, img) => { cm.AddComponentMenuOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "MenuId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentMenu>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As MenuId, cm.IdUser, cm.SiteNumber, cm.Category, cm.Title, cm.Description, cm.Price," +
                " st.Id As OptionId, st.Title, st.Description, st.Price," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentMenu cm" +
                " INNER JOIN ComponentMenuOption st ON cm.ComponentMenuOptionId = st.Id" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentMenu> list = await cn.QueryAsync<ComponentMenu, ComponentMenuOption, UserImageGallery, ComponentMenu>(str, (cm, st, img) => { cm.AddComponentMenuOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "MenuId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }
    }
}
