using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Application.Interface
{
    public interface IAdminViewDataAppService : IAppServiceBase<AdminViewData>
    {
        AdminViewData GetByViewCod(int viewCod);
        AdminViewData GetByTemplateId(int templateId);
        string GetControllerByViewCod(int viewCod);
        IEnumerable<string> GetAllControllerByViewCod(IEnumerable<int> viewCod); 
        IEnumerable<AdminViewData> GetAllByTemplateCod(int templateCod);
        IEnumerable<AdminViewData> GetAllByTemplateId(int templateId);
        IEnumerable<ListedViewUser> GetListViewByTemplateCod(int templateCod);
        string GetViewName(int viewCod);
    }
}
