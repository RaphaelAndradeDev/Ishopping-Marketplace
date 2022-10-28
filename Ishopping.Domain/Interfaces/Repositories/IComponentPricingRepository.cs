using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentPricingRepository : IRepositoryBaseT2<ComponentPricing>, IComponentRepositoryBaseT2<ComponentPricing>, IComponentRepositoryBaseT2Async<ComponentPricing>
    {        
    }
}
