using Dapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ConfigUserViewItemDapperRepository : Repository, IConfigUserViewItemDapperRepository
    {
        public IEnumerable<ConfigUserViewItem> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cn.Id As UserViewItemId, cn.SiteNumber, cn.Active, cn.TextMenu, cn.TextView, cn.StTextView, cn.SubTitle, cn.StSubTitle," +
               " adm.Id AS AdminViewItemId, adm.OnMenu, adm.Active, adm.TextMenu, adm.TextView, adm.ViewTipo, adm.ViewTypeCod, adm.Link" +           
               " FROM ConfigUserViewItem cn" +
               " INNER JOIN AdminViewItem adm ON cn.AdminViewItemId = adm.Id" +              
               " WHERE SiteNumber = @SiteNumber";

            using (var cnn = IshoppingConnection)
            {
                cnn.Open();
                IEnumerable<ConfigUserViewItem> list = cnn.Query<ConfigUserViewItem, AdminViewItem, ConfigUserViewItem>(str, (cn, adm) => { cn.AddAdminViewItem(adm); return cn; }, new { SiteNumber = siteNumber }, splitOn: "UserViewItemId,AdminViewItemId");     
                cnn.Close();
                return list;
            }
        }


        // Async Methods
        public async Task<IEnumerable<ConfigUserViewItem>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cn.Id As UserViewItemId, cn.SiteNumber, cn.Active, cn.TextMenu, cn.TextView, cn.StTextView, cn.SubTitle, cn.StSubTitle," +
               " adm.Id AS AdminViewItemId, adm.OnMenu, adm.Active, adm.TextMenu, adm.TextView, adm.ViewTipo, adm.ViewTypeCod, adm.Link" +
               " FROM ConfigUserViewItem cn" +
               " INNER JOIN AdminViewItem adm ON cn.AdminViewItemId = adm.Id" +
               " WHERE SiteNumber = @SiteNumber";

            using (var cnn = IshoppingConnection)
            {
                cnn.Open();
                IEnumerable<ConfigUserViewItem> list = await cnn.QueryAsync<ConfigUserViewItem, AdminViewItem, ConfigUserViewItem>(str, (cn, adm) => { cn.AddAdminViewItem(adm); return cn; }, new { SiteNumber = siteNumber }, splitOn: "UserViewItemId,AdminViewItemId");
                cnn.Close();
                return list;
            }
        }

        public async Task<BasicUserViewItem> GetBasicViewItemAsync(int viewTypeCod, string userId) 
        {
            string str = "SELECT cn.TextView, cn.StTextView, cn.SubTitle, cn.StSubTitle" +              
               " FROM ConfigUserViewItem cn" +
               " INNER JOIN AdminViewItem adm ON cn.AdminViewItemId = adm.Id" +
               " WHERE adm.ViewTypeCod = @ViewTypeCod AND cn.IdUser = @IdUser";

            using (var cnn = IshoppingConnection)
            {
                cnn.Open();
                BasicUserViewItem userViewItem = await cnn.QueryFirstAsync<BasicUserViewItem>(str, new { ViewTypeCod = viewTypeCod, IdUser = userId });
                cnn.Close();
                return userViewItem;
            }
        }

        public async Task<BasicUserViewItem> GetBasicViewItemAsync(int viewTypeCod, int siteNumber)
        {
            string str = "SELECT cn.Active, cn.TextView, cn.StTextView, cn.SubTitle, cn.StSubTitle" +
               " FROM ConfigUserViewItem cn" +
               " INNER JOIN AdminViewItem adm ON cn.AdminViewItemId = adm.Id" +
               " WHERE adm.ViewTypeCod = @ViewTypeCod AND cn.SiteNumber = @SiteNumber";

            using (var cnn = IshoppingConnection)
            {
                cnn.Open();
                BasicUserViewItem userViewItem = await cnn.QueryFirstAsync<BasicUserViewItem>(str, new { ViewTypeCod = viewTypeCod, SiteNumber = siteNumber });
                cnn.Close();
                return userViewItem;
            }
        }

        public async Task<IEnumerable<BasicUserViewItem>> GetAllBasicViewItemAsync(int[] viewTypeCod, int siteNumber)
        {
            string str = "SELECT cn.Active, cn.TextView, cn.StTextView, cn.SubTitle, cn.StSubTitle," +
               " adm.ViewTypeCod" +
               " FROM ConfigUserViewItem cn" +
               " INNER JOIN AdminViewItem adm ON cn.AdminViewItemId = adm.Id" +
               " WHERE adm.ViewTypeCod IN @ViewTypeCod AND cn.SiteNumber = @SiteNumber";

            using (var cnn = IshoppingConnection)
            {
                cnn.Open();
                var userViewItem = await cnn.QueryAsync<BasicUserViewItem>(str, new { ViewTypeCod = viewTypeCod, SiteNumber = siteNumber });
                cnn.Close();
                return userViewItem;
            }
        }
    }
}
