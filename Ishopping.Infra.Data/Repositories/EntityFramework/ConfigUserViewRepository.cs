using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class ConfigUserViewRepository : RepositoryBaseT2<ConfigUserView>, IConfigUserViewRepository
    {
        public IEnumerable<ConfigUserView> GetAllBy(bool active, string userId)
        {
            return db.ConfigUserView.Include("ConfigUserViewItem").Include("AdminViewData").Where(x => x.Active == active && x.IdUser == userId);
        }

        public IEnumerable<ConfigUserView> GetAllByUserId(string userId)
        {
            return db.ConfigUserView.Include("ConfigUserViewItem").Include("AdminViewData").Where(x => x.IdUser == userId);
        }
        
        public IEnumerable<ConfigUserView> GetAllBySiteNumber(int siteNumber)
        {
            return db.ConfigUserView.Include("ConfigUserViewItem").Include("AdminViewData").Where(x => x.SiteNumber == siteNumber);
        }
        
        public ConfigUserView GetById(string id, string userId)
        {
            return db.ConfigUserView.Include("ConfigUserViewItem").Include("AdminViewData").FirstOrDefault(b => b.IdUser == userId && b.Id.ToString() == id);
        }

        public void AddRanger(IEnumerable<ConfigUserView> configUserView)
        {
            db.ConfigUserView.AddRange(configUserView);
            db.SaveChanges();
        }
        
        public IEnumerable<int> GetAllViewCodByUserId(string userId)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.IdUser == userId).Select(x => x.AdminViewData.ViewCod);
        }

        public IEnumerable<int> GetAllViewCodBySiteNumber(int siteNumber)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.SiteNumber == siteNumber).Select(x => x.AdminViewData.ViewCod);
        }

        public IEnumerable<ListedViewUser> GetAllTextBy(bool active, string userId)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.Active == active && x.IdUser == userId)
                .Select(x => new ListedViewUser { ViewCod = x.AdminViewData.ViewCod, StringKey = x.AdminViewData.ListText, Text = x.TextMenu }).ToList(); 
        }
        
        public IEnumerable<ListedViewUser> GetAllVectorIconBy(bool active, string userId)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.Active == active && x.IdUser == userId)
                 .Select(x => new ListedViewUser { ViewCod = x.AdminViewData.ViewCod, StringKey = x.AdminViewData.ListVectorIcon, Text = x.TextMenu }).ToList(); 
        }

        public IEnumerable<ListedViewUser> GetAllNumButtonBy(bool active, string userId)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.Active == active && x.IdUser == userId)
                .Select(x => new ListedViewUser { ViewCod = x.AdminViewData.ViewCod, IntKey = x.AdminViewData.NumBtn, Text = x.TextMenu }).ToList(); 
        }

        public IEnumerable<ListedViewUser> GetAllListBy(bool active, string userId)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.Active == active && x.IdUser == userId)
                .Select(x => new ListedViewUser { ViewCod = x.AdminViewData.ViewCod, IntKey = x.AdminViewData.ListList, Text = x.TextMenu }).ToList(); 
        }

        public IEnumerable<ListedViewUser> GetAllNumVideoBy(bool active, string userId)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.Active == active && x.IdUser == userId)
                .Select(x => new ListedViewUser { ViewCod = x.AdminViewData.ViewCod, IntKey = x.AdminViewData.NumVideo, Text = x.TextMenu }).ToList(); 
        }

        public IEnumerable<ListedViewUser> GetAllViewsBy(bool active, string userId)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.Active == active && x.IdUser == userId)
                .Select(x => new ListedViewUser { ViewCod = x.AdminViewData.ViewCod, Text = x.TextMenu }).ToList();
        }

        public IEnumerable<GroupViewUser> GetAllViewsUser(string userId)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.IdUser == userId)
                .Select(x => new GroupViewUser { Id = x.Id.ToString(), ViewCod = x.AdminViewData.ViewCod, Active = x.Active, Text = x.TextMenu, Name = x.AdminViewData.ViewName, Tipo = x.AdminViewData.ViewTipo }).ToList();
        }
        
        public IEnumerable<ListedViewUser> GetAllViewTextMenu(bool active, string userId)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.Active == active && x.IdUser == userId)
                .Select(x => new ListedViewUser { ViewCod = x.AdminViewData.ViewCod, Text = x.TextMenu }).ToList();
        }

        public IEnumerable<string> GetAllControllerByUserId(string userId)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.IdUser == userId).Select(x => x.AdminViewData.Controller);
        }

        public IEnumerable<string> GetAllControllerBySiteNumber(int siteNumber)
        {
            return db.ConfigUserView.Include("AdminViewData").Where(x => x.SiteNumber == siteNumber).Select(x => x.AdminViewData.Controller);
        }
        
        public void DeleteAll(string userId)
        {
            var configUserView = db.ConfigUserView.Include("ConfigUserViewItem").Where(x => x.IdUser == userId).ToList();
            db.ConfigUserView.RemoveRange(configUserView);
        }
      
    }
}
