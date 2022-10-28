using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IAdminTemplateRepository : IRepositoryBase<AdminTemplate>
    {
        AdminTemplate GetByTemplateCod(int templateCod);
        AdminTemplate GetByViewCod(int viewCod);
        IEnumerable<AdminTemplate> GetAllByGroup(int group);
        IEnumerable<KeyValue> GetAllName(int group);
        string GetCssPath(int templateCod);
        string GetTemplateName(int templateCod);
    }
}
