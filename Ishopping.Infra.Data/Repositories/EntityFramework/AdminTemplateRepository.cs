using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Data.Entity;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class AdminTemplateRepository : RepositoryBase<AdminTemplate>, IAdminTemplateRepository
    {
        public AdminTemplate GetByTemplateCod(int templateCod)
        {
            return db.AdminTemplate              
                .FirstOrDefault(x => x.TemplateCod == templateCod);
        }

        public AdminTemplate GetByViewCod(int viewCod)
        {
            return db.AdminTemplate    
                .FirstOrDefault(x => x.AdminViewData.Any(y => y.ViewCod == viewCod));
        }
        
        public IEnumerable<AdminTemplate> GetAllByGroup(int group)
        {           
            return db.AdminTemplate          
                .Where(x => x.Group == group);     
        }

        public IEnumerable<KeyValue> GetAllName(int group)
        {
            return db.AdminTemplate.Where(x => x.Group == group).Select(x => new KeyValue { Key = x.TemplateCod, Value = x.Name });
        }

        public string GetCssPath(int templateCod)
        {
            return db.AdminTemplate.First(x => x.TemplateCod == templateCod).CssPath;
        }

        public string GetTemplateName(int templateCod)
        {
            return db.AdminTemplate.First(x => x.TemplateCod == templateCod).Name;
        }
    }
}
