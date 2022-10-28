using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentPricingOptionAppService : IAppServiceBaseT2<ComponentPricingOption>, IOptionAppServiceBaseT1<ComponentPricingOption>, IOptionAppServiceBaseT1Async<ComponentPricingOption>
    {
        Task<JsonResponse> AppUpdateAsync(string nomePlano, string moeda, string priceUnid, string priceCent, string periodo, string description, string comment, string textButton, string price, string userId);
    }
}
