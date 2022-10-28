using Dapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class UserImageGalleryDapperRepository : Repository, IUserImageGalleryDapperRepository
    {
        public int CountImg(int fileType, string userId)
        {
            string str = "SELECT COUNT(*)" +
            " FROM UserImageGallery img" +
            " WHERE img.IdUser = @UserId AND img.FileType = @FileType";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                int count = cn.ExecuteScalar<int>(str, new { FileType = fileType, UserId = userId });
                cn.Close();
                return count;
            }
        }               

        public void SetImageCheck(IEnumerable<AdminImageChecked> adminImageChecked)
        {
            string str = "UPDATE UserImageGallery SET Checked = @Checked, IsBlock = @IsBlock WHERE Id = @Id";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                cn.Execute(str, adminImageChecked);
                cn.Close();   
            }
        }


        // Async Methods
        public async Task<int> CountImgAsync(int fileType, string userId)
        {
            string str = "SELECT COUNT(*)" +
            " FROM UserImageGallery img" +
            " WHERE img.IdUser = @UserId AND img.FileType = @FileType";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                int count = await cn.ExecuteScalarAsync<int>(str, new { FileType = fileType, UserId = userId });
                cn.Close();
                return count;
            }
        }

        public async Task<BasicImage> GetImageByViewCod(int viewCod, int fileType, int position, int siteNumber)
        {
            string str = "SELECT img.Folder, img.FileName" +
            " FROM UserImageGallery img" +
            " WHERE img.ViewCod = @ViewCod AND img.Position = @Position" +
            " AND img.SiteNumber = @SiteNumber AND img.FileType = @FileType";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var basicImage = await cn.QueryFirstOrDefaultAsync<BasicImage>(str, new { ViewCod = viewCod, FileType = fileType, Position = position, SiteNumber = siteNumber });
                cn.Close();
                return basicImage;
            }
        }
    }
}
