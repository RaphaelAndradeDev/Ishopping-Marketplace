using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class AdminImageGalleryDapperRepository : Repository, IAdminImageGalleryDapperRepository
    {
        public IEnumerable<AdminImageGallery> GetAllByViewCod(int viewCod, int fileType)
        {
            string str = "SELECT *" +
              " FROM AdminImageGallery" +
              " WHERE ViewCod = @ViewCod AND FileType = @FileType";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var adminImageGallery = cn.Query<AdminImageGallery>(str, new { ViewCod = viewCod, FileType = fileType });
                cn.Close();
                return adminImageGallery;
            }
        }

        public async Task<IEnumerable<AdminImageGallery>> GetAllByViewCodAsync(int viewCod, int fileType)
        {
            string str = "SELECT *" +
              " FROM AdminImageGallery" +
              " WHERE ViewCod = @ViewCod AND FileType = @FileType";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var adminImageGallery = await cn.QueryAsync<AdminImageGallery>(str, new { ViewCod = viewCod, FileType = fileType });
                cn.Close();
                return adminImageGallery;
            }
        }            
    }
}
