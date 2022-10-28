using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IAdminSliderRepository : IRepositoryBase<AdminSlider>
    {
        IEnumerable<AdminSlider> GetAllByViewCod(int viewCod);        
        IEnumerable<AdminSlider> GetAllByViewDataId(int viewDataId);
        int[] GetAllSlideType(int viewCod);
        string[] GetAllSlideName(int viewCod, int slideType);
        string[] GetAllSlideClass(int viewCod, int slideType, string slideName);
    }
}
