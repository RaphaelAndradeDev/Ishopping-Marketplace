using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class AdminViewDataRepository : RepositoryBase<AdminViewData>, IAdminViewDataRepository
    {
        public AdminViewData GetByViewCod(int viewCod)
        {
            return db.AdminViewData
                .Include("AdminViewItem")
                .Include("AdminSlider")
                .Include("AdminSliderConfig")
                .First(x => x.ViewCod == viewCod);
        }

        public IEnumerable<AdminViewData> GetAllByTemplateCod(int templateCod)
        {
            return db.AdminViewData               
                .Include("AdminViewItem")
                .Include("AdminSlider")
                .Include("AdminSliderConfig")
                .Where(x => x.AdminTemplate.TemplateCod == templateCod);
        }
        
        public string GetControllerByViewCod(int viewCod)
        {
            return db.AdminViewData.First(x => x.ViewCod == viewCod).Controller;  
        }

        public IEnumerable<string> GetAllControllerByViewCod(IEnumerable<int> viewCod)
        {
            return db.AdminViewData.Where(x => viewCod.Contains(x.ViewCod)).Select(x => x.Controller);
        }
        
        public AdminViewData GetByTemplateId(int templateId)
        {
            return db.AdminViewData
                .Include("AdminViewItem")
                .Include("AdminSlider")
                .Include("AdminSliderConfig")
                .FirstOrDefault(x => x.AdminTemplateId == templateId);
        }
        
        public IEnumerable<AdminViewData> GetAllByTemplateId(int templateId)
        {
            return db.AdminViewData
                .Include("AdminViewItem")
                .Include("AdminSlider")
                .Include("AdminSliderConfig")
                .Where(x => x.AdminTemplateId == templateId);
        }
        
        public IEnumerable<ListedViewUser> GetListViewByTemplateCod(int templateCod)
        {
            return db.AdminViewData.Where(x => x.AdminTemplate.TemplateCod == templateCod)
                .Select(x => new ListedViewUser { ViewCod = x.ViewCod, StringKey = x.ViewTipo, Text = x.ViewName }).ToList();
        }
        
        public string GetViewName(int viewCod)
        {
            return db.AdminViewData.First(x => x.ViewCod == viewCod).ViewName;
        }        
       
    }
}
