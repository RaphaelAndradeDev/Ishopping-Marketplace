using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Application
{
    public class ConfigUserViewAppService : AppServiceBaseT2<ConfigUserView>, IConfigUserViewAppService
    {
        private readonly IConfigUserViewService _configUserViewService;

        public ConfigUserViewAppService(IConfigUserViewService configUserViewService)
            :base(configUserViewService)
        {
            _configUserViewService = configUserViewService;
        }              

        IEnumerable<ConfigUserView> IConfigUserViewAppService.GetAllBy(bool active, string userId)
        {
            return _configUserViewService.GetAllBy(active, userId);
        }

        public IEnumerable<ConfigUserView> GetAllByUserId(string userId)
        {
            return _configUserViewService.GetAllByUserId(userId);
        }
        
        public IEnumerable<ConfigUserView> GetAllBySiteNumber(int siteNumber)
        {
            return _configUserViewService.GetAllBySiteNumber(siteNumber);
        }
        
        public ConfigUserView GetById(string id, string userId)
        {
            return _configUserViewService.GetById(id, userId);
        }

        public void AddRanger(IEnumerable<ConfigUserView> configUserView)
        {
            _configUserViewService.AddRanger(configUserView);
        }
        
        public IEnumerable<int> GetViewCodByUserId(string userId)
        {
            return _configUserViewService.GetAllViewCodByUserId(userId);
        }

        public IEnumerable<int> GetViewCodBySiteNumber(int siteNumber)
        {
            return _configUserViewService.GetAllViewCodBySiteNumber(siteNumber);
        }

        public IEnumerable<ListedViewUser> GetAllTextBy(bool active, string userId)
        {
            return _configUserViewService.GetAllTextBy(active, userId);
        }

        public IEnumerable<ListedViewUser> GetAllVectorIconBy(bool active, string userId)
        {
            return _configUserViewService.GetAllVectorIconBy(active, userId);
        }

        public IEnumerable<ListedViewUser> GetAllNumButtonBy(bool active, string userId)
        {
            return _configUserViewService.GetAllNumButtonBy(active, userId);
        }

        public IEnumerable<ListedViewUser> GeAllListBy(bool active, string userId)
        {
            return _configUserViewService.GetAllListBy(active, userId);
        }

        public IEnumerable<ListedViewUser> GetAllNumVideoBy(bool active, string userId)
        {
            return _configUserViewService.GetAllNumVideoBy(active, userId);
        }

        public IEnumerable<ListedViewUser> GetAllViewsBy(bool active, string userId)
        {
            return _configUserViewService.GetAllViewsBy(active, userId);
        }

        public IEnumerable<GroupViewUser> GetAllViewsUser(string userId)
        {
            return _configUserViewService.GetAllViewsUser(userId);
        }
        
        public IEnumerable<ListedViewUser> GetViewTextMenu(bool active, string userId)
        {
            return _configUserViewService.GetAllViewTextMenu(active, userId);
        }
        
        public void DeleteAll(string userId)
        {
            _configUserViewService.DeleteAll(userId);
        }

        public IEnumerable<string> GetAllControllerByUserId(string userId)
        {
            return _configUserViewService.GetAllControllerByUserId(userId);
        }

        public IEnumerable<string> GetAllControllerBySiteNumber(int siteNumber)
        {
            return _configUserViewService.GetAllControllerBySiteNumber(siteNumber);
        }
    }
}
