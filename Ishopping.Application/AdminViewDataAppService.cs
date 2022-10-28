using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Application
{
    public class AdminViewDataAppService : AppServiceBase<AdminViewData>, IAdminViewDataAppService
    {
        private readonly IAdminViewDataService _adminViewDataService;

        public AdminViewDataAppService(IAdminViewDataService adminViewDataService)
            :base(adminViewDataService)
        {
            _adminViewDataService = adminViewDataService;
        }

        public AdminViewData GetByViewCod(int viewCod)
        {
            return _adminViewDataService.GetByViewCod(viewCod);
        }

        public IEnumerable<AdminViewData> GetAllByTemplateCod(int templateCod)
        {
            return _adminViewDataService.GetAllByTemplateCod(templateCod);
        }

        public string GetControllerByViewCod(int viewCod)
        {
            return _adminViewDataService.GetControllerByViewCod(viewCod);
        }

        public IEnumerable<string> GetAllControllerByViewCod(IEnumerable<int> viewCod)
        {
            return _adminViewDataService.GetAllControllerByViewCod(viewCod);
        }
        
        public AdminViewData GetByTemplateId(int templateId)
        {
            return _adminViewDataService.GetByTemplateId(templateId);
        }
        
        public IEnumerable<AdminViewData> GetAllByTemplateId(int templateId)
        {
            return _adminViewDataService.GetAllByTemplateId(templateId);
        }
        
        public IEnumerable<ListedViewUser> GetListViewByTemplateCod(int templateCod)
        {
            return _adminViewDataService.GetListViewByTemplateCod(templateCod);
        }
        
        public string GetViewName(int viewCod)
        {
            return _adminViewDataService.GetViewName(viewCod);
        }        
      
    }
}
