using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Application
{
    public class AdminSliderAppService : AppServiceBase<AdminSlider>, IAdminSliderAppService
    {
        private readonly IAdminSliderService _adminSliderService;

        public AdminSliderAppService(IAdminSliderService adminSliderService)
            :base(adminSliderService)
        {
            _adminSliderService = adminSliderService;
        }

        public IEnumerable<AdminSlider> GetAllByViewCod(int viewCod)
        {
            return _adminSliderService.GetAllByViewCod(viewCod);
        }

        public IEnumerable<AdminSlider> GetAllByViewDataId(int viewDataId)
        {
            return _adminSliderService.GetAllByViewDataId(viewDataId);
        }
        
        public int[] GetAllSlideType(int viewCod)
        {
            return _adminSliderService.GetAllSlideType(viewCod);
        }

        public string[] GetAllSlideName(int viewCod, int slideType)
        {
            return _adminSliderService.GetAllSlideName(viewCod, slideType);
        }

        public string[] GetAllSlideClass(int viewCod, int slideType, string slideName)
        {
            return _adminSliderService.GetAllSlideClass(viewCod, slideType, slideName);
        }
    }
}
