using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Application.Interface
{
    public interface IAdminSliderConfigAppService : IAppServiceBase<AdminSliderConfig>
    {
        IEnumerable<AdminSliderConfig> GetAllByViewCod(int viewCod);
        IEnumerable<AdminSliderConfig> GetAllByViewDataId(int viewDataId);
        AdminSliderConfig GetBy(int viewCod, int slideType, string slideName, string slideClass);
        int[] GetAllSlideType(int viewCod);
        string[] GetAllSlideName(int viewCod, int slideType);
        string[] GetAllSlideClass(int viewCod, int slideType, string slideName);
    }
}
