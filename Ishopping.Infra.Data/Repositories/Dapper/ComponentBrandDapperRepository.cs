using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentBrandDapperRepository : Commun.Repository, IComponentBrandDapperRepository
    {
        public IEnumerable<ComponentBrand> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As BrandId, cm.IdUser, cm.SiteNumber, cm.Marca, cm.Comment, cm.SiteOficial, cm.Exibicao," +
                " st.Id As OptionId, st.Marca, st.Comment," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentBrand cm" +
                " INNER JOIN ComponentBrandOption st ON cm.ComponentBrandOptionId = st.Id" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentBrand> list = cn.Query<ComponentBrand, ComponentBrandOption, UserImageGallery, ComponentBrand>(str, (cm, st, img) => { cm.AddComponentBrandOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "BrandId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentBrand>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As BrandId, cm.IdUser, cm.SiteNumber, cm.Marca, cm.Comment, cm.SiteOficial, cm.Exibicao," +
                " st.Id As OptionId, st.Marca, st.Comment," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentBrand cm" +
                " INNER JOIN ComponentBrandOption st ON cm.ComponentBrandOptionId = st.Id" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentBrand> list = await cn.QueryAsync<ComponentBrand, ComponentBrandOption, UserImageGallery, ComponentBrand>(str, (cm, st, img) => { cm.AddComponentBrandOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber }, splitOn: "BrandId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }
    }
}
