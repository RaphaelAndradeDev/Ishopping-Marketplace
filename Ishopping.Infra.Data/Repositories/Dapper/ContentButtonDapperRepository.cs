using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ContentButtonDapperRepository : Repository, IContentButtonDapperRepository
    {
        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT ct.Id As ButtonId, ct.IdUser, ct.SiteNumber, ct.Position, ct.TextBtn, ct.TextURL," +
               " st.Id As OptionId, st.TextBtn" +
               " FROM ContentButton ct" +
               " INNER JOIN ContentButtonOption st ON ct.ContentButtonOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentButton> list = cn.Query<ContentButton, ContentButtonOption, ContentButton>(str, (ct, st) => { ct.AddContentButtonOption(st); return ct; }, new { SiteNumber = siteNumber }, splitOn: "ButtonId,OptionId");
                cn.Close();
                return list;
            }
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            string str = "SELECT ct.Id As ButtonId, ct.IdUser, ct.SiteNumber, ct.Position, ct.TextBtn, ct.TextURL," +
               " st.Id As OptionId, st.TextBtn" +
               " FROM ContentButton ct" +
               " INNER JOIN ContentButtonOption st ON ct.ContentButtonOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentButton> list = cn.Query<ContentButton, ContentButtonOption, ContentButton>(str, (ct, st) => { ct.AddContentButtonOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition }, splitOn: "ButtonId,OptionId");
                cn.Close();
                return list;
            }
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT ct.Id As ButtonId, ct.IdUser, ct.SiteNumber, ct.Position, ct.TextBtn, ct.TextURL," +
               " st.Id As OptionId, st.TextBtn" +
               " FROM ContentButton ct" +
               " INNER JOIN ContentButtonOption st ON ct.ContentButtonOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentButton> list = cn.Query<ContentButton, ContentButtonOption, ContentButton>(str, (ct, st) => { ct.AddContentButtonOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod }, splitOn: "ButtonId,OptionId");
                cn.Close();
                return list;
            }
        }


        // Async Methods
        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT ct.Id As ButtonId, ct.IdUser, ct.SiteNumber, ct.Position, ct.TextBtn, ct.TextURL," +
               " st.Id As OptionId, st.TextBtn" +
               " FROM ContentButton ct" +
               " INNER JOIN ContentButtonOption st ON ct.ContentButtonOptionId = st.Id" +
               " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentButton> list = await cn.QueryAsync<ContentButton, ContentButtonOption, ContentButton>(str, (ct, st) => { ct.AddContentButtonOption(st); return ct; }, new { SiteNumber = siteNumber }, splitOn: "ButtonId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            string str = "SELECT ct.Id As ButtonId, ct.IdUser, ct.SiteNumber, ct.Position, ct.TextBtn, ct.TextURL," +
              " st.Id As OptionId, st.TextBtn" +
              " FROM ContentButton ct" +
              " INNER JOIN ContentButtonOption st ON ct.ContentButtonOptionId = st.Id" +
              " WHERE ct.SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentButton> list = await cn.QueryAsync<ContentButton, ContentButtonOption, ContentButton>(str, (ct, st) => { ct.AddContentButtonOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition }, splitOn: "ButtonId,OptionId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            string str = "SELECT ct.Id As ButtonId, ct.IdUser, ct.SiteNumber, ct.Position, ct.TextBtn, ct.TextURL," +
              " st.Id As OptionId, st.TextBtn" +
              " FROM ContentButton ct" +
              " INNER JOIN ContentButtonOption st ON ct.ContentButtonOptionId = st.Id" +
              " WHERE ct.SiteNumber = @SiteNumber AND ct.ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ContentButton> list = await cn.QueryAsync<ContentButton, ContentButtonOption, ContentButton>(str, (ct, st) => { ct.AddContentButtonOption(st); return ct; }, new { SiteNumber = siteNumber, MaxPosition = maxPosition, ViewCod = viewCod }, splitOn: "ButtonId,OptionId");
                cn.Close();
                return list;
            }
        }
    }
}
