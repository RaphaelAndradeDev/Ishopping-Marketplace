using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Domain.Services
{
    public class AdminTemplateService : ServiceBase<AdminTemplate>, IAdminTemplateService
    {
        private readonly IAdminTemplateRepository _adminTemplateRepository;

        public AdminTemplateService(IAdminTemplateRepository adminTemplateRepository)
            : base(adminTemplateRepository)
        {
            _adminTemplateRepository = adminTemplateRepository;
        }

        public AdminTemplate GetByTemplateCod(int templateCod)
        {
            return _adminTemplateRepository.GetByTemplateCod(templateCod);
        }

        public AdminTemplate GetByViewCod(int viewCod)
        {
            return _adminTemplateRepository.GetByTemplateCod(viewCod);
        }
        
        public IEnumerable<AdminTemplate> GetAllByGroup(int group)
        {
            return _adminTemplateRepository.GetAllByGroup(group);
        }
        
        public string GetTemplateName(int templateCod)
        {
            return _adminTemplateRepository.GetTemplateName(templateCod);
        }

        public IEnumerable<KeyValue> GetAllName(int group)
        {
            return _adminTemplateRepository.GetAllName(group);
        }
        
        public string GetCssPath(int templateCod)
        {
            return _adminTemplateRepository.GetCssPath(templateCod);
        }
    }
}
