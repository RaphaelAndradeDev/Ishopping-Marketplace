using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentPresentationDapperRepository : Repository, IComponentPresentationDapperRepository
    {
        public IEnumerable<ComponentPresentation> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As PresentationId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.Category, cm.Description, cm.VectorIcon," +
                " st.Id As OptionId, st.Title, st.Category, st.Description," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentPresentation cm" +
                " INNER JOIN ComponentPresentationOption st ON cm.ComponentPresentationOptionId = st.Id" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentPresentation> list = cn.Query<ComponentPresentation, ComponentPresentationOption, UserImageGallery, ComponentPresentation>(str, (cm, st, img) => { cm.AddComponentPresentationOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "PresentationId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentPresentation>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As PresentationId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Title, cm.Category, cm.Description, cm.VectorIcon," +
               " st.Id As OptionId, st.Title, st.Category, st.Description," +
               " img.Id As ImageId, img.Folder, img.FileName" +
               " FROM ComponentPresentation cm" +
               " INNER JOIN ComponentPresentationOption st ON cm.ComponentPresentationOptionId = st.Id" +
               " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
               " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentPresentation> list = await cn.QueryAsync<ComponentPresentation, ComponentPresentationOption, UserImageGallery, ComponentPresentation>(str, (cm, st, img) => { cm.AddComponentPresentationOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "PresentationId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }
    }
}
