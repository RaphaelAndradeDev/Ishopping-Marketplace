using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ContentListDapperRepository : Repository, IContentListDapperRepository
    {
        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT ct.Id As ListId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Lista, ct.Ordered," +
               " st.Id As OptionId, st.Lista" +
               " FROM ContentList ct" +
               " INNER JOIN ContentListOption st ON ct.ContentListOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentList> list = cn.Query<ContentList, ContentListOption, ContentList>(str, (ct, st) => { ct.AddContentListOption(st); return ct; }, new { SiteNumber = siteNumber }, splitOn: "ListId,OptionId");
                cn.Close();
                return list;
            }
        }

        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            string str = "SELECT ct.Id As ListId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Lista, ct.Ordered," +
               " st.Id As OptionId, st.Lista" +
               " FROM ContentList ct" +
               " INNER JOIN ContentListOption st ON ct.ContentListOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentList> list = cn.Query<ContentList, ContentListOption, ContentList>(str, (ct, st) => { ct.AddContentListOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition }, splitOn: "ListId,OptionId");
                cn.Close();
                return list;
            }
        }

        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT ct.Id As ListId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Lista, ct.Ordered," +
               " st.Id As OptionId, st.Lista" +
               " FROM ContentList ct" +
               " INNER JOIN ContentListOption st ON ct.ContentListOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentList> list = cn.Query<ContentList, ContentListOption, ContentList>(str, (ct, st) => { ct.AddContentListOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod }, splitOn: "ListId,OptionId");
                cn.Close();
                return list;
            }
        }


        // Async Methods
        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT ct.Id As ListId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Lista, ct.Ordered," +
               " st.Id As OptionId, st.Lista" +
               " FROM ContentList ct" +
               " INNER JOIN ContentListOption st ON ct.ContentListOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentList> list = await cn.QueryAsync<ContentList, ContentListOption, ContentList>(str, (ct, st) => { ct.AddContentListOption(st); return ct; }, new { SiteNumber = siteNumber }, splitOn: "ListId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            string str = "SELECT ct.Id As ListId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Lista, ct.Ordered," +
               " st.Id As OptionId, st.Lista" +
               " FROM ContentList ct" +
               " INNER JOIN ContentListOption st ON ct.ContentListOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentList> list = await cn.QueryAsync<ContentList, ContentListOption, ContentList>(str, (ct, st) => { ct.AddContentListOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition }, splitOn: "ListId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT ct.Id As ListId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Lista, ct.Ordered," +
               " st.Id As OptionId, st.Lista" +
               " FROM ContentList ct" +
               " INNER JOIN ContentListOption st ON ct.ContentListOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentList> list = await cn.QueryAsync<ContentList, ContentListOption, ContentList>(str, (ct, st) => { ct.AddContentListOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod }, splitOn: "ListId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
