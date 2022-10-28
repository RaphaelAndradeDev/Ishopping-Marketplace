using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ContentSliderDapperRepository : Repository, IContentSliderDapperRepository
    {
        public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT *" +
               " FROM ContentSlider" +
               " WHERE SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentSlider> list = cn.Query<ContentSlider>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return list;
            }
        }

        public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            string str = "SELECT *" +
              " FROM ContentSlider" +
              " WHERE SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentSlider> list = cn.Query<ContentSlider>(str, new { SiteNumber = siteNumber, MaxPosition = maxPosition });
                cn.Close();
                return list;
            }
        }

        public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT *" +
              " FROM ContentSlider" +
              " WHERE SiteNumber = @SiteNumber AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentSlider> list = cn.Query<ContentSlider>(str, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod });
                cn.Close();
                return list;
            }
        }


        // Async Methods
        public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT *" +
               " FROM ContentSlider" +
               " WHERE SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentSlider> list = await cn.QueryAsync<ContentSlider>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            string str = "SELECT *" +
              " FROM ContentSlider" +
              " WHERE SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentSlider> list = await cn.QueryAsync<ContentSlider>(str, new { SiteNumber = siteNumber, MaxPosition = maxPosition });
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT *" +
              " FROM ContentSlider" +
              " WHERE SiteNumber = @SiteNumber AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentSlider> list = await cn.QueryAsync<ContentSlider>(str, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod });
                cn.Close();
                return list;
            }
        }
    }
}
