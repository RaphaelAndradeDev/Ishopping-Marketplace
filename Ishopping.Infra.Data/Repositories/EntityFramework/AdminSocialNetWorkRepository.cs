using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class AdminSocialNetWorkRepository : RepositoryBase<AdminSocialNetWork>, IAdminSocialNetWorkRepository
    {
        public AdminSocialNetWork GetBy(string rede, int templateCod)
        {
            return db.AdminSocialNetWork.Include("AdminTemplate").FirstOrDefault(t => t.Rede == rede && t.AdminTemplate.TemplateCod == templateCod);
        }
        
        public IEnumerable<AdminSocialNetWork> GetAllByTemplateId(int templateId)
        {
            return db.AdminSocialNetWork.Include("AdminTemplate").Where(x => x.AdminTemplateId == templateId);
        }
        
        public IEnumerable<string> GetAllRedeByTemplateCod(int templateCod)
        {
            return db.AdminSocialNetWork.Where(x => x.AdminTemplate.TemplateCod == templateCod).Select(x => x.Rede);
        }
    }
}
