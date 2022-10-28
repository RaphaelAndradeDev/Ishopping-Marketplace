using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IAdminSliderService : IServiceBase<AdminSlider>
    {
        IEnumerable<AdminSlider> GetAllByViewCod(int viewCod);        
        IEnumerable<AdminSlider> GetAllByViewDataId(int viewDataId);
        int[] GetAllSlideType(int viewCod);
        string[] GetAllSlideName(int viewCod, int slideType);
        string[] GetAllSlideClass(int viewCod, int slideType, string slideName);
    }
}
