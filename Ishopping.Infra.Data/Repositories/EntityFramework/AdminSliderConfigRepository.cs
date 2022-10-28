using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class AdminSliderConfigRepository : RepositoryBase<AdminSliderConfig>, IAdminSliderConfigRepository
    {
        public IEnumerable<AdminSliderConfig> GetAllByViewCod(int viewCod)
        {
            return db.AdminSliderConfig.Include("AdminViewData").Where(x => x.AdminViewData.ViewCod == viewCod);
        }

        public IEnumerable<AdminSliderConfig> GetAllByViewDataId(int viewDataId)
        {
            return db.AdminSliderConfig.Include("AdminViewData").Where(x => x.AdminViewDataId == viewDataId);
        }
        
        public int[] GetAllSlideType(int viewCod)
        {
            return db.AdminSliderConfig.Where(x => x.AdminViewData.ViewCod == viewCod).Select(x => x.SliderType).Distinct().ToArray();
        }

        public string[] GetAllSlideName(int viewCod, int slideType)
        {
            return db.AdminSliderConfig.Where(x => x.AdminViewData.ViewCod == viewCod && x.SliderType == slideType).Select(x => x.SliderName).Distinct().ToArray();
        }

        public string[] GetAllSlideClass(int viewCod, int slideType, string slideName)
        {
            return db.AdminSliderConfig.Where(x => x.AdminViewData.ViewCod == viewCod && x.SliderType == slideType && x.SliderName == slideName).Select(x => x.SliderClass).Distinct().ToArray();
        }
        
        public AdminSliderConfig GetBy(int viewCod, int slideType, string slideName, string slideClass)
        {
            return db.AdminSliderConfig.First(x => x.AdminViewData.ViewCod == viewCod && x.SliderType == slideType && x.SliderName == slideName && x.SliderClass == slideClass);
        }
    }
}
