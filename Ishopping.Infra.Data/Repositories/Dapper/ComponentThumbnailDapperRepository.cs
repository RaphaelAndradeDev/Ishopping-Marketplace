using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentThumbnailDapperRepository : Repository, IComponentThumbnailDapperRepository
    {
        public IEnumerable<ComponentThumbnail> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As ThumbnailId, cm.IdUser, cm.SiteNumber, cm.Category, cm.VectorIcon, cm.WebSite," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentThumbnail cm" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentThumbnail> list = cn.Query<ComponentThumbnail, UserImageGallery, ComponentThumbnail>(str, (cm, img) => { cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ThumbnailId,ImageId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentThumbnail>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As ThumbnailId, cm.IdUser, cm.SiteNumber, cm.Category, cm.VectorIcon, cm.WebSite," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentThumbnail cm" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentThumbnail> list = await cn.QueryAsync<ComponentThumbnail, UserImageGallery, ComponentThumbnail>(str, (cm, img) => { cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "ThumbnailId,ImageId");
                cn.Close();
                return list;
            }
        }
    }
}
