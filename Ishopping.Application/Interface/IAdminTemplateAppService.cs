using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Application.Interface
{
    public interface IAdminTemplateAppService : IAppServiceBase<AdminTemplate>
    {
        AdminTemplate GetByTemplateCod(int templateCod);
        IEnumerable<AdminTemplate> GetAllByGroup(int group);
        IEnumerable<KeyValue> GetAllName(int group);
        string GetCssPath(int templateCod);
        string GetTemplateName(int templateCod);
    }
}
