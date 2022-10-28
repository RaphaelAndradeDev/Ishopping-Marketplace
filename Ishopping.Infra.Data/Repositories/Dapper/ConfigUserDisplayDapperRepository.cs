using Dapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ConfigUserDisplayDapperRepository : Repository, IConfigUserDisplayDapperRepository
    {
        private double d = 0.03;
        private int radius = 1;
        private List<ConfigUserDisplay> configUserDisplay = new List<ConfigUserDisplay>();
        private List<BasicDisplay> basicDisplayList = new List<BasicDisplay>();

        public async Task<IEnumerable<ConfigUserDisplay>> GetAllByGeolocationAsync(double latitude, double longitude)
        {
            string str = "SELECT TOP 9 cm.Id As DisplayId, cm.SiteNumber, cm.Action, cm.Controller, cm.Title, cm.Message," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ConfigUserDisplay cm" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE" +
                " (Latitude BETWEEN @LatitudeS AND @LatitudeN) AND" +
                " (Longitude BETWEEN @LongitudeO AND @LongitudeL) AND" +
                " Blocked = 'False' AND Maintenance = 'False'" +
                " ORDER BY NEWID()";

            string str2 = "SELECT TOP 9 cm.Id As DisplayId, cm.SiteNumber, cm.Action, cm.Controller, cm.Title, cm.Message," +
              " img.Id As ImageId, img.Folder, img.FileName" +
              " FROM ConfigUserDisplay cm" +
              " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
              " WHERE" +              
              " Blocked = 'False' AND Maintenance = 'False'" +
              " ORDER BY NEWID()";

            using (var cn = IshoppingConnection)
            {
                IEnumerable<ConfigUserDisplay> userDisplay;
                do
                {
                    cn.Open();
                    userDisplay = await cn.QueryAsync<ConfigUserDisplay, UserImageGallery, ConfigUserDisplay>(str, (cm, img) => { cm.AddUserImageGallery(img); return cm; }, new { LatitudeS = latitude - d, LatitudeN = latitude + d, LongitudeO = longitude - d, LongitudeL = longitude + d }, splitOn: "DisplayId,ImageId");
                    cn.Close();

                } while (LoadDisplay(userDisplay));

                if(configUserDisplay.Count == 0)
                {
                    cn.Open();
                    userDisplay = await cn.QueryAsync<ConfigUserDisplay, UserImageGallery, ConfigUserDisplay>(str2, (cm, img) => { cm.AddUserImageGallery(img); return cm; }, splitOn: "DisplayId,ImageId");
                    cn.Close();
                    return userDisplay;
                }
                return configUserDisplay;
            }
        }

        public async Task<IEnumerable<BasicDisplay>> GetAllBasicByGeolocationAsync(double latitude, double longitude)
        {
            string str = "SELECT TOP 9 cm.SiteNumber, cm.Action, cm.Controller, cm.District, cm.City, cm.State, cm.Latitude, cm.Longitude" +        
                " FROM ConfigUserDisplay cm" +       
                " WHERE" +
                " (Latitude BETWEEN @LatitudeS AND @LatitudeN) AND" +
                " (Longitude BETWEEN @LongitudeO AND @LongitudeL) AND" +
                " Blocked = 'False' AND Maintenance = 'False'" +
                " ORDER BY NEWID()";

            string str2 = "SELECT TOP 9 cm.SiteNumber, cm.Action, cm.Controller" +     
              " FROM ConfigUserDisplay cm" +      
              " WHERE" +
              " Blocked = 'False' AND Maintenance = 'False'" +
              " ORDER BY NEWID()";

            using (var cn = IshoppingConnection)
            {
                IEnumerable<BasicDisplay> basicDisplay;
                do
                {
                    cn.Open();
                    basicDisplay = await cn.QueryAsync<BasicDisplay>(str, new { LatitudeS = latitude - d, LatitudeN = latitude + d, LongitudeO = longitude - d, LongitudeL = longitude + d });
                    cn.Close();

                } while (LoadDisplay(basicDisplay));

                if (configUserDisplay.Count == 0)
                {
                    cn.Open();
                    basicDisplay = await cn.QueryAsync<BasicDisplay>(str2);
                    cn.Close();
                    return basicDisplay;
                }
                return basicDisplayList;
            }
        }

        public async Task<IEnumerable<ConfigUserDisplay>> GetBySearchAsync(string semantic, string address)
        {
            string str = "SELECT TOP 12 cm.Id As DisplayId, cm.SiteNumber, cm.Action, cm.Controller, cm.Title, cm.Message," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ConfigUserDisplay cm" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE" +
                " SemanticFull LIKE '%" + semantic.Trim() + "%' AND" +
                " AddressFull LIKE '%" + address.Trim() + "%' AND" +
                " Blocked = 'False' AND Maintenance = 'False'" +
                " ORDER BY NEWID()";

            using (var cn = IshoppingConnection)
            {
                IEnumerable<ConfigUserDisplay> userDisplay;
                cn.Open();
                userDisplay = await cn.QueryAsync<ConfigUserDisplay, UserImageGallery, ConfigUserDisplay>(str, (cm, img) => { cm.AddUserImageGallery(img); return cm; }, splitOn: "DisplayId,ImageId");
                cn.Close();
                return userDisplay;
            }
        }

        public async Task<IEnumerable<ConfigUserDisplay>> GetSpecificAsync(string specific)
        {
            string str = "SELECT TOP 12 cm.Id As DisplayId, cm.SiteNumber, cm.Action, cm.Controller, cm.Title, cm.Message," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ConfigUserDisplay cm" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE" +
                " Specific LIKE '%" + specific.Trim() + "%' AND" +
                " Blocked = 'False' AND Maintenance = 'False'" +
                " ORDER BY NEWID()";

            using (var cn = IshoppingConnection)
            {
                IEnumerable<ConfigUserDisplay> userDisplay;
                cn.Open();
                userDisplay = await cn.QueryAsync<ConfigUserDisplay, UserImageGallery, ConfigUserDisplay>(str, (cm, img) => { cm.AddUserImageGallery(img); return cm; }, splitOn: "DisplayId,ImageId");
                cn.Close();
                return userDisplay;
            }
        }

        public async Task<IEnumerable<string>> SearchBySemanticAsync(string term)
        {
            string str = "SELECT TOP 5 cm.SemanticFull" +
                " FROM ConfigUserDisplay cm" +
                " WHERE" +
                " SemanticFull LIKE '%" + term.Trim() + "%' AND" +
                " Blocked = 'False' AND Maintenance = 'False'" +
                " ORDER BY NEWID()";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ConfigUserDisplay> list = await cn.QueryAsync<ConfigUserDisplay>(str);
                cn.Close();
                return SemanticFilter(list.Select(x => x.SemanticFull), term);
            }
        }

        public async Task<IEnumerable<string>> SearchByAddressAsync(string term)
        {
            term = term.Trim();
            string str = "SELECT TOP 5 cm.Street, cm.District, cm.City, cm.State" +
                " FROM ConfigUserDisplay cm" +
                " WHERE" +
                " Street LIKE '%" + term + "%' OR" +
                " District LIKE '%" + term + "%' OR" +
                " City LIKE '%" + term + "%' OR" +
                " State LIKE '%" + term + "%' AND" +
                " Blocked = 'False' AND Maintenance = 'False'" +
                " ORDER BY NEWID()";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ConfigUserDisplay> list = await cn.QueryAsync<ConfigUserDisplay>(str);
                cn.Close();
                return AddressFilter(list, term);
            }
        }

        public async Task<IEnumerable<string>> SearchSpecificAsync(string term)
        {
            string str = "SELECT TOP 5 cm.SiteName" +
                " FROM ConfigUserDisplay cm" +
                " WHERE" +
                " Specific LIKE '%" + term.Trim() + "%' AND" +
                " Blocked = 'False' AND Maintenance = 'False'" +
                " ORDER BY NEWID()";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ConfigUserDisplay> list = await cn.QueryAsync<ConfigUserDisplay>(str);
                cn.Close();
                return list.Select(x => x.SiteName);
            }
        }

        public async Task<IEnumerable<string>> SearchSpecificAdressAsync(string term)
        {
            string str = "SELECT TOP 5 cm.AddressFull" +
                " FROM ConfigUserDisplay cm" +
                " WHERE" +
                " Specific LIKE '%" + term.Trim() + "%' AND" +
                " Blocked = 'False' AND Maintenance = 'False'" +
                " ORDER BY NEWID()";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ConfigUserDisplay> list = await cn.QueryAsync<ConfigUserDisplay>(str);
                cn.Close();
                return list.Select(x => x.AddressFull);
            }
        }


        // Private Methods
        private bool LoadDisplay(IEnumerable<ConfigUserDisplay> userDisplay)
        {
            foreach (var item in userDisplay)
            {
                if (!configUserDisplay.Any(x => x.SiteNumber == item.SiteNumber))
                {
                    configUserDisplay.Add(item);
                    if (configUserDisplay.Count() >= 12) return false;
                }
            }
            d += 0.05;
            return d <= 0.2;
        }

        private bool LoadDisplay(IEnumerable<BasicDisplay> basicDisplay)
        {
            foreach (var item in basicDisplay)
            {
                if (!configUserDisplay.Any(x => x.SiteNumber == item.SiteNumber))
                {
                    item.Radius = radius;
                    basicDisplayList.Add(item);
                    if (basicDisplayList.Count() >= 12) return false;
                }
            }
            d += 0.05;
            radius += 1; 
            return d <= 0.2;
        }

        private List<string> SemanticFilter(IEnumerable<string> listSemantic, string term)
        {
            term = RemoveDiacritics(term).ToLower().Trim();

            var semantic = new List<string>();
            var restult = new List<string>();

            foreach (var item in listSemantic)
            {
                var str = item.ToLower().Split(',');
                semantic.AddRange(str);
            }

            foreach (var item in semantic)
            {
                string str = RemoveDiacritics(item);
                if (str.StartsWith(term))
                {
                    restult.Add(item);
                }
            }

            return restult.Distinct().ToList();
        }

        private List<string> AddressFilter(IEnumerable<ConfigUserDisplay> listConfigUserDisplay, string term)
        {
            term = RemoveDiacritics(term).ToLower().Trim();

            var restult = new List<string>();

            foreach (var item in listConfigUserDisplay)
            {
                if (RemoveDiacritics(item.Street).StartsWith(term))
                {
                    restult.Add(item.Street + " " + item.District + " " + item.City + " " + item.State);
                    continue;
                }
                else if (RemoveDiacritics(item.District).StartsWith(term))
                {
                    restult.Add(item.District + " " + item.City + " " + item.State);
                    continue;
                }
                else if (RemoveDiacritics(item.City).StartsWith(term))
                {
                    restult.Add(item.City + " " + item.State);
                    continue;
                }
                else
                {
                    restult.Add(item.State);
                    continue;
                }
            }
            return restult.Distinct().ToList();
        }

        private string RemoveDiacritics(string text)
        {
            const string SINGLEBYTE_LATIN_ASCII_ENCODING = "ISO-8859-7";

            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return Encoding.ASCII.GetString(
                Encoding.GetEncoding(SINGLEBYTE_LATIN_ASCII_ENCODING).GetBytes(text));
        }
    }
}
