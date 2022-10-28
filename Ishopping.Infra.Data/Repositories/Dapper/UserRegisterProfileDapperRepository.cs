using Dapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class UserRegisterProfileDapperRepository : Repository, IUserRegisterProfileDapperRepository
    {   

        public UserRegisterProfile GetBySiteNumber(int siteNumber)
        {
            string str = "SELECT *" +
              " FROM UserRegisterProfile" +
              " WHERE SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var userRegisterProfile = cn.QueryFirst<UserRegisterProfile>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return userRegisterProfile;
            }
        }

        public BasicProfile GetBasicProfile(string userId)
        {
            string str = "SELECT SiteNumber, Controller, AppMenu, TemplateCod, ViewStart, Serialize, GoogleFonts" +
              " FROM UserRegisterProfile" +
              " WHERE IdUser = @IdUser";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var basicProfile = cn.QueryFirst<BasicProfile>(str, new { IdUser = userId });
                cn.Close();
                return basicProfile;
            }
        }

        public void SetGoogleFonts(string userId, string googleFonts)
        {
            using (var cn = IshoppingConnection)
            {
                cn.Open();
                string sqlQuery = "UPDATE UserRegisterProfile SET GoogleFonts = @GoogleFonts WHERE IdUser = @IdUser";
                cn.Execute(sqlQuery, new { GoogleFonts = googleFonts, IdUser = userId });
                cn.Close();
            }
        }

        public void SetProfileServices(ServicesProfile servicesProfile)
        {           
            using (var cn = IshoppingConnection)
            {
                cn.Open();
                string sqlQuery = "UPDATE UserRegisterProfile SET EmailQuantity = @EmailQuantity  WHERE SiteNumber = @SiteNumber";
                cn.Execute(sqlQuery, new {                   
                    servicesProfile.EmailQuantity,
                    servicesProfile.SiteNumber
                });
                cn.Close();
            }
        }

        public void BlockProfiles(IEnumerable<string> userId)
        {
            using (var cn = IshoppingConnection)
            {
                cn.Open();
                string sqlQuery = "UPDATE UserRegisterProfile SET HasInsufficientValue = 1 WHERE IdUser = @IdUser";
                cn.Execute(sqlQuery, new { IdUser = userId });
                cn.Close();
            }
        }

        public void EmailQuantityClear()
        {
            using (var cn = IshoppingConnection)
            {
                cn.Open();
                string sqlQuery = "UPDATE UserRegisterProfile SET EmailQuantity = 0";
                cn.Execute(sqlQuery);
                cn.Close();
            }
        }


        // Async Methods
        public async Task<UserRegisterProfile> GetBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT *" +
              " FROM UserRegisterProfile" +
              " WHERE SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var userRegisterProfile = await cn.QueryFirstAsync<UserRegisterProfile>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return userRegisterProfile;
            }
        }

        public async Task<UserRegisterProfile> GetByUserIdAsync(string userId)
        {
            string str = "SELECT *" +
              " FROM UserRegisterProfile" +
              " WHERE IdUser = @IdUser";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var userRegisterProfile = await cn.QueryFirstAsync<UserRegisterProfile>(str, new { IdUser = userId });
                cn.Close();
                return userRegisterProfile;
            }
        }

        public async Task<BasicProfile> GetBasicProfileAsync(string userId)
        {
            string str = "SELECT SiteNumber, Controller, AppMenu, TemplateCod, ViewStart, Serialize, GoogleFonts" +
              " FROM UserRegisterProfile" +
              " WHERE IdUser = @IdUser";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var basicProfile = await cn.QueryFirstAsync<BasicProfile>(str, new { IdUser = userId });
                cn.Close();
                return basicProfile;
            }
        }

        public async Task<IEnumerable<string>> GetEmailAsync(IEnumerable<string> userId)
        {
            string str = "SELECT Email" +
              " FROM UserRegisterProfile" +
              " WHERE IdUser = @IdUser";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var emails = await cn.QueryAsync<string>(str, new { IdUser = userId });
                cn.Close();
                return emails;
            }
        }

        public async Task<ProfileContact> GetProfileContactAsync( int siteNumber )
        {
            string str = "SELECT ViewStart, SiteNumber, SiteName, Controller, Empresa, Rua, NumRua, Distrito, Cidade, Estado, CEP, Pais, Telefone, Telefone2, WhatsApp, Email, Latitude, Longitude" +
              " FROM UserRegisterProfile" +
              " WHERE SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var profiles = await cn.QueryFirstAsync<ProfileContact>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return profiles;
            }
        }        

        // Admin Methods  
        public void SetRestriction(int siteNumber, bool restriction)
        {
            using (var cn = IshoppingConnection)
            {
                cn.Open();
                string sqlQuery = "UPDATE UserRegisterProfile SET HasRestriction = @HasRestriction WHERE SiteNumber = @SiteNumber";
                cn.Execute(sqlQuery, new { HasRestriction = restriction, SiteNumber = siteNumber });
                cn.Close();
            }
        }

        public void SetRestriction(IEnumerable<ProfileRestriction> profileRestriction)
        {
            using (var cn = IshoppingConnection)
            {
                cn.Open();
                string sqlQuery = "UPDATE UserRegisterProfile SET HasRestriction = @HasRestriction WHERE SiteNumber = @SiteNumber";
                cn.Execute(sqlQuery, profileRestriction);
                cn.Close();
            }
        }
         
        public async Task<ServicesProfile> GetProfileServicesAsync(int siteNumber)
        {
            string str = "SELECT EmailQuantity, Email, [Plan], HasInsufficientValue, HasRestriction, IsTimeOver" +
              " FROM UserRegisterProfile" +
              " WHERE SiteNumber = @SiteNumber";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var servicesProfile = await cn.QueryFirstAsync<ServicesProfile>(str, new { SiteNumber = siteNumber });
                cn.Close();
                return servicesProfile;
            }
        }

        public async Task<IEnumerable<ProfileContact>> GetRestrictionAsync()
        {
            string str = "SELECT TOP 30 SiteNumber, SiteName, Controller, Cidade, Estado, Telefone, Telefone2, WhatsApp, Email" +
              " FROM UserRegisterProfile" +
              " WHERE HasRestriction = @HasRestriction";
                    
            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var profiles = await cn.QueryAsync<ProfileContact>(str, new { HasRestriction = true });
                cn.Close();
                return profiles;
            }
        }          
    }
}
