using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Application
{
    public class AdminSliderConfigAppService : AppServiceBase<AdminSliderConfig>, IAdminSliderConfigAppService
    {
        private readonly IAdminSliderConfigService _adminSliderConfigService;

        public AdminSliderConfigAppService(IAdminSliderConfigService adminSliderConfigService)
            :base(adminSliderConfigService)
        {
            _adminSliderConfigService = adminSliderConfigService;
        }

        public IEnumerable<AdminSliderConfig> GetAllByViewCod(int viewCod)
        {
            return _adminSliderConfigService.GetAllByViewCod(viewCod);
        }

        public IEnumerable<AdminSliderConfig> GetAllByViewDataId(int viewDataId)
        {
            return _adminSliderConfigService.GetAllByViewDataId(viewDataId);
        }
        
        public int[] GetAllSlideType(int viewCod)
        {
            return _adminSliderConfigService.GetAllSlideType(viewCod);
        }

        public string[] GetAllSlideName(int viewCod, int slideType)
        {
            return _adminSliderConfigService.GetAllSlideName(viewCod, slideType);
        }

        public string[] GetAllSlideClass(int viewCod, int slideType, string slideName)
        {
            return _adminSliderConfigService.GetAllSlideClass(viewCod, slideType, slideName);
        }
        
        public AdminSliderConfig GetBy(int viewCod, int slideType, string slideName, string slideClass)
        {
            return _adminSliderConfigService.GetBy(viewCod, slideType, slideName, slideClass);
        }
    }
}
