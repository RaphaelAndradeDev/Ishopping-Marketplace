using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class AdminViewDataService : ServiceBase<AdminViewData>, IAdminViewDataService
    {
        private readonly IAdminViewDataRepository _adminViewDataRepository;
        private readonly IAdminViewDataDapperRepository _adminViewDataDapperRepository;

        public AdminViewDataService(
            IAdminViewDataRepository adminViewDataRepository,
            IAdminViewDataDapperRepository adminViewDataDapperRepository)
            : base(adminViewDataRepository)
        {
            _adminViewDataRepository = adminViewDataRepository;
            _adminViewDataDapperRepository = adminViewDataDapperRepository;
        }

        public AdminViewData GetByViewCod(int viewCod)
        {
            return _adminViewDataDapperRepository.GetByViewCod(viewCod);
        }

        public IEnumerable<AdminViewData> GetAllByTemplateCod(int templateCod)
        {
            return _adminViewDataRepository.GetAllByTemplateCod(templateCod);
        }
        
        public string GetControllerByViewCod(int viewCod)
        {
            return _adminViewDataRepository.GetControllerByViewCod(viewCod);
        }

        public AdminViewData GetByTemplateId(int templateId)
        {
            return _adminViewDataRepository.GetByTemplateId(templateId);
        }
        
        public IEnumerable<AdminViewData> GetAllByTemplateId(int templateId)
        {
            return _adminViewDataRepository.GetAllByTemplateId(templateId);
        }
        
        public IEnumerable<ListedViewUser> GetListViewByTemplateCod(int templateCod)
        {
            return _adminViewDataRepository.GetListViewByTemplateCod(templateCod);
        }
        
        public string GetViewName(int viewCod)
        {
            return _adminViewDataRepository.GetViewName(viewCod);
        }
        
        public IEnumerable<string> GetAllControllerByViewCod(IEnumerable<int> viewCod)
        {
            return _adminViewDataRepository.GetAllControllerByViewCod(viewCod);
        }


        // Async Methods
        public async Task<AdminViewData> GetByViewCodAsync(int viewCod)
        {
            return await _adminViewDataDapperRepository.GetByViewCodAsync(viewCod);
        }

        public async Task<AdminViewData> GetListImageAsync(int templateCod, int viewCod)
        {
            return await _adminViewDataDapperRepository.GetListImageAsync(templateCod, viewCod);
        }        
    
    }
}
