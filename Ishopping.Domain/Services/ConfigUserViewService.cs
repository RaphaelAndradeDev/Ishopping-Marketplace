using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Domain.Services
{
    public class ConfigUserViewService : ServiceBaseT2<ConfigUserView>, IConfigUserViewService
    {
        private readonly IConfigUserViewRepository _configUserViewRepository;

        public ConfigUserViewService(IConfigUserViewRepository configUserViewRepository)
            : base(configUserViewRepository)
        {
            _configUserViewRepository = configUserViewRepository;
        }

        IEnumerable<ConfigUserView> IConfigUserViewService.GetAllBy(bool active, string userId)
        {
            return _configUserViewRepository.GetAllBy(active, userId);
        }

        public IEnumerable<ConfigUserView> GetAllByUserId(string userId)
        {
            return _configUserViewRepository.GetAllByUserId(userId);
        }
        
        public IEnumerable<ConfigUserView> GetAllBySiteNumber(int siteNumber)
        {
            return _configUserViewRepository.GetAllBySiteNumber(siteNumber);
        }
        
        public ConfigUserView GetById(string id, string userId)
        {
            return _configUserViewRepository.GetById(id, userId);
        }

        public void AddRanger(IEnumerable<ConfigUserView> configUserView)
        {
            _configUserViewRepository.AddRanger(configUserView);
        }

        public IEnumerable<int> GetAllViewCodByUserId(string userId)
        {
            return _configUserViewRepository.GetAllViewCodByUserId(userId);
        }

        public IEnumerable<int> GetAllViewCodBySiteNumber(int siteNumber)
        {
            return _configUserViewRepository.GetAllViewCodBySiteNumber(siteNumber);
        }

        public IEnumerable<ListedViewUser> GetAllTextBy(bool active, string userId)
        {
            return AddTextToAppViews(_configUserViewRepository.GetAllTextBy(active, userId).ToList()); //
        }

        public IEnumerable<ListedViewUser> GetAllVectorIconBy(bool active, string userId)
        {
            return _configUserViewRepository.GetAllVectorIconBy(active, userId);
        }

        public IEnumerable<ListedViewUser> GetAllNumButtonBy(bool active, string userId)
        {
            return _configUserViewRepository.GetAllNumButtonBy(active, userId);
        }

        public IEnumerable<ListedViewUser> GetAllListBy(bool active, string userId)
        {
            return _configUserViewRepository.GetAllListBy(active, userId);
        }

        public IEnumerable<ListedViewUser> GetAllNumVideoBy(bool active, string userId)
        {
            return _configUserViewRepository.GetAllNumVideoBy(active, userId);
        }

        public IEnumerable<ListedViewUser> GetAllViewsBy(bool active, string userId)
        {
            return AddViewsToAppViews(_configUserViewRepository.GetAllViewsBy(active, userId).ToList());
        }
        
        public IEnumerable<GroupViewUser> GetAllViewsUser(string userId)
        {
            return _configUserViewRepository.GetAllViewsUser(userId);
        }
        
        public IEnumerable<ListedViewUser> GetAllViewTextMenu(bool active, string userId)
        {
            return _configUserViewRepository.GetAllViewTextMenu(active, userId);
        }
        
        public void DeleteAll(string userId)
        {
            _configUserViewRepository.DeleteAll(userId);
        }


        public IEnumerable<string> GetAllControllerByUserId(string userId)
        {
            return _configUserViewRepository.GetAllControllerByUserId(userId);
        }

        public IEnumerable<string> GetAllControllerBySiteNumber(int siteNumber)
        {
            return _configUserViewRepository.GetAllControllerBySiteNumber(siteNumber);
        }


        // Private Methods
        private IEnumerable<ListedViewUser> AddTextToAppViews(List<ListedViewUser> listedViewUsers)
        {
            listedViewUsers.Add(new ListedViewUser() { IntKey = 0, StringKey = "1,2,1,1,1,1,2", Text = "Portfolio", ViewCod = 1111 });
            listedViewUsers.Add(new ListedViewUser() { IntKey = 0, StringKey = "1,1,1,1,1", Text = "Loja", ViewCod = 1112 });
            return listedViewUsers;
        }

        private IEnumerable<ListedViewUser> AddButtonToAppViews(List<ListedViewUser> listedViewUsers)
        {
            listedViewUsers.Add(new ListedViewUser() { IntKey = 2, StringKey = "", Text = "Portfolio", ViewCod = 1111 });
            listedViewUsers.Add(new ListedViewUser() { IntKey = 2, StringKey = "", Text = "", ViewCod = 1112 });
            return listedViewUsers;
        }

        private IEnumerable<ListedViewUser> AddViewsToAppViews(List<ListedViewUser> listedViewUsers)
        {
            listedViewUsers.Add(new ListedViewUser() { IntKey = 0, StringKey = "", Text = "Portfolio", ViewCod = 1111 });
            listedViewUsers.Add(new ListedViewUser() { IntKey = 0, StringKey = "", Text = "Loja", ViewCod = 1112 });
            return listedViewUsers;
        }
    }
}
