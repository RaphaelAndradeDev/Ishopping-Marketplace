using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Domain.Services
{
    public class AdminSocialNetWorkService : ServiceBase<AdminSocialNetWork>, IAdminSocialNetWorkService
    {
        private readonly IAdminSocialNetWorkRepository _adminSocialNetWorkRepository;

        public AdminSocialNetWorkService(IAdminSocialNetWorkRepository adminSocialNetWorkRepository)
            : base(adminSocialNetWorkRepository)
        {
            _adminSocialNetWorkRepository = adminSocialNetWorkRepository;
        }

        public AdminSocialNetWork GetBy(string rede, int templateCod)
        {
            return _adminSocialNetWorkRepository.GetBy(rede, templateCod);
        }
        
        public IEnumerable<AdminSocialNetWork> GetAllByTemplateId(int templateId)
        {
            return _adminSocialNetWorkRepository.GetAllByTemplateId(templateId);
        }
        
        public IEnumerable<string> GetAllRedeByTemplateCod(int templateCod)
        {
            return _adminSocialNetWorkRepository.GetAllRedeByTemplateCod(templateCod);
        }
    }
}
