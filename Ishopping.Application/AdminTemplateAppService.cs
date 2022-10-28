using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;

namespace Ishopping.Application
{
    public class AdminTemplateAppService : AppServiceBase<AdminTemplate>, IAdminTemplateAppService
    {
        private readonly IAdminTemplateService _adminTemplateService;

        public AdminTemplateAppService(IAdminTemplateService adminTemplateService)
            :base(adminTemplateService)
        {
            _adminTemplateService = adminTemplateService;
        }

        public AdminTemplate GetByTemplateCod(int templateCod)
        {
            return _adminTemplateService.GetByTemplateCod(templateCod);
        }
        
        public IEnumerable<AdminTemplate> GetAllByGroup(int group)
        {
            return _adminTemplateService.GetAllByGroup(group);
        }
        
        public string GetTemplateName(int templateCod)
        {
            return _adminTemplateService.GetTemplateName(templateCod);
        }

        public string GetCssPath(int templateCod)
        {
            return _adminTemplateService.GetCssPath(templateCod);
        }

        public IEnumerable<KeyValue> GetAllName(int group)
        {
            return _adminTemplateService.GetAllName(group);
        }       
     
    }
}
