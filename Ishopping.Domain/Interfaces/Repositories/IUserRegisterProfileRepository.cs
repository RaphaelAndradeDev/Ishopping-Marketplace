using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IUserRegisterProfileRepository : IRepositoryBaseT2<UserRegisterProfile>
    {
        UserRegisterProfile GetBySiteNumber(int siteNumber);
        UserRegisterProfile GetByUserId(string userId);
        bool ExistProfile(string userId);
        GroupPlan GetPlan(string userId);
        void SetSerialize(bool serialize, string userId);
        bool ExistSiteNumber(int siteNumber, string userId);
        bool ExistSiteName(string siteName, string userId);
        bool ExistCnpj(string cnpj, string userId);
        bool ExistEmail(string email, string userId);
        bool ExistEmpresa(string empresa, string userId);
        bool ExistWebsite(string website, string userId);
        void DeleteProfileExtension(string userId);       
    }
}
