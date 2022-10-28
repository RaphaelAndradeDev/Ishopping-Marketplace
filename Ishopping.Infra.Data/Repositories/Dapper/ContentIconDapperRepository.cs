using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ContentIconDapperRepository : Repository, IContentIconDapperRepository
    {
        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT ct.Id, ct.IdUser, ct.SiteNumber, ct.Position, ct.Icon" +
               " FROM ContentIcon ct" +         
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentIcon> list = cn.Query<ContentIcon>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return list;
            }
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            string str = "SELECT ct.Id, ct.IdUser, ct.SiteNumber, ct.Position, ct.Icon" +
              " FROM ContentIcon ct" +
              " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentIcon> list = cn.Query<ContentIcon>(str, new { SiteNumber = siteNumber, MaxPosition = maxPosition });
                cn.Close();
                return list;
            }
        }

        public IEnumerable<ContentIcon> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT ct.Id, ct.IdUser, ct.SiteNumber, ct.Position, ct.Icon" +
              " FROM ContentIcon ct" +
              " WHERE ct.SiteNumber = @SiteNumber AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentIcon> list = cn.Query<ContentIcon>(str, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod });
                cn.Close();
                return list;
            }
        }


        // Async Methods
        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT ct.Id, ct.IdUser, ct.SiteNumber, ct.Position, ct.Icon" +
              " FROM ContentIcon ct" +
              " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentIcon> list = await cn.QueryAsync<ContentIcon>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            string str = "SELECT ct.Id, ct.IdUser, ct.SiteNumber, ct.Position, ct.Icon" +
              " FROM ContentIcon ct" +
              " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentIcon> list = await cn.QueryAsync<ContentIcon>(str, new { SiteNumber = siteNumber, MaxPosition = maxPosition });
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ContentIcon>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT ct.Id, ct.IdUser, ct.SiteNumber, ct.Position, ct.Icon" +
              " FROM ContentIcon ct" +
              " WHERE ct.SiteNumber = @SiteNumber AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentIcon> list = await cn.QueryAsync<ContentIcon>(str, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod });
                cn.Close();
                return list;
            }
        }
    }
}
