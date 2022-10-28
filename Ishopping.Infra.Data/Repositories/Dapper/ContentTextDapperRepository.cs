using Dapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ContentTextDapperRepository : Repository, IContentTextDapperRepository
    {
        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT ct.Id As TextId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Text32, ct.Text512, ct.Text5120," +
               " st.Id As OptionId, st.Text32, st.Text512, st.Text5120" +
               " FROM ContentText ct" +
               " INNER JOIN ContentTextOption st ON ct.ContentTextOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentText> list = cn.Query<ContentText, ContentTextOption, ContentText>(str, (ct, st) => { ct.AddContentTextOption(st); return ct; }, new { SiteNumber = siteNumber }, splitOn: "TextId,OptionId");
                cn.Close();
                return list;
            }
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            string str = "SELECT ct.Id As TextId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Text32, ct.Text512, ct.Text5120," +
               " st.Id As OptionId, st.Text32, st.Text512, st.Text5120" +
               " FROM ContentText ct" +
               " INNER JOIN ContentTextOption st ON ct.ContentTextOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentText> list = cn.Query<ContentText, ContentTextOption, ContentText>(str, (ct, st) => { ct.AddContentTextOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition }, splitOn: "TextId,OptionId");
                cn.Close();
                return list;
            }
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT ct.Id As TextId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Text32, ct.Text512, ct.Text5120," +
               " st.Id As OptionId, st.Text32, st.Text512, st.Text5120" +
               " FROM ContentText ct" +
               " INNER JOIN ContentTextOption st ON ct.ContentTextOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentText> list = cn.Query<ContentText, ContentTextOption, ContentText>(str, (ct, st) => { ct.AddContentTextOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod }, splitOn: "TextId,OptionId");
                cn.Close();
                return list;
            }
        }


        // Async Methods
        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT ct.Id As TextId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Text32, ct.Text512, ct.Text5120," +
               " st.Id As OptionId, st.Text32, st.Text512, st.Text5120" +
               " FROM ContentText ct" +
               " INNER JOIN ContentTextOption st ON ct.ContentTextOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentText> list = await cn.QueryAsync<ContentText, ContentTextOption, ContentText>(str, (ct, st) => { ct.AddContentTextOption(st); return ct; }, new { SiteNumber = siteNumber }, splitOn: "TextId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            string str = "SELECT ct.Id As TextId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Text32, ct.Text512, ct.Text5120," +
               " st.Id As OptionId, st.Text32, st.Text512, st.Text5120" +
               " FROM ContentText ct" +
               " INNER JOIN ContentTextOption st ON ct.ContentTextOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentText> list = await cn.QueryAsync<ContentText, ContentTextOption, ContentText>(str, (ct, st) => { ct.AddContentTextOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition }, splitOn: "TextId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT ct.Id As TextId, ct.IdUser, ct.SiteNumber, ct.Position, ct.Text32, ct.Text512, ct.Text5120," +
               " st.Id As OptionId, st.Text32, st.Text512, st.Text5120" +
               " FROM ContentText ct" +
               " INNER JOIN ContentTextOption st ON ct.ContentTextOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentText> list = await cn.QueryAsync<ContentText, ContentTextOption, ContentText>(str, (ct, st) => { ct.AddContentTextOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod }, splitOn: "TextId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<BasicText>> GetAllBasicTextAsync(int siteNumber, int maxPosition)
        {
            string str = "SELECT ct.Position, ct.Text32, ct.Text512, ct.Text5120" +
               " FROM ContentText ct" +
               " WHERE ct.SiteNumber = @SiteNumber AND ct.Position <= @MaxPosition";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<BasicText> list = await cn.QueryAsync<BasicText>(str, new { SiteNumber = siteNumber, MaxPosition = maxPosition });
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<BasicText>> GetAllBasicTextAsync(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT ct.Position, ct.Text32, ct.Text512, ct.Text5120" +
               " FROM ContentText ct" +
               " WHERE ct.SiteNumber = @SiteNumber AND ct.Position <= @MaxPosition  AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<BasicText> list = await cn.QueryAsync<BasicText>(str, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod });
                cn.Close();
                return list;
            }
        }
    }
}
