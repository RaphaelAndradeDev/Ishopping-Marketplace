using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IAdminSliderConfigService : IServiceBase<AdminSliderConfig>
    {
        IEnumerable<AdminSliderConfig> GetAllByViewCod(int viewCod);
        IEnumerable<AdminSliderConfig> GetAllByViewDataId(int viewDataId);
        AdminSliderConfig GetBy(int viewCod, int slideType, string slideName, string slideClass);
        int[] GetAllSlideType(int viewCod);
        string[] GetAllSlideName(int viewCod, int slideType);
        string[] GetAllSlideClass(int viewCod, int slideType, string slideName);
    }
}
