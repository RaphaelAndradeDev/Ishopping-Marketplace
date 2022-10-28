using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Application.Interface
{
    public interface IConfigUserViewAppService : IAppServiceBaseT2<ConfigUserView>
    {
        void AddRanger(IEnumerable<ConfigUserView> configUserView);
        IEnumerable<ConfigUserView> GetAllByUserId(string userId);
        IEnumerable<ConfigUserView> GetAllBySiteNumber(int siteNumber);
        ConfigUserView GetById(string id, string userId);
        IEnumerable<int> GetViewCodByUserId(string userId);
        IEnumerable<int> GetViewCodBySiteNumber(int siteNumber);
        IEnumerable<string> GetAllControllerByUserId(string userId);
        IEnumerable<string> GetAllControllerBySiteNumber(int siteNumber);
        IEnumerable<ConfigUserView> GetAllBy(bool active, string userId);
        IEnumerable<ListedViewUser> GetViewTextMenu(bool active, string userId);
        IEnumerable<ListedViewUser> GetAllTextBy(bool active, string userId);
        IEnumerable<ListedViewUser> GetAllVectorIconBy(bool active, string userId);
        IEnumerable<ListedViewUser> GetAllNumButtonBy(bool active, string userId);
        IEnumerable<ListedViewUser> GeAllListBy(bool active, string userId);
        IEnumerable<ListedViewUser> GetAllNumVideoBy(bool active, string userId);
        IEnumerable<ListedViewUser> GetAllViewsBy(bool active, string userId);
        IEnumerable<GroupViewUser> GetAllViewsUser(string userId);
        void DeleteAll(string userId);
    }
}
