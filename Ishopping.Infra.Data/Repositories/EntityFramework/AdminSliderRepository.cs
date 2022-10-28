using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class AdminSliderRepository : RepositoryBase<AdminSlider>, IAdminSliderRepository
    {
        public IEnumerable<AdminSlider> GetAllByViewCod(int viewCod)
        {
            return db.AdminSlider.Include("AdminViewData").Where(x => x.AdminViewData.ViewCod == viewCod);
        }
        
        public IEnumerable<AdminSlider> GetAllByViewDataId(int viewDataId)
        {
            return db.AdminSlider.Include("AdminViewData").Where(x => x.AdminViewDataId == viewDataId);
        }
        
        public int[] GetAllSlideType(int viewCod)
        {
            return db.AdminSlider.Where(x => x.AdminViewData.ViewCod == viewCod).Select(x => x.SliderType).ToArray();
        }

        public string[] GetAllSlideName(int viewCod, int slideType)
        {
            return db.AdminSlider.Where(x => x.AdminViewData.ViewCod == viewCod && x.SliderType == slideType).Select(x => x.SliderName).ToArray();
        }

        public string[] GetAllSlideClass(int viewCod, int slideType, string slideName)
        {
            return db.AdminSlider.Where(x => x.AdminViewData.ViewCod == viewCod && x.SliderType == slideType && x.SliderName == slideName).Select(x => x.SliderClass).ToArray();
        }
    }
}
