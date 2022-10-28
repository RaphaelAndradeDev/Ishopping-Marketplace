using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Domain.Services
{
    public class AdminSliderService : ServiceBase<AdminSlider>, IAdminSliderService
    {
        private readonly IAdminSliderRepository _adminSliderRepository;

        public AdminSliderService(IAdminSliderRepository adminSliderRepository)
            : base(adminSliderRepository)
        {
            _adminSliderRepository = adminSliderRepository;
        }

        public IEnumerable<AdminSlider> GetAllByViewCod(int viewCod)
        {
            return _adminSliderRepository.GetAllByViewCod(viewCod);
        }
        
        public IEnumerable<AdminSlider> GetAllByViewDataId(int viewDataId)
        {
            return _adminSliderRepository.GetAllByViewDataId(viewDataId);
        }
        
        public int[] GetAllSlideType(int viewCod)
        {
            return _adminSliderRepository.GetAllSlideType(viewCod);
        }

        public string[] GetAllSlideName(int viewCod, int slideType)
        {
            return _adminSliderRepository.GetAllSlideName(viewCod, slideType);
        }

        public string[] GetAllSlideClass(int viewCod, int slideType, string slideName)
        {
            return _adminSliderRepository.GetAllSlideClass(viewCod, slideType, slideName);
        }
    }
}
