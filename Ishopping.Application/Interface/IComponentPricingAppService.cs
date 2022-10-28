using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentPricingAppService : IAppServiceBaseT2<ComponentPricing>, IComponentAppServiceBaseT2<ComponentPricing>, IComponentAppServiceBaseT2Async<ComponentPricing>
    {
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<object> GetObjetoAsync(string search, string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, bool destacar, string name, string styleName, string moeda, string styleMoeda, string priceU, string stylePriceU, string priceC, string stylePriceC, string periodo, string stylePeriodo, string description, string styleDescription, string comment, string styleComment, string textButton, string styleTextButton, string urlButton);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
