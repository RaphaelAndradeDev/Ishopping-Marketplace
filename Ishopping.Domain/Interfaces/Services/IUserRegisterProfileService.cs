using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IUserRegisterProfileService : IServiceBaseT2<UserRegisterProfile>
    {
        BasicProfile GetBasicProfile(string userId); 
        UserRegisterProfile GetBySiteNumber(int siteNumber);
        UserRegisterProfile GetByUserId(string userId);     
        bool ExistProfile(string userId);
        GroupPlan GetPlan(string userId);
        void SetSerialize(bool serialize, string userId);
        void SetGoogleFonts(string userId, string googleFonts);
        void BlockProfiles(IEnumerable<string> userId);
        void EmailQuantityClear();
        void SetProfileServices(ServicesProfile servicesProfile);        
        bool ExistSiteNumber(int siteNumber, string userId);
        bool ExistSiteName(string siteName, string userId);
        bool ExistCnpj(string cnpj, string userId);
        bool ExistEmail(string email, string userId);
        bool ExistEmpresa(string empresa, string userId);
        bool ExistWebsite(string website, string userId);
        void DeleteProfileExtension(string userId);   
    
        // Async Methods
        Task<UserRegisterProfile> GetBySiteNumberAsync(int siteNumber);
        Task<UserRegisterProfile> GetByUserIdAsync(string userId);
        Task<BasicProfile> GetBasicProfileAsync(string userId);
        Task<ServicesProfile> GetProfileServicesAsync(int siteNumber);
        Task<IEnumerable<string>> GetEmailAsync(IEnumerable<string> userId);
        Task<ProfileContact> GetProfileContactAsync(int siteNumber);

        // Admin Methods
        void SetRestriction(int siteNumber, bool restriction);
        void SetRestriction(IEnumerable<ProfileRestriction> profileRestriction);
        Task<IEnumerable<ProfileContact>> GetRestrictionAsync();
    }
}
