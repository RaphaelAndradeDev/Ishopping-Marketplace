using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IUserRegisterProfileDapperRepository
    {
        UserRegisterProfile GetBySiteNumber(int siteNumber);
        BasicProfile GetBasicProfile(string userId);        
        void SetGoogleFonts(string userId, string googleFonts);
        void SetProfileServices(ServicesProfile servicesProfile);
        void BlockProfiles(IEnumerable<string> userId);
        void EmailQuantityClear();

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
