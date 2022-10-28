using Ishopping.Application.Common;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IUserRegisterProfileAppService : IAppServiceBaseT2<UserRegisterProfile>
    {
        BasicProfile GetBasicProfile(string userId); 
        UserRegisterProfile GetBySiteNumber(int siteNumber);
        UserRegisterProfile GetByUserId(string userId);
        JsonResponse AppUpdate(string userId, string SiteName, string Semantica1, string Semantica2, string Semantica3, string Semantica4, string Rua, string NumRua, string Distrito, string Cidade, string Estado, string CEP, string Telefone, string Telefone2, string WhatsApp, string Empresa, string Cnpj, string Email, string Website, double Latitude, double Longitude, string description);
        bool ExistProfile(string userId);
        GroupPlan GetPlan(string userId);
        void EmailQuantityClear();
        void SetSerialize(bool serialize, string userId);
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

        // Admin Methods
        void SetRestriction(int siteNumber, bool restriction);
        Task<IEnumerable<ProfileContact>> GetRestrictionAsync();
    }
}
