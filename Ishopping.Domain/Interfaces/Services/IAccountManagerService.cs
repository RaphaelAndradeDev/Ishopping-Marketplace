
using Ishopping.Domain.Entities;
using System.Collections.Generic;
namespace Ishopping.Domain.Interfaces.Services
{
    public interface IAccountManagerService
    {
        void AddProfile(UserRegisterProfile userRegisterProfile);
        void AddProfileExtension(UserRegisterProfile userRegisterProfile, int? oldTemplateCod, string[] cssPath);
        void SetApplication(UserRegisterProfile userRegisterProfile);
        void ProfileViewUpdate(string userId, string id, int viewCod, bool ativo, string textMenu);
        void ProfileViewItemUpdate(string userId, string configUserViewItemId, bool ativo, string textMenu, string textView);
        void DeleteProfileExtension(string userId, int newTemplateCod);
    }
}
