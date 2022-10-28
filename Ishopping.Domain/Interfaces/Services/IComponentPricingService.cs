using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentPricingService : IServiceBaseT2<ComponentPricing>, IComponentServiceBaseT2<ComponentPricing>, IComponentServiceBaseT2Async<ComponentPricing>
    {
    }
}
