using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Ishopping.Domain.Services
{
    public class AdminSliderConfigService : ServiceBase<AdminSliderConfig>, IAdminSliderConfigService
    {
        private readonly IAdminSliderConfigRepository _adminSliderConfigRepository;

        public AdminSliderConfigService(IAdminSliderConfigRepository adminSliderConfigRepository)
            : base(adminSliderConfigRepository)
        {
            _adminSliderConfigRepository = adminSliderConfigRepository;
        }

        public IEnumerable<AdminSliderConfig> GetAllByViewCod(int viewCod)
        {
            return _adminSliderConfigRepository.GetAllByViewCod(viewCod);
        }

        public IEnumerable<AdminSliderConfig> GetAllByViewDataId(int viewDataId)
        {
            return _adminSliderConfigRepository.GetAllByViewDataId(viewDataId);
        }
        
        public int[] GetAllSlideType(int viewCod)
        {
            return _adminSliderConfigRepository.GetAllSlideType(viewCod);
        }

        public string[] GetAllSlideName(int viewCod, int slideType)
        {
            return _adminSliderConfigRepository.GetAllSlideName(viewCod, slideType);
        }

        public string[] GetAllSlideClass(int viewCod, int slideType, string slideName)
        {
            return _adminSliderConfigRepository.GetAllSlideClass(viewCod, slideType, slideName);
        }
        
        public AdminSliderConfig GetBy(int viewCod, int slideType, string slideName, string slideClass)
        {
            return _adminSliderConfigRepository.GetBy(viewCod,slideType,slideName,slideClass);
        }
    }
}
