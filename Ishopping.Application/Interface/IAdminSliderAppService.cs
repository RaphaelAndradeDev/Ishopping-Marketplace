using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ishopping.Domain.Entities;

namespace Ishopping.Application.Interface
{
    public interface IAdminSliderAppService : IAppServiceBase<AdminSlider>
    {
        IEnumerable<AdminSlider> GetAllByViewCod(int viewCod);         
        IEnumerable<AdminSlider> GetAllByViewDataId(int viewDataId);
        int[] GetAllSlideType(int viewCod);
        string[] GetAllSlideName(int viewCod, int slideType);
        string[] GetAllSlideClass(int viewCod, int slideType, string slideName);
    }
}
