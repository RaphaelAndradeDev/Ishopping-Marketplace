using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class ConfigUserViewItemRepository : RepositoryBaseT2<ConfigUserViewItem>, IConfigUserViewItemRepository
    {
        public IEnumerable<ConfigUserViewItem> GetAllBySiteNumber(int siteNumber)
        {
            return db.ConfigUserViewItem.Include("ConfigUserView.AdminViewData").Include("AdminViewItem").Where(x => x.SiteNumber == siteNumber).ToList();
        }

        public bool ExistItem(string viewTipo, string userId)
        {
            return db.ConfigUserViewItem.Any(x => x.Active == true && x.AdminViewItem.ViewTipo == viewTipo && x.IdUser == userId);
        }

        public IEnumerable<ConfigUserViewItem> GetAllBy(int viewCod, string userId)
        {
            return db.ConfigUserViewItem.Include("ConfigUserView.AdminViewData").Include("AdminViewItem").Where(x => x.AdminViewItem.AdminViewData.ViewCod == viewCod && x.IdUser == userId);
        }
        
        public IEnumerable<GroupViewItem> GetAllUserViewItem(int viewCod, string userId)
        {
            return db.ConfigUserViewItem.Include("AdminViewItem").Where(x => x.AdminViewItem.AdminViewData.ViewCod == viewCod && x.IdUser == userId)
                .Select(x => new GroupViewItem { Id = x.Id.ToString(), Active = x.Active, TextMenu = x.TextMenu, AdmTextMenu = x.AdminViewItem.TextMenu, TextView = x.TextView, AdmTextView = x.AdminViewItem.TextView, ViewTipo = x.AdminViewItem.ViewTipo }).ToList();
        }            
        
        public ConfigUserViewItem GetBy(string viewTipo, string userId)
        {
            return db.ConfigUserViewItem.Include("ConfigUserView.AdminViewData").Include("AdminViewItem").FirstOrDefault(x => x.AdminViewItem.ViewTipo == viewTipo && x.IdUser == userId);
        }

        public ConfigUserViewItem GetBy(int viewTypeCod, string userId)
        {
            return db.ConfigUserViewItem.Include("ConfigUserView.AdminViewData").Include("AdminViewItem").FirstOrDefault(x => x.AdminViewItem.ViewTypeCod == viewTypeCod && x.IdUser == userId);
        }

        public ConfigUserViewItem GetBy(Guid id, string userId)
        {
            return db.ConfigUserViewItem.Include("ConfigUserView.AdminViewData").Include("AdminViewItem").FirstOrDefault(x => x.Id == id && x.IdUser == userId);
        }
        
        public IEnumerable<int> GetAllAdminViewItemCod(string userId)
        {
            return db.ConfigUserViewItem.Include("AdminViewItem").Where(x => x.Active && x.IdUser == userId).Select(x => x.AdminViewItem.ViewTypeCod).ToList();
        }

        public IEnumerable<ConfigUserViewItem> GetAllByUserId(string userId)
        {
            return db.ConfigUserViewItem.Include("ConfigUserView.AdminViewData").Include("AdminViewItem").Where(x => x.IdUser == userId);           
        }

   
    }
}
