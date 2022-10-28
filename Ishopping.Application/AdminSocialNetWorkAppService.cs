using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Application
{
    public class AdminSocialNetWorkAppService : AppServiceBase<AdminSocialNetWork>, IAdminSocialNetWorkAppService
    {
        private readonly IAdminSocialNetWorkService _adminSocialNetWorkService;

        public AdminSocialNetWorkAppService(IAdminSocialNetWorkService adminSocialNetWorkService)
            :base(adminSocialNetWorkService)
        {
            _adminSocialNetWorkService = adminSocialNetWorkService;
        }

        public AdminSocialNetWork GetBy(string rede, int templateCod)
        {
            return _adminSocialNetWorkService.GetBy(rede, templateCod);
        }
        
        public IEnumerable<AdminSocialNetWork> GetAllByTemplateId(int templateId)
        {
            return _adminSocialNetWorkService.GetAllByTemplateId(templateId);
        }
    }
}
