using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class UserRegisterProfileAppService : AppServiceBaseT2<UserRegisterProfile>, IUserRegisterProfileAppService
    {
        private readonly IConfigUserDisplayAppService _configUserDisplayAppService;
        private readonly IUserRegisterProfileService _userRegisterProfileService;

        public UserRegisterProfileAppService(
            IUserRegisterProfileService userRegisterProfileService,
            IConfigUserDisplayAppService configUserDisplayAppService)
            :base(userRegisterProfileService)
        {
            _configUserDisplayAppService = configUserDisplayAppService;
            _userRegisterProfileService = userRegisterProfileService;
        }


        public BasicProfile GetBasicProfile(string userId)
        {
            return _userRegisterProfileService.GetBasicProfile(userId);
        }

        public UserRegisterProfile GetBySiteNumber(int siteNumber)
        {
            return _userRegisterProfileService.GetBySiteNumber(siteNumber);
        }

        public UserRegisterProfile GetByUserId(string userId)
        {
            return _userRegisterProfileService.GetByUserId(userId);
        }               

        public void EmailQuantityClear()
        {
            _userRegisterProfileService.EmailQuantityClear();
        }

        public bool ExistProfile(string userId)
        {
            return _userRegisterProfileService.ExistProfile(userId);
        }

        public GroupPlan GetPlan(string userId)
        {
            return _userRegisterProfileService.GetPlan(userId);
        }

        public void SetSerialize(bool serialize, string userId)
        {
            _userRegisterProfileService.SetSerialize(serialize, userId);
        }

        public void SetProfileServices(ServicesProfile servicesProfile)
        {
            _userRegisterProfileService.SetProfileServices(servicesProfile);
        }

        public bool ExistSiteNumber(int siteNumber, string userId)
        {
            return _userRegisterProfileService.ExistSiteNumber(siteNumber, userId);
        }

        public bool ExistSiteName(string siteName, string userId)
        {
            return _userRegisterProfileService.ExistSiteName(siteName, userId);
        }

        public bool ExistCnpj(string cnpj, string userId)
        {
            return _userRegisterProfileService.ExistCnpj(cnpj, userId);
        }

        public bool ExistEmail(string email, string userId)
        {
            return _userRegisterProfileService.ExistEmail(email, userId);
        }

        public bool ExistEmpresa(string empresa, string userId)
        {
            return _userRegisterProfileService.ExistEmpresa(empresa, userId);
        }

        public bool ExistWebsite(string website, string userId)
        {
            return _userRegisterProfileService.ExistWebsite(website, userId);
        }

        public void DeleteProfileExtension(string userId)
        {
            _userRegisterProfileService.DeleteProfileExtension(userId);
        }

        public JsonResponse AppUpdate(string userId, string SiteName, string Semantica1, string Semantica2, string Semantica3, string Semantica4, string Rua, string NumRua, string Distrito, string Cidade, string Estado, string CEP, string Telefone, string Telefone2, string WhatsApp, string Empresa, string Cnpj, string Email, string Website, double Latitude, double Longitude, string description)
        {
            var profile = _userRegisterProfileService.GetByUserId(userId);
            profile.Chage(SiteName, Semantica1, Semantica2, Semantica3, Semantica4, Rua, NumRua, Distrito, Cidade, Estado, CEP, Telefone, Telefone2, WhatsApp, Empresa, Cnpj, Email, Website, Latitude, Longitude, message:description);
            _configUserDisplayAppService.ConfigUserDisplayProfileUpdate(profile);
            _userRegisterProfileService.Update(profile);

            return new JsonResponse();
        }


        // Async Methods
        public async Task<UserRegisterProfile> GetBySiteNumberAsync(int siteNumber)
        {
            return await _userRegisterProfileService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<UserRegisterProfile> GetByUserIdAsync(string userId)
        {
            return await _userRegisterProfileService.GetByUserIdAsync(userId);
        }

        public async Task<BasicProfile> GetBasicProfileAsync(string userId)
        {
            return await _userRegisterProfileService.GetBasicProfileAsync(userId);
        }

        public async Task<ServicesProfile> GetProfileServicesAsync(int siteNumber)
        {
            return await _userRegisterProfileService.GetProfileServicesAsync(siteNumber);
        }

        // Admin Methods
        public async Task<IEnumerable<ProfileContact>> GetRestrictionAsync()
        {
            return await _userRegisterProfileService.GetRestrictionAsync();
        }
                
        public void SetRestriction(int siteNumber, bool restriction)
        {
            _userRegisterProfileService.SetRestriction(siteNumber, restriction);
        }
    }
}
