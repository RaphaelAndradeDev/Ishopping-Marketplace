using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IAdminViewDataService : IServiceBase<AdminViewData>
    {
        AdminViewData GetByViewCod(int viewCod);
        AdminViewData GetByTemplateId(int templateId);
        string GetControllerByViewCod(int viewCod);
        IEnumerable<string> GetAllControllerByViewCod(IEnumerable<int> viewCod); 
        IEnumerable<AdminViewData> GetAllByTemplateCod(int templateCod);
        IEnumerable<AdminViewData> GetAllByTemplateId(int templateId);
        IEnumerable<ListedViewUser> GetListViewByTemplateCod(int templateCod);
        string GetViewName(int viewCod);

        // Async Methods
        Task<AdminViewData> GetByViewCodAsync(int viewCod);
        Task<AdminViewData> GetListImageAsync(int templateCod, int viewCod);
    }
}
