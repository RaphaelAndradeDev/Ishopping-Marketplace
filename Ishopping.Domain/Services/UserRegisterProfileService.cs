using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class UserRegisterProfileService : ServiceBaseT2<UserRegisterProfile>, IUserRegisterProfileService
    {
        private readonly IUserRegisterProfileRepository _userRegisterProfileRepository;
        private readonly IUserRegisterProfileDapperRepository _userRegisterProfileDapperRepository; 

        public UserRegisterProfileService(
            IUserRegisterProfileRepository userRegisterProfileRepository,
            IUserRegisterProfileDapperRepository userRegisterProfileDapperRepository)
            :base(userRegisterProfileRepository)
        {
            _userRegisterProfileRepository = userRegisterProfileRepository;
            _userRegisterProfileDapperRepository = userRegisterProfileDapperRepository;
        }


        public BasicProfile GetBasicProfile(string userId)
        {
            return _userRegisterProfileDapperRepository.GetBasicProfile(userId);
        }

        public UserRegisterProfile GetBySiteNumber(int siteNumber)
        {
            return _userRegisterProfileDapperRepository.GetBySiteNumber(siteNumber);
        }
        
        public UserRegisterProfile GetByUserId(string userId)
        {
            return _userRegisterProfileRepository.GetByUserId(userId);
        }           
        
        public bool ExistProfile(string userId)
        {
            return _userRegisterProfileRepository.ExistProfile(userId);
        }

        public ApplicationClass.GroupPlan GetPlan(string userId)
        {
            return _userRegisterProfileRepository.GetPlan(userId);
        }

        public void SetSerialize(bool serialize, string userId)
        {
            _userRegisterProfileRepository.SetSerialize(serialize, userId);
        }

        public void SetGoogleFonts(string userId, string googleFonts)
        {
            _userRegisterProfileDapperRepository.SetGoogleFonts(userId, googleFonts);
        }

        public void SetProfileServices(ServicesProfile servicesProfile)
        {
            _userRegisterProfileDapperRepository.SetProfileServices(servicesProfile);
        }

        public void BlockProfiles(IEnumerable<string> userId)
        {
            _userRegisterProfileDapperRepository.BlockProfiles(userId);
        }

        public void EmailQuantityClear()
        {
            _userRegisterProfileDapperRepository.EmailQuantityClear();
        }

        public bool ExistSiteNumber(int siteNumber, string userId)
        {
            return _userRegisterProfileRepository.ExistSiteNumber(siteNumber, userId);
        }

        public bool ExistSiteName(string siteName, string userId)
        {
            return _userRegisterProfileRepository.ExistSiteName(siteName, userId);
        }

        public bool ExistCnpj(string cnpj, string userId)
        {
            return _userRegisterProfileRepository.ExistCnpj(cnpj, userId);
        }

        public bool ExistEmail(string email, string userId)
        {
            return _userRegisterProfileRepository.ExistEmail(email, userId);
        }

        public bool ExistEmpresa(string empresa, string userId)
        {
            return _userRegisterProfileRepository.ExistEmpresa(empresa, userId);
        }

        public bool ExistWebsite(string website, string userId)
        {
            return _userRegisterProfileRepository.ExistWebsite(website, userId);
        }

        public void DeleteProfileExtension(string userId)
        {
            _userRegisterProfileRepository.DeleteProfileExtension(userId);
        }

        // Async Methods
        public async Task<UserRegisterProfile> GetBySiteNumberAsync(int siteNumber)
        {
            return await _userRegisterProfileDapperRepository.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<UserRegisterProfile> GetByUserIdAsync(string userId)
        {
            return await _userRegisterProfileDapperRepository.GetByUserIdAsync(userId);
        }

        public async Task<BasicProfile> GetBasicProfileAsync(string userId)
        {
            return await _userRegisterProfileDapperRepository.GetBasicProfileAsync(userId);
        }
        
        public async Task<ServicesProfile> GetProfileServicesAsync(int siteNumber)
        {
            return await _userRegisterProfileDapperRepository.GetProfileServicesAsync(siteNumber);
        }

        public async Task<IEnumerable<string>> GetEmailAsync(IEnumerable<string> userId)
        {
            return await _userRegisterProfileDapperRepository.GetEmailAsync(userId);
        }

        public async Task<ProfileContact> GetProfileContactAsync(int siteNumber)
        {
            return await _userRegisterProfileDapperRepository.GetProfileContactAsync(siteNumber);
        }

        // Admin Methods
        public void SetRestriction(IEnumerable<ProfileRestriction> profileRestriction)
        {
            _userRegisterProfileDapperRepository.SetRestriction(profileRestriction);
        }

        public void SetRestriction(int siteNumber, bool restriction)
        {
            _userRegisterProfileDapperRepository.SetRestriction(siteNumber, restriction);
        }

        public async Task<IEnumerable<ProfileContact>> GetRestrictionAsync()
        {
            return await _userRegisterProfileDapperRepository.GetRestrictionAsync();
        }       
    }
}
