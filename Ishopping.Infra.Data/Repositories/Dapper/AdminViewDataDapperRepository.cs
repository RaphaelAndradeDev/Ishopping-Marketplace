using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class AdminViewDataDapperRepository : Repository, IAdminViewDataDapperRepository
    {
        public AdminViewData GetByViewCod(int viewCod)
        {
            string str = "SELECT *" +
              " FROM AdminViewData" +
              " WHERE ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var adminViewData = cn.QueryFirst<AdminViewData>(str, new { ViewCod = viewCod });
                cn.Close();
                return adminViewData;
            }
        }

        // Async Methods
        public async Task<AdminViewData> GetByViewCodAsync(int viewCod)
        {
            string str = "SELECT *" +
              " FROM AdminViewData" +
              " WHERE ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var adminViewData = await cn.QueryFirstAsync<AdminViewData>(str, new { ViewCod = viewCod });
                cn.Close();
                return adminViewData;
            }
        }

        public async Task<AdminViewData> GetListImageAsync(int templateCod, int viewCod)
        {
            string str = "SELECT vd.ListImage, vd.ListIconPng, vd.ListLogo" +
              " FROM AdminViewData vd" +
              " INNER JOIN AdminTemplate tp ON vd.AdminTemplateId = tp.Id" +
              " WHERE vd.ViewCod = @ViewCod AND tp.TemplateCod = @TemplateCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var adminViewData = await cn.QueryFirstOrDefaultAsync<AdminViewData>(str, new { TemplateCod = templateCod, ViewCod = viewCod });
                cn.Close();
                return adminViewData;
            }
        }
    }
}
